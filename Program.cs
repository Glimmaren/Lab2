using System;
using System.Collections.Generic;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string checkNumber;

            //ville testa "keys syntax"
            ConsoleKey response;

            do
            {
                Console.WriteLine("****************************************************************");

                Console.Write("Enter a string: ");
                checkNumber = Console.ReadLine();

                Console.WriteLine("****************************************************************\n");

                List<string> strings = StringToList(checkNumber);

                HighLightNumbers(strings);

                do
                {
                    Console.Write("\nDo agian? (y/n):");
                    response = Console.ReadKey(false).Key;

                }while(response != ConsoleKey.Y && response != ConsoleKey.N);

                Console.WriteLine();

            } while (response == ConsoleKey.Y || response != ConsoleKey.N);

            
        }

        public static List<string> StringToList(string input)
        {
            List<string> strings = new List<string>();

            string tempString = string.Empty;
 
            int counter = 0;

            while (counter < input.Length)
            {
                for (; counter < input.Length;)
                {
                    if (char.IsDigit(input[counter]))
                    {
                        tempString += input[counter];
                        counter++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (tempString.Length > 0)
                {
                    strings.Add(tempString);
                    tempString = "";
                }

                for (; counter < input.Length;)
                {
                    if (!Char.IsDigit(input[counter]))
                    {
                        tempString += input[counter];
                        counter++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (tempString.Length > 0)
                {
                    strings.Add(tempString);
                    tempString = "";
                }
            }
            return strings;
        }

        public static void HighLightNumbers(List<string> list)
        {
            string tempItem = string.Empty;
            int secondIndex = 1;
            int fwdCount = 0;
            Int64 sum = 0;

            for (int i = 0; i < list.Count; i++)
            {
                fwdCount = 0;

                if (IsNumretic(list[i]))
                {
                Foo:

                    string temp = string.Empty;

                    for (int k = 0 + fwdCount; k < list[i].Length; k++)
                    {
                        if (k == list[i].Length - 1 && secondIndex == list[i].Length)
                        {
                            tempItem += list[i];
                        }
                        if (k == list[i].Length - 1)
                        {
                            goto Hell;
                        }

                        secondIndex = 1 + k;

                        for (int j = k; j < list[i].Length; j++)
                        {

                            if (list[i].Substring(k, 1).Equals(list[i].Substring(secondIndex, 1)))
                            {

                                temp = list[i].Substring(k, secondIndex - k + 1);

                                if (temp.Length >= 1)
                                {
                                    if (tempItem != null)
                                    {
                                        Console.Write(tempItem);
                                    }

                                    Console.Write(list[i].Substring(0, k));

                                    Console.ForegroundColor = RandomColor();
                                    Console.Write(temp);
                                    Console.ForegroundColor = ConsoleColor.White;

                                    Console.Write(list[i].Substring(secondIndex + 1));

                                    for (int o = i + 1; o < list.Count; o++)
                                    {
                                        Console.Write(list[o]);
                                    }

                                    Console.WriteLine();
                                    sum += Int64.Parse(temp);
                                    fwdCount++;
                                    goto Foo;
                                }
                            }
                            secondIndex++;

                            if (secondIndex == list[i].Length)
                            {
                                fwdCount++;
                                goto Foo;
                            }
                        }
                    }
                }
                else
                {
                    tempItem += list[i];
                }
            Hell:;

            }
            Console.WriteLine("\n----------------------------------------------------------------");
            Console.WriteLine($"The sum of all substrings are: {sum}");
            Console.WriteLine("----------------------------------------------------------------");

            static bool IsNumretic(string str)
            {
                foreach (char c in str)
                {
                    if (c < '0' || c > '9')
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public static ConsoleColor RandomColor()
        {
            Random rand = new Random();

            ConsoleColor color = ConsoleColor.White;

            switch (rand.Next(1, 5))
            {
                case 1:
                    color = ConsoleColor.Yellow;
                    break;
                case 2:
                    color = ConsoleColor.Red;
                    break;
                case 3:
                    color = ConsoleColor.Blue;
                    break;
                case 4:
                    color = ConsoleColor.Green;
                    break;
                case 5:
                    color = ConsoleColor.Red;
                    break;
                case 6:
                    color = ConsoleColor.Yellow;
                    break;
                case 7:
                    color = ConsoleColor.Magenta;
                    break;
                case 8:
                    color = ConsoleColor.Blue;
                    break;
                case 9:
                    color = ConsoleColor.Green;
                    break;
                case 10:
                    color = ConsoleColor.Magenta;
                    break;
            }
            return color;
        }
    }
}





