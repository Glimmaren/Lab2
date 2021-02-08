using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ClassLibrary
{
    public class Triangle : Shape2D, IEnumerable
    {
        private Vector2[] vectors = null;
        public override Vector3 Center { get; }
        public override float Area { get; }
        public override float Circumference { get; }
        public Vector2 P1 { get; set; }
        public Vector2 P2 { get; set; }
        public Vector2 P3 { get; set; }

        public Triangle(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            vectors = new Vector2[3];

            float centerX = (float)Math.Round((p1.X + p2.X + p3.X) / 3, 1);
            float centerY = (float)Math.Round((p1.Y + p2.Y + p3.Y) / 3, 1);

            Center = new Vector3(centerX, centerY, 0.0f);

            P1 = new Vector2(p1.X, p1.Y);
            P2 = new Vector2(p2.X, p2.Y);
            P3 = new Vector2(p3.X, p3.Y);
            
            float line1Legnth = p1.X * (p2.Y - p3.Y);
            float line2Legnth = p2.X * (p3.Y - p1.Y);
            float line3Lenght = p3.X * (p1.Y - p2.Y);
  
            Area = Math.Abs(line1Legnth + line2Legnth + line3Lenght) / 2;

            Circumference = Math.Abs(line1Legnth + line2Legnth + line3Lenght);

            vectors[0] = P1;
            vectors[1] = P2;
            vectors[2] = P3;          
        }

        public override string ToString()
        {
            //Fick krångla till det för att byta ut , emot .
            string centerX = Center.X.ToString();
            string centerY = Center.Y.ToString();

            string p1X = P1.X.ToString();
            string p1Y = P1.Y.ToString();

            string p2X = P2.X.ToString();
            string p2Y = P2.Y.ToString();

            string p3X = P3.X.ToString();
            string p3Y = P3.Y.ToString();

            return $"Triangle@({centerX.Replace(",", ".")}, {centerY.Replace(",", ".")}): p1({p1X.Replace(",", ".")}, {p1Y.Replace(",", ".")})," +
                $"p2({p2X.Replace(",", ".")}, {p2Y.Replace(",", ".")}), p3({p3X.Replace(",", ".")}, {p3Y.Replace(",", ".")})";
        }

        public IEnumerator GetEnumerator()
        {
            foreach (object o in vectors)
            {
                if(o == null)
                {
                    break;
                }
                else
                {
                    yield return o;
                }
            }
        }
    }
}
