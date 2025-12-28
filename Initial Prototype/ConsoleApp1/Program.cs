using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "Date_Intrare/FBUBBLE.TRA";

            foreach (string line in File.ReadLines(filePath))
            {
                Console.WriteLine(line);
            }
        }
    }
}
