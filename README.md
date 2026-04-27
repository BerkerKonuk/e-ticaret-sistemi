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
* **Tests/**: NUnit test senaryolarının bulunduğu klasördür.
* **Program.cs**: Uygulama derlendiğinde (F5), tüm test senaryolarının sonuçlarını görsel bir rapor halinde sunan giriş noktasıdır.

---

## 🐛 Enjekte Edilen Bilinçli Hatalar (Bugs)

Analiz derinliğini artırmak amacıyla sisteme aşağıdaki kritik hatalar eklenmiştir:

1. **KDV Hesaplama Hatası (Cart.cs)**: Sepet toplamına eklenmesi gereken %18 KDV, operatör hatası nedeniyle toplam tutardan **çıkarılmaktadır (`-`)**.
2. **Eksi Stok Kontrol Hatası (Product.cs)**: Ürün stoğu tükendiğinde veya yetersiz olduğunda sistem hata vermemekte, stoğun **eksi değerlere** düşmesine izin vermektedir.
3. **Veri Kaybı Hatası (OrderService.cs)**: Ödeme yetersiz olduğunda sistem hata fırlatmadan hemen önce müşterinin sepetini tamamen temizleyerek **veri kaybına** neden olmaktadır.

---

## 🧪 Uygulanan Test Senaryoları ve Sonuçları

NUnit kullanılarak hazırlanan 10 farklı senaryo sonucunda sistemin kararlılığı ölçülmüştür. Mantık hatalarına çarpan senaryolar kırmızı (FAIL) olarak raporlanmıştır.

### 🔴 BAŞARISIZ (FAIL) OLAN TESTLERİN ANALİZİ (4 Test)

#### 1. `[White Box]` CartCalculateTotal_CorrectlyAppliesDiscountAndTax
* **Açıklama:** KDV'nin toplama eklenmek yerine çıkarılması sonucu, beklenen tahsilat tutarı ile gerçek tutar uyuşmamaktadır.

#### 2. `[Black Box]` ProductDecreaseStock_ThrowsWhenNegative
* **Açıklama:** Stok sıfırken ürün düşülmeye çalışıldığında sistemin durmaması, sınır değer kontrol zafiyetini kanıtlamaktadır.

#### 3. `[Gray Box]` CartPaymentError_ShouldNotClearCartState
* **Açıklama:** Ödeme hatası durumunda sepetin sıfırlanması, sistemin iç durum (state) yönetimindeki hatayı yakalamıştır.

#### 4. `[Integration Test]` MultipleProducts_CalculationAndPayment
* **Açıklama:** Sepet ve Ödeme modülleri birlikte çalıştığında, KDV hatasının tüm sipariş maliyetini zincirleme olarak bozduğu tespit edilmiştir.

---

### 🟢 BAŞARILI (PASS) OLAN TESTLER (6 Test)

Sistemin kararlı çalışan kısımları aşağıdaki 6 Pass testi ile doğrulanmıştır:
1. `[White Box]` OrderServicePlaceOrder_UpdatesInnerState
2. `[White Box]` CartRemoveProduct_ReducesCount
3. `[Black Box] ` CartAddProduct_IncreasesCount
4. `[Black Box] ` ProductDecreaseStock_ReducesStockCorrectly
5. `[Gray Box]  ` OrderServicePlaceOrder_ValidOrderMustBeCheckoutState
6. `[Integration]` AddProductToCart_And_PlaceOrderSuccessfully

---

## 🚀 Projeyi Çalıştırma

1. Projeyi GitHub üzerinden klonlayın.
2. `ECommerceApp.sln` dosyasını Visual Studio 2022 veya güncel bir IDE ile açın.
3. Uygulamayı `F5` tuşu ile başlatarak konsol üzerindeki renkli test raporunu görüntüleyin.
