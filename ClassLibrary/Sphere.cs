using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ClassLibrary
{
    public class Sphere : Shape3D
    {
        public override Vector3 Center { get; }

        public override float Area { get; }

        public override float Volume { get; }

        public float Radius { get; set; }

        public Sphere(Vector3 center, float radius)
        {
            Center = new Vector3(center.X, center.Y, center.Z);
            
            Volume = Math.Abs((float)4/3 * (float)Math.PI * (float)Math.Pow(radius, 3));

            Area = Math.Abs( 4 * (float)Math.PI * (float)Math.Pow(radius, 2));

            Radius = Math.Abs(radius);
        }

        public override string ToString()
        {
            //Fick krångla till det för att byta ut , emot .
            string x = Center.X.ToString();
            string y = Center.Y.ToString();
            string z = Center.Z.ToString();

            string radius = Radius.ToString();
         
                return $"Sphere @({x.Replace(",", ".")}, {y.Replace(",", ".")}, {z.Replace(",", ".")}): r={radius.Replace(",", ".")}";
            
        }
    }
}
