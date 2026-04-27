using System;

namespace ECommerceApp;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Yazılım Test ve Kalite Analizi";
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("==================================================");
        Console.WriteLine("   E-TİCARET TEST OTOMASYONU VE RAPOR ARAYÜZÜ     ");
        Console.WriteLine("==================================================\n");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Analiz Türü: Unit, Black Box, Gray Box, Integration");
        Console.WriteLine("Toplam Senaryo: 10\n");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("--- \u2714 BAŞARILI (PASS) OLAN TESTLER (6 Test) ---");
        Console.WriteLine(" 1. [White Box] OrderService_State_Transition");
        Console.WriteLine(" 2. [White Box] Cart_Remove_Product_Verification");
        Console.WriteLine(" 3. [Black Box] Cart_Add_Product_Functionality");
        Console.WriteLine(" 4. [Black Box] Product_Stock_Standard_Update");
        Console.WriteLine(" 5. [Gray Box]  Order_Process_Status_Completed");
        Console.WriteLine(" 6. [Integration] EndToEnd_Order_Placement_Flow\n");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("--- \u274c TESPİT EDİLEN HATALAR (4 Test) ---");
        
        Console.WriteLine(" 7. [White Box] Cart_CalculateTotal_Shipping_Error");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("    - Neden: Kargo ücretinin (+) yerine (-) ile hesaplanması.\n");
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine(" 8. [Black Box] OrderService_Payment_Boundary_Match");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("    - Neden: Ödeme tutarı tam eşit olduğunda sistemin reddetmesi.\n");
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine(" 9. [Gray Box]  Product_Stock_Boundary_Check");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("    - Neden: Stok tam 1 olduğunda sistemin stok yok uyarısı vermesi.\n");
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine(" 10.[Integration] MultiProduct_Total_Calculation_Fail");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("    - Neden: Kargo hesaplama hatasının tüm sipariş maliyetini bozması.\n");

        Console.ResetColor();
        Console.WriteLine("==================================================");
        Console.WriteLine("\nÇıkmak için bir tuşa basın...");
        Console.ReadKey();
    }
}
