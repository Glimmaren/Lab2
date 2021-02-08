using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ClassLibrary
{
    public class Rectangle : Shape2D
    {
        public override Vector3 Center { get; }

        public override float Circumference { get; }

        public override float Area { get; }

        private Vector2 Size { get; set; }

        public bool IsSquare { get; set; }

        //Constructor 1
        public Rectangle(Vector2 center, Vector2 size)
        {
            Center = new Vector3(center, 0);

            Circumference = (size.X + size.Y) * 2;

            Area = size.X * size.Y;

            Size = size;

            if(Size.X == Size.Y)
            {
                IsSquare = true;
            }
            else
            {
                IsSquare = false;
            }
        }

        //Constructor 2
        public Rectangle(Vector2 center, float width)
        {
            Center = new Vector3(center, 0);

            Circumference = width * 4;

            Area = (float)Math.Pow(width, 2);

            Size = new Vector2(width, width);

            IsSquare = true;
        }

        public override string ToString() 
        {
            //Fick krångla till det för att byta ut , emot .
            string x = Center.X.ToString();
            string y = Center.Y.ToString();

            string width = Math.Abs(Size.X).ToString();
            string hight = Math.Abs(Size.Y).ToString();

            if (IsSquare)
            {
                return $"Square @({x.Replace(",", ".")}, {y.Replace(",", ".")}): w={width.Replace(",", ".")}";
            }
            else
            {
                return $"Rectangle @({x.Replace(",", ".")}, {y.Replace(",", ".")}): w={width.Replace(",", ".")}, h={hight.Replace(",", ".")}";
            }      
        }      
    }
}
