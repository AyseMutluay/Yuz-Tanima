using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.Util;
using System.IO;
using System.Linq; 
using System.Collections.Generic; 

namespace YuzTanimaProjesi
{
    public partial class Form1 : Form
    {
        private VideoCapture? _capture;
        private Mat _frame;
        private CascadeClassifier _faceCascade;
        private Mat _grayFrame;
        private Rectangle[]? _detectedFaces;
        private EigenFaceRecognizer? _faceRecognizer; 
        private List<Image<Gray, byte>> _trainingImages = new List<Image<Gray, byte>>();
        private List<string> _faceLabels = new List<string>();

        public Form1()
        {
            InitializeComponent();
            _frame = new Mat();
            _faceCascade = new CascadeClassifier("haarcascade_frontalface_default.xml");

            
            TrainRecognizer();
        }

        
        private bool TrainRecognizer()
        {
            string folderPath = Path.Combine(Application.StartupPath, "TrainedFaces");
            if (!Directory.Exists(folderPath)) return false;

            var imageFiles = Directory.GetFiles(folderPath, "*.bmp", SearchOption.AllDirectories);
            if (imageFiles.Length == 0) return false;

            _trainingImages.Clear();
            _faceLabels.Clear();

            foreach (var filePath in imageFiles)
            {
                _trainingImages.Add(new Image<Gray, byte>(filePath));
                _faceLabels.Add(Path.GetFileNameWithoutExtension(filePath).Split('.')[0]);
            }

            int[] labels = new int[_faceLabels.Count];
            for (int i = 0; i < _faceLabels.Count; i++)
            {
                labels[i] = i;
            }

            if (_trainingImages.Count > 0)
            {
                var imageArray = new VectorOfMat();
                foreach (var img in _trainingImages)
                {
                    imageArray.Push(img.Mat);
                }

                var labelArray = new VectorOfInt(labels);

                
                _faceRecognizer = new EigenFaceRecognizer(80, double.PositiveInfinity);
                _faceRecognizer.Train(imageArray, labelArray);
                return true;
            }
            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_capture == null)
            {
                _capture = new VideoCapture(0, VideoCapture.API.DShow);
            }

            if (_capture != null && _capture.IsOpened)
            {
                Application.Idle += ProcessFrame;
                btnStart.Enabled = false;
            }
            else
            {
                MessageBox.Show("HATA: Kamera baþlatýlamadý!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcessFrame(object? sender, EventArgs e)
        {
            if (_capture != null && _capture.IsOpened)
            {
                _capture.Retrieve(_frame);

                if (!_frame.IsEmpty)
                {
                    _grayFrame = new Mat();
                    CvInvoke.CvtColor(_frame, _grayFrame, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                    CvInvoke.EqualizeHist(_grayFrame, _grayFrame);

                    _detectedFaces = _faceCascade.DetectMultiScale(_grayFrame, 1.1, 10, new Size(20, 20));

                    if (_detectedFaces != null && _detectedFaces.Length > 0)
                    {
                        foreach (var face in _detectedFaces)
                        {
                            CvInvoke.Rectangle(_frame, face, new MCvScalar(0, 255, 0), 2);

                            if (_faceRecognizer != null && _trainingImages.Count > 0)
                            {
                                
                                Mat faceRoi = new Mat(_grayFrame, face);

                                Mat resizedFace = new Mat();

                                CvInvoke.Resize(faceRoi, resizedFace, new Size(100, 100), 0, 0, Emgu.CV.CvEnum.Inter.Cubic);
                                var resultPrediction = _faceRecognizer.Predict(resizedFace);
                                string name;

                                if (resultPrediction.Label != -1 && resultPrediction.Distance > 2500 && resultPrediction.Distance < 4000)
                                {
                                    name = _faceLabels[resultPrediction.Label];
                                }
                                else
                                {
                                    name = "Bilinmiyor";
                                }

                                string label = $"{name} ({resultPrediction.Distance:F0})";
                                CvInvoke.PutText(_frame, label, new Point(face.X, face.Y - 10),
                                    Emgu.CV.CvEnum.FontFace.HersheyComplex, 0.6, new MCvScalar(255, 255, 0), 1);
                            }
                        }
                    }
                    picCapture.Image = _frame.ToBitmap();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string folderPath = Path.Combine(Application.StartupPath, "TrainedFaces");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (_detectedFaces != null && _detectedFaces.Length > 0 && !string.IsNullOrEmpty(txtName.Text))
            {
                Mat result = new Mat(_grayFrame, _detectedFaces[0]);
                CvInvoke.Resize(result, result, new Size(100, 100), 0, 0, Emgu.CV.CvEnum.Inter.Cubic);

                int fileCount = Directory.GetFiles(folderPath, txtName.Text + ".*").Length + 1;
                string fileName = txtName.Text + "." + fileCount + ".bmp";
                result.Save(Path.Combine(folderPath, fileName));

                MessageBox.Show("Yüz baþarýyla kaydedildi! Tanýmanýn baþlamasý için programý yeniden baþlatýn.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

               
                TrainRecognizer();
            }
            else
            {
                MessageBox.Show("Lütfen önce bir yüzün algýlandýðýndan ve bir isim girdiðinizden emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}