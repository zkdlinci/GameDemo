using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceReference1;

namespace GameDemo
{
    public class CustomerManager
    {
        private readonly ServiceReference1.KPSPublicSoapClient _client;

        public CustomerManager(KPSPublicSoapClient client)
        {
            _client = client;
        }

        private List<Customer> CustomerList { get; }

        //public CustomerManager(KPSPublicSoapClient kPSPublicSoapClient)
        //{
        //    CustomerList = new List<Customer>();
        //}

        public void Validate(Customer customer)
        {
            Task<TCKimlikNoDogrulaResponse> response = _client.TCKimlikNoDogrulaAsync(customer.NationalId, customer.Name, customer.Surname, customer.DateOfBirth);


            Console.WriteLine(response.Result.Body.TCKimlikNoDogrulaResult
                ? "Bilgiler doğrulandı. Hoşgeldiniz " + customer.Name
                : "Hatalı giriş"
                ) ;
            
        }

        public void Delete(Customer customer)
        {
            if (customer == null)
            {
                return;
            }
            else
            {
                CustomerList.Remove(customer);
                Console.WriteLine("Silme işlemi başarılı: " + customer.Name);
            }

        }

        public Customer Update(string NationalId)
        {
            foreach (Customer customer in CustomerList)
            {
                if (customer.NationalId.Equals(NationalId))
                {
                    return customer;
                }

            }
            return null;
        }
    }
}
