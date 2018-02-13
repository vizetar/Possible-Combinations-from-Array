using System;
using System.Collections.Generic;

namespace SotiQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            Query program = new Query();
            
            // get combination from method written in Query class
            List<int[]> list = program.GetCombination(20);

            // display result on console
            string result = string.Empty;
            foreach (var res in list)
            {
                for (int i=0;i<res.Length;i++)
                {
                    result = result + res[i]+ "+";
                }
                result = result.TrimEnd('+');
                Console.Write("["+result+"]");
                result = string.Empty;
                Console.WriteLine();

            }
            Console.ReadLine();

        }
    }

    
}
