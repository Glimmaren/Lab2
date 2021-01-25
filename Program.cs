using System;
using System.Collections.Generic;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string checkString;

            //ville testa "keys syntax1."
            ConsoleKey response;

            do
            {
                Console.WriteLine("****************************************************************");

                Console.Write("Enter a string: ");
                checkString = Console.ReadLine();

                Console.WriteLine("****************************************************************\n");

                List<string> strings = StringToList(checkString);

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
            
            string tempItem = string.Empty; //Förvarar dem främre substringen

            string substring = string.Empty; //Förvarar Substringen som skall färgas

            int stepFwd = 0; //Används för att flytta fram scopet på stringen
       
            int firstIndex; //Firstindex är indexet på det första jämnförelsenummret
            
            int secondIndex = 1; //SecondIndex är idexet i stringen på det andra jämförhetsnummret

            Int64 sum = 0;// Förvarar summan av de färgade talen

            for (int i = 0; i < list.Count; i++)//Kollar igenom listan efter strängar som skall jämföras
            {
                stepFwd = 0;

                if (IsNumretic(list[i]))
                {
                Foo:

                    substring = string.Empty;

                    for (firstIndex = 0 + stepFwd; firstIndex < list[i].Length; firstIndex++)
                    {
                        if (firstIndex == list[i].Length - 1 && secondIndex == list[i].Length)
                        {
                            tempItem += list[i];
                        }
                        if (firstIndex == list[i].Length - 1)
                        {
                            goto Hell;
                        }

                        secondIndex = 1 + firstIndex;

                        for (int j = firstIndex; j < list[i].Length; j++)
                        {

                            if (list[i].Substring(firstIndex, 1).Equals(list[i].Substring(secondIndex, 1))) //Jämför talen i stränegn
                            {

                                substring = list[i].Substring(firstIndex, secondIndex - firstIndex + 1);

                                if (substring.Length >= 1) // Färgsätter och skriver ut
                                {
                                    if (tempItem != null)
                                    {
                                        Console.Write(tempItem);
                                    }

                                    Console.Write(list[i].Substring(0, firstIndex));

                                    Console.ForegroundColor = RandomColor();
                                    Console.Write(substring);
                                    Console.ForegroundColor = ConsoleColor.White;

                                    Console.Write(list[i].Substring(secondIndex + 1));

                                    for (int o = i + 1; o < list.Count; o++)
                                    {
                                        Console.Write(list[o]);
                                    }

                                    Console.WriteLine();

                                    sum += Int64.Parse(substring); // Lägger ihop summan av de markerade

                                    stepFwd++;

                                    goto Foo;
                                }
                            }
                            secondIndex++;

                            if (secondIndex == list[i].Length)
                            {
                                stepFwd++;
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





