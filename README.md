# Yüz Tanıma Projesi

Bu proje, C#, Visual Studio (Windows Forms) ve **Emgu.CV** (OpenCV kütüphanesinin .NET sarmalayıcısı) kullanılarak geliştirilmiş temel bir gerçek zamanlı yüz tanıma uygulamasıdır. Uygulama, bir web kamerasından canlı video akışı alabilir, görüntüdeki insan yüzlerini tespit edebilir, yeni yüzleri bir isimle veritabanına kaydedebilir ve daha önceden kaydettiği yüzleri tanıyarak ekranda ismini gösterebilir.

## 🚀 Demo


## ✨ Özellikler

- **Gerçek Zamanlı Yüz Tespiti:** Kamera görüntüsündeki yüzleri anlık olarak algılar ve etraflarını bir dikdörtgen ile işaretler.
- **Yeni Yüz Kaydetme:** Tespit edilen bir yüzü, metin kutusuna girilen bir isimle birlikte sisteme kaydeder.
- **Kayıtlı Yüzleri Tanıma:** Daha önce kaydedilmiş yüzleri tanır ve kişinin ismini, bir "benzerlik mesafesi" değeriyle birlikte ekranda gösterir.
- **Bilinmeyen Yüzleri Etiketleme:** Veritabanında bulunmayan yüzleri "Bilinmiyor" olarak işaretler.
- **Basit ve Kullanıcı Dostu Arayüz:** Windows Forms kullanılarak tasarlanmış anlaşılır bir arayüze sahiptir.

## 🛠️ Kullanılan Teknolojiler

- **C#** & **.NET 8.0**
- **Windows Forms** - Masaüstü uygulama arayüzü için
- **Visual Studio** - Geliştirme ortamı
- **Emgu.CV** - Görüntü işleme ve yüz tanıma için temel kütüphane
- **Haar Cascade Sınıflandırıcısı** - Yüz tespiti için kullanılan önceden eğitilmiş model (`haarcascade_frontalface_default.xml`)
- **EigenFaceRecognizer** - Yüz tanıma için kullanılan algoritma

## 🔧 Kurulum ve Çalıştırma

Bu uygulamayı kullanmak için herhangi bir kod derlemesine veya geliştirme ortamına ihtiyacınız yoktur. Sadece çalıştırılabilir dosyaları indirip kullanmaya başlayabilirsiniz.

#### Ön Gereksinimler

- **Windows 10 veya üzeri** bir işletim sistemi.
- **.NET Desktop Runtime 8.0** Eğer bilgisayarınızda yüklü değilse, program çalışırken bir hata alabilirsiniz.
- Bilgisayarınıza bağlı bir **web kamerası**.

#### Çalıştırma Adımları

1.  **En Son Sürümü İndirin:**
    - Bu sayfanın sağ tarafında bulunan **"Releases"** bölümüne gidin.
    - En güncel sürümün (en üstteki) altındaki **"Assets"** (Varlıklar) kısmını genişletin.
    - `Yuz-Tanima-v1.0.zip` dosyasına tıklayarak indirin.

2.  **ZIP Dosyasını Çıkartın:**
    - İndirdiğiniz `.zip` dosyasına sağ tıklayın.
    - **"Tümünü Ayıkla..."** (Extract All...) seçeneğini seçin ve dosyaları istediğiniz bir klasöre çıkartın.

3.  **Uygulamayı Başlatın:**
    - Dosyaları çıkardığınız klasörün içine girin.
    - `YuzTanimaProjesi.exe` adındaki dosyayı bulun ve çift tıklayarak çalıştırın.

4.  **Kamera İzinleri:**
    - Uygulama ilk kez çalıştığında, Windows veya antivirüs yazılımınız kameraya erişim izni isteyebilir. Uygulamanın düzgün çalışabilmesi için bu izni vermeniz gerekmektedir.

## 📖 Kullanım

1.  **Yüz Kaydetme:**
    - Kamera karşısına geçin. Yüzünüzün etrafında yeşil bir kutu belirecektir.
    - Altındaki metin kutusuna isminizi yazın.
    - `Yüz Kaydet` butonuna tıklayın.
    - Daha iyi tanıma sonuçları için aynı kişiye ait, farklı açılardan ve ışık koşullarından birkaç fotoğraf kaydetmeniz önerilir.

2.  **Yüz Tanıma:**
    - Program, daha önce kaydettiğiniz bir yüzü gördüğünde, kutunun üzerinde kişinin ismini ve parantez içinde bir benzerlik mesafesi değeri gösterecektir. (Düşük mesafe, daha iyi eşleşme demektir.)
    - Sistemde kayıtlı olmayan yüzler için `Bilinmiyor` etiketi gösterilecektir.
## Geliştirici  
*Ayşe MUtluay
