using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDemo
{
    public class Customer
    {
        private string _name;
        private string _surname;

        public string Name
        {
            get
            {
                return _name.ToUpper(CultureInfo.CurrentCulture);
            }

            set
            {
                _name = value;
            }
        }
        public string Surname
        {
            get
            {
                return _surname.ToUpper(CultureInfo.CurrentCulture);
            }

            set
            {
                _surname = value;
            }
        }
        public int DateOfBirth { get; set; }
        public string NationalId { get; set; }
        public float Balance { get; set; }
    }
}