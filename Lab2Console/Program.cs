using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Object[] arrayOfShapes = MakeAListOfrandomShapes(20);

            //For test of the IEnumerble
            Triangle triangle = new Triangle(new Vector2(2.5f, 2.5f), new Vector2(2.5f, 5.5f), new Vector2(6.5f, 7.5f));

            PrintAllInfo(arrayOfShapes);

            TestTheEnumerable(triangle);

            Console.ReadLine();
        }

        public static Object[] MakeAListOfrandomShapes(int size)
        {
            object[] arrayOfShapes = new object[size];

            for (int i = 0; i < size; i++)
            {
                arrayOfShapes[i] = Shape.GenerateShape();
            }

            return arrayOfShapes;
        }
        public static float SumOfCirumference(Object[] o)
        {
            List<Triangle> triangleList = new List<Triangle>();

            float sumOfTriangleCirc = 0;

            for (int i = 0; i < o.Length; i++)
            {
                if (o[i] is Triangle triangle)
                {
                    sumOfTriangleCirc += triangle.Circumference;
                }
            }

            return sumOfTriangleCirc;
        }
        public static void PrintBiggest3DShape(object[] o)
        {
            List<Sphere> sphereList = new List<Sphere>();
            List<Cuboid> cuboidList = new List<Cuboid>();

            for (int i = 0; i < o.Length; i++)
            {
                if (o[i] is Sphere sphere)
                {
                    sphereList.Add(sphere);
                }
            }

            sphereList.Sort((x, y) => y.Volume.CompareTo(x.Volume));

            for (int i = 0; i < o.Length; i++)
            {
                if (o[i] is Cuboid cuboid)
                {
                    cuboidList.Add(cuboid);
                }
            }
 
            cuboidList.Sort((x, y) => y.Volume.CompareTo(x.Volume));

            Console.WriteLine("\n*********************************************************************************\n");

            if (sphereList.Count != 0 && cuboidList.Count != 0)
            {
                if (sphereList[0].Volume > cuboidList[0].Volume)
                {                  
                    Console.WriteLine($"The Shape3D with the biggest volym is: " +
                        $"\n{sphereList[0].ToString()}" +
                        $"\nWith a volume of {sphereList[0].Volume}");
                }
                else
                {
                    Console.WriteLine($"The Shape3D with the biggest volym is: " +
                        $"\n{cuboidList[0].ToString()}" +
                        $"\nWith a volume of {cuboidList[0].Volume}");
                } 

            }else if(sphereList.Count != 0 && cuboidList.Count == 0)
            {
                Console.WriteLine($"The Shape3D with the biggest volym is: " +
                    $"\n{sphereList[0].ToString()}" +
                    $"\nWith a volume of {sphereList[0].Volume}");
            }
            else if(sphereList.Count == 0 && cuboidList.Count != 0)
            {
                Console.WriteLine($"The Shape3D with the biggest volym is: " +
                    $"\n{cuboidList[0].ToString()}" +
                    $"\nWith a volume of {cuboidList[0].Volume}");
            }
            else
            {
                Console.WriteLine("There are none shapes with volume!");
            }

            Console.WriteLine("\n*********************************************************************************");
        }
        public static float AvgArea(object[] o)
        {
            float sumArea = 0, avgArea = 0;

            for (int i = 0; i < o.Length; i++)
            {
                if(o[i] is Shape shape)
                {
                    sumArea += shape.Area;
                }
            }

            avgArea = sumArea / o.Length;

            return avgArea;
        }
        public static void TestTheEnumerable(Triangle tri)
        {
            
            Console.WriteLine("\nThis is just a test to prove the implement of IEnuerable");

            for (int i = 0; i < 15; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("**************");

            foreach (var vector in tri)
            {
                for (int i = 0; i < 15; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine($"* {vector} *");
            }

            for (int i = 0; i < 15; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("**************");

        }
        public static void PrintAllInfo(object[] o)
        {
            float theSumOfAllCircumference;
            float avgArea;

            theSumOfAllCircumference = SumOfCirumference(o);
            avgArea = AvgArea(o);

            Console.WriteLine("*********************************************************************************");
            Console.WriteLine("All shapes in the list:");

            foreach (var item in o)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("\n*********************************************************************************\n");

            if (theSumOfAllCircumference == 0)
            {
                Console.WriteLine($"The sum of the triangles circumference is: {theSumOfAllCircumference}, becuse they are no triangles");
            }
            else
            {
                Console.WriteLine($"The sum of circumference of the list triangles is: {theSumOfAllCircumference}");
            }

            Console.WriteLine($"The average area om all Shapes is: {avgArea}");

            PrintBiggest3DShape(o);
        }
    }
}
