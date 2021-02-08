using System;
using System.Numerics;

namespace ClassLibrary
{
    public abstract class Shape
    {
        static Random rand = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
        public abstract Vector3 Center { get; }
        public abstract float Area { get; }
        public static object GenerateShape()
        {
            //Random Center
            float randomCenterX = RandomFloat();
            float randomCenterY = RandomFloat();
            float randomCenterZ = RandomFloat();

            //Ranodm Size
            float randomRadius = RandomFloat();

            float randomSizeW = RandomFloat();
            float randomSizeH = RandomFloat();
            float randomSizeD = RandomFloat();

            //In case of triangle
            float randomP1X = RandomFloat();
            float randomP1Y = RandomFloat();
            float randomP2X = RandomFloat();
            float randomP2Y = RandomFloat();
            float randomP3X = RandomFloat();
            float randomP3Y = RandomFloat();

            switch (rand.Next(0, 7))
            {
                case 0:
                    return new Circle(new Vector2(randomCenterX, randomCenterY), randomRadius);

                case 1:
                    return new Rectangle(new Vector2(randomCenterX, randomCenterY), new Vector2(randomSizeW, randomSizeH));

                case 2:
                    return new Rectangle(new Vector2(randomCenterX, randomCenterY), randomSizeW);

                case 3:
                    return new Triangle(new Vector2(randomP1X, randomP1Y), new Vector2(randomP2X, randomP2Y), new Vector2(randomP3X, randomP3Y));

                case 4:
                    return new Cuboid(new Vector3(randomCenterX, randomCenterY, randomCenterZ), new Vector3(randomSizeW, randomSizeH, randomSizeD));

                case 5:
                    return new Cuboid(new Vector3(randomCenterX, randomCenterY, randomCenterZ), randomSizeW);

                default:
                    return new Sphere(new Vector3(randomCenterX, randomCenterY, randomCenterZ), randomRadius);

            }
        }

        //TODO fix triangle
        public static object GenerateShape(Vector3 position)
        {

            //Ranodm Size
            float randomRadius = RandomFloat();
            float randomSizeW = RandomFloat();
            float randomSizeH = RandomFloat();
            float randomSizeD = RandomFloat();

            switch (rand.Next(0, 7))
            {
                case 0:
                    return new Circle(new Vector2(position.X, position.Y), randomRadius);

                case 1:
                    return new Rectangle(new Vector2(position.X, position.Y), new Vector2(randomSizeW, randomSizeH));

                case 2:
                    return new Rectangle(new Vector2(position.X, position.Y), randomSizeW);

                case 3:
                    return new Triangle(new Vector2(position.X, position.Y), new Vector2(randomSizeW, randomSizeH), new Vector2(position.X, position.Y));

                case 4:
                    return new Cuboid(new Vector3(position.X, position.Y, position.Z), new Vector3(randomSizeW, randomSizeH, randomSizeD));

                case 5:
                    return new Cuboid(new Vector3(position.X, position.Y, position.Z), randomSizeW);

                default:
                    return new Sphere(new Vector3(position.X, position.Y, position.Z), randomRadius);

            }
        }

        //Behövde random floats till vectorer mm och hittade ingen lösning som jag förstod så jag gjorde en egen, ta inte bort VG pga detta!!=)
        //Jag har avrundat dem till en decimal med!
        private static float RandomFloat()
        {
            float num1 = rand.Next(-100, 101);
            float num2 = (float)rand.NextDouble();

            float rndNumber = num1 * num2;

            return (float)Math.Round(rndNumber,1);
        }

    }
}
