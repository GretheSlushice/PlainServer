using System.Collections.Generic;
using System.Text;

namespace ModelLib
{
    public class AutoSale
    {
        public string Name;
        public string Address;
        public List<Car> Cars;

        public AutoSale(string name, string address)
        {
            Name = name;
            Address = address;
            Cars = new List<Car>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Name+", "+Address);
            foreach (var car in Cars)
            {
                sb.Append(", ");
                sb.Append(car);
            }
            
            return sb.ToString();
        }
    }
}