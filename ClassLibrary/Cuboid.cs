using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ClassLibrary
{
    public class Cuboid : Shape3D
    {
        public override Vector3 Center { get; }

        public override float Area { get; }

        public override float Volume { get; }

        public Vector3 Size { get; set; }

        public bool IsCube { get; set; }

        public Cuboid(Vector3 center, Vector3 size)
        {
            Center = new Vector3(center.X, center.Y, center.Z);

            Size = new Vector3(size.X, size.Y, size.Z);

            Area = Math.Abs((size.X * size.Y) * 2) + ((size.X * size.Z) * 2) + ((size.Z * size.Y) * 2);

            Volume = Math.Abs(size.X * size.Y * size.Z);

            if(size.X == size.Y && size.Y == size.Z)
            {
                IsCube = true;
            }
            else
            {
                IsCube = false;
            }
        }

        public Cuboid(Vector3 center, float width)
        {
            Center = new Vector3(center.X, center.Y, center.Z);

            Size = new Vector3(width, 0, 0);

            Area = ((float)Math.Pow(width, 2)) * 6;

            Volume = Math.Abs((float)Math.Pow(width, 3));

            IsCube = true;
        }

        public override string ToString()
        {
            //Fick krångla till det för att byta ut , emot .
            string x = Center.X.ToString();
            string y = Center.Y.ToString();
            string z = Center.Z.ToString();

            string width = Math.Abs(Size.X).ToString();
            string hight = Math.Abs(Size.Y).ToString();
            string depth = Math.Abs(Size.Z).ToString();


            if (IsCube)
            {
                return $"Cube @({x.Replace(",", ".")}, {y.Replace(",", ".")}, {z.Replace(",", ".")}): s={width.Replace(",", ".")}";
            }
            else
            {
                return $"Cuboid @({x.Replace(",", ".")}, {y.Replace(",", ".")}): w={width.Replace(",", ".")}, h={hight.Replace(",", ".")}, d={depth.Replace(",", ".")}";
            }

        }
    }
}
