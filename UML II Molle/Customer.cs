using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_II_Molle
{
    public class Customer
    {
        public string Name { get; private set; }
        public string Phone { get; set; }



        public Customer(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }

        public override string ToString()
        {
            string cstmInfo = $"Customer name: {Name}\nCustomer phone: {Phone}";
            return cstmInfo;
        }
    }
}
