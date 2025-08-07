// First Commit testing {
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;              
using Microsoft.Extensions.Configuration; 
using FrontLearn_1.Data;
using FrontLearn_1.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddScoped<UserService>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:4200","https://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod());
});


var app = builder.Build();


app.UseCors("AllowFrontend");
app.MapControllers();
app.Run();






    
public partial class Program
{
    /*
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
    */
}  

