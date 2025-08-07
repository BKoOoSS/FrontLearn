// First Commit testing {
public partial class Program
{
    static void Main()
    {
        Random random = new Random();
        int hedefSayi = random.Next(1, 11); // 1 ile 10 arasında sayı üretir
        int tahmin = 0;
        int denemeSayisi = 0;

        Console.WriteLine("1 ile 10 arasında bir sayı tahmin edin.");

        while (tahmin != hedefSayi)
        {
            Console.Write("Tahmininiz: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out tahmin))
            {
                denemeSayisi++;
                if (tahmin < hedefSayi)
                {
                    Console.WriteLine("Daha büyük bir sayı girin.");
                }
                else if (tahmin > hedefSayi)
                {
                    Console.WriteLine("Daha küçük bir sayı girin.");
                }
            }
            else
            {
                Console.WriteLine("Lütfen geçerli bir sayı girin.");
            }
        }

        Console.WriteLine($"Tebrikler! {denemeSayisi} denemede doğru tahmin ettiniz.");
    }
}  

