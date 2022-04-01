using ServiceReference1;
using System;

namespace GameDemo
{
    public class Program
    {
        static void Main(String[] args)
        {
            Console.WriteLine("--------------------------Oyun Şeysi--------------------------");
            Console.WriteLine("Giriş yapmak için lütfen gerekli bilgileri giriniz.");
            CustomerManager customerManager = new(new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap));

            Game game = new("Tomb Raider", "Savaşıyon parkur yapıyon falan filan", 150.3f);
            Game game2 = new("Five Nights At Freddy's", "Foxy>>>", 300.74f);
            Game game3 = new("League Of Legends", "Çöp", 30.2f);
            Game game4 = new("There Is No Game", "Indie oyun ama müq", 70.41f);


            Customer customer = new Customer();
            customer.Balance = 200;

            Console.Write("Ad: ");
            customer.Name = Console.ReadLine();

            Console.Write("Soyad: ");
            customer.Surname = Console.ReadLine();

            Console.Write("Doğum Tarihi: ");
            customer.DateOfBirth = Convert.ToInt32(Console.ReadLine());

            Console.Write("Tc Kimlik Numarası: ");
            customer.NationalId = Console.ReadLine();

            customerManager.Validate(customer);

            Console.WriteLine("--------------------------------------------------------------");

            Console.Write("Lütfen yapmak istediğiniz işlemin adını giriniz: ");

            string operation = Console.ReadLine();

            switch (operation)
                {
                case "oyun satın almak":
                    Console.WriteLine("Satın almak istediğiniz oyunun adını yazınız: ");
                    game.Name = Console.ReadLine();

                    bool gm = GameManager.PurchaseGame(customer, game);
                    if (gm == true)
                    {
                        Console.WriteLine("Satın alma başarılı!");
                        Console.Write("Kalan bakiyeniz: " + customer.Balance);
                    }
                    else
                    {
                        Console.WriteLine("Bakiyeniz Yetersiz.");
                    }
                    break;
            }

            

        }
    }
}
