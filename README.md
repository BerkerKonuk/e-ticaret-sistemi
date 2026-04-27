# 🛒 E-Ticaret Yazılım Test ve Kalite Analiz Projesi

## 👤 Öğrenci Bilgileri
* **Ad Soyad:** Berker Konuk
* **Öğrenci No:** 20230108038
* **Bölüm:** Bilgisayar Programcılığı
* **Üniversite:** Piri Reis Üniversitesi
* **Ders:** MTH2005 Yazılım Test ve Kalitesi

---

## 📝 Proje Özeti
Bu proje, "Yazılım Test ve Kalitesi" dersi kapsamında, modern test metodolojilerini uygulamalı olarak göstermek amacıyla geliştirilmiştir. İçerisinde bilinçli olarak bırakılmış **mantıksal hatalar (bug)** barındıran bir .NET 9 konsol uygulamasıdır.

Projenin temel amacı; Unit Test, Integration Test, White-Box, Black-Box ve Gray-Box tekniklerini kullanarak sistemdeki açıkları **NUnit** framework'ü ile tespit etmektir.

---

## 🏗️ Proje Mimarisi

Sistem, uçtan uca bir e-ticaret akışını (Ürün -> Sepet -> Ödeme) simüle eden modüllerden oluşur:

* **Core/**: İş mantığının (Business Logic) bulunduğu sınıflardır (`Product.cs`, `Cart.cs`, `OrderService.cs`).
* **Program.cs**: Uygulama derlendiğinde (F5), tüm test senaryolarının sonuçlarını görsel bir rapor halinde sunan giriş noktasıdır.

---

## 🐛 Enjekte Edilen Bilinçli Hatalar (Bugs)

Analiz derinliğini artırmak amacıyla sisteme aşağıdaki kritik hatalar eklenmiştir:

1. **Kargo Maliyet Hatası (Cart.cs)**: Sepet toplamına eklenmesi gereken sabit kargo ücreti, operatör hatası nedeniyle toplam tutardan **çıkarılmaktadır (`-`)**.
2. **Ödeme Sınır Değer Hatası (OrderService.cs)**: Müşterinin ödediği tutar sepet toplamına kuruşu kuruşuna eşit olsa dahi, sistem hatalı bir karşılaştırma operatörü nedeniyle ödemeyi **reddetmektedir**.
3. **Stok Kritik Seviye Hatası (Product.cs)**: Ürün stoğu tam olarak "1" olduğunda, sistem yanlış bir mantıkla stok yok uyarısı vermekte ve satışı engellemektedir.

---

## 🧪 Uygulanan Test Senaryoları ve Sonuçları

NUnit kullanılarak hazırlanan 10 farklı senaryo sonucunda sistemin kararlılığı ölçülmüştür. Mantık hatalarına çarpan senaryolar kırmızı (FAIL) olarak raporlanmıştır.

### 🔴 BAŞARISIZ (FAIL) OLAN TESTLERİN ANALİZİ (4 Test)

#### 1. `[White Box]` Cart_CalculateTotal_Shipping_Error
* **Açıklama:** Kargo ücretinin toplama eklenmek yerine çıkarılması sonucu, beklenen tahsilat tutarı ile gerçek tutar uyuşmamaktadır.

#### 2. `[Black Box]` OrderService_Payment_Boundary_Match
* **Açıklama:** Tam tutar ile yapılan ödemelerde sistemin hata vermesi, ödeme modülündeki sınır değer zafiyetini kanıtlamaktadır.

#### 3. `[Gray Box]` Product_Stock_Boundary_Check
* **Açıklama:** Stokta 1 adet ürün varken yapılan alımların reddedilmesi, sistemin iç durum (state) yönetimindeki hatayı yakalamıştır.

#### 4. `[Integration Test]` MultiProduct_Total_Calculation_Fail
* **Açıklama:** Sepet ve Ödeme modülleri birlikte çalıştığında, kargo hatasının tüm sipariş maliyetini zincirleme olarak bozduğu tespit edilmiştir.

---

### 🟢 BAŞARILI (PASS) OLAN TESTLER (6 Test)

Sistemin kararlı çalışan kısımları aşağıdaki 6 Pass testi ile doğrulanmıştır:
1. `[White Box]` OrderService_State_Transition
2. `[White Box]` Cart_Remove_Product_Verification
3. `[Black Box] ` Cart_Add_Product_Functionality
4. `[Black Box] ` Product_Stock_Standard_Update
5. `[Gray Box]  ` Order_Process_Status_Completed
6. `[Integration]` EndToEnd_Order_Placement_Flow

---

## 🚀 Projeyi Çalıştırma

1. Projeyi GitHub üzerinden klonlayın.
2. `ECommerceApp.sln` dosyasını Visual Studio 2022 veya güncel bir IDE ile açın.
3. Uygulamayı `F5` tuşu ile başlatarak konsol üzerindeki renkli test raporunu görüntüleyin.
4. Kaynak koddaki detaylar için Visual Studio üst menüsünden **Test > Test Explorer (Test Gezgini)** aracını kullanabilirsiniz.
