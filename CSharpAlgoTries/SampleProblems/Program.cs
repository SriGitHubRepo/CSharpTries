using System;
using System.Linq;

namespace SampleProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(PerformBinaryAdditionsOnStrings("1100", "1011"));
            Console.ReadLine();
        }

        /// <summary>
        /// Does the binary additions on string
        /// e.g a =  "1101" b =  "1010 
        /// result is "10111"
        /// note that the input is always a string
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string PerformBinaryAdditionsOnStrings(string a, string b)
        {
            //first determine the largest of size

            int legth = a.Length > b.Length ? a.Length : b.Length;
            if(a.Length > b.Length)
            {
                int extalength = a.Length - b.Length;
                b = string.Concat(Enumerable.Repeat("0", extalength)) + b;
            }
            else if(b.Length < a.Length)
            {
                int extalength = b.Length - a.Length;
                a = string.Concat(Enumerable.Repeat("0", extalength)) + a;
            }

            //iterate backwords by taking one charater on each string and perform binary addition
            string carryover = "0";
            string sum = "";
            for(int index = legth - 1; index >=0; index--)
            {
                if (carryover == "0")
                {
                    if (a[index] == '1' && b[index] == '1')
                    {
                        sum = "0" + sum;
                        carryover = "1";
                    }
                    if ((a[index] == '0' && b[index] == '1') || (a[index] == '1' && b[index] == '0'))
                    {
                        sum = "1" + sum;
                        carryover = "0";
                    }
                    if (a[index] == '0' && b[index] == '0')
                    {
                        sum = "0" + sum;
                        carryover = "0";
                    }
                }
                else if (carryover == "1")
                {
                    if (a[index] == 1 && b[index] == 1)
                    {
                        sum = "1" + sum;
                        carryover = "1";
                    }
                    if ((a[index] == 0 && b[index] == 1) || (a[index] == 1 && b[index] == 0))
                    {
                        sum = "0" + sum;
                        carryover = "1";
                    }
                    if (a[index] == '0' && b[index] == '0')
                    {
                        sum = "0" + sum;
                        carryover = "0";
                    }
                }

            }
            return carryover + sum;
        }
    }
}
