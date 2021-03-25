using System;
using System.Collections.Generic;
using System.Text;

namespace _5_Person
{
    class Person
    {
        private string name;
        private int weight;
        private double height;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        public string GetName()
        { return name; }

        public void SetName(string value)
        { name = value; }

        public int GetWeight()
        { return weight; }

        public void SetWeight(int value)
        { weight = value; }

        public double GetHeight()
        { return height; }

        public void SetHeight(double value)
        { height = value; }

        public double CalculateBMI()
        {
            return weight / (height * height);
        }

        public String BodyCategory()
        {
            double bodyMassIndex = CalculateBMI();

            if (bodyMassIndex < 18.5)
                return "underweight";
            else if (bodyMassIndex > 25)
                return "overweight";
            else
                return "normal weight";
        }

        public String DisplayInformation()
        {
            return name + ", " + weight + " kg, " + height + " m, BMI: " + CalculateBMI() + " (" + BodyCategory() + ")";
        }
    }
}
