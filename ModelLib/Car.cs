using System;

namespace ModelLib
{
    public class Car
    {
        public string Model;
        public string Color;
        public string RegNumber;

        public Car(string model, string color, string regNumber)
        {
            Model = model;
            Color = color;
            RegNumber = regNumber;
        }

        public override string ToString()
        {
            return Model +"," + Color+ "," + RegNumber;
        }
    }
}
