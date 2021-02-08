using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;


namespace ClassLibrary
{
    public class Circle : Shape2D
    {
        public override Vector3 Center { get; }

        public override float Circumference { get; }

        public override float Area { get; }

        public float Radius { get; set; }

        //Constructor
        public Circle(Vector2 center, float radius)
        {
            Center = new Vector3(center, 0);

            this.Area = (float)Math.Pow(radius,2) * (float)Math.PI;

            Radius = Math.Abs(radius);

            Circumference = (radius * 2) * (float)Math.PI;
        }
      
        public override string ToString()
        {
            //Fick krångla till det för att byta ut , emot .
            string x = Center.X.ToString();
            string y = Center.Y.ToString();

            string radius = Radius.ToString();

            return $"Circle @({x.Replace(",", ".")}, {y.Replace(",", ".")}): r={radius.Replace(",", ".")}";

        }
    }
}
