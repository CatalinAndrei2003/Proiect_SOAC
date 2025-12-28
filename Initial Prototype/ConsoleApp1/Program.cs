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
        public struct Instructiune
        {
            public string tipInstructiune;
            public int PC;
            public int Destinatie;
             public Instructiune(string tipInstructiune, int PC, int Destinatie)
            {
                this.tipInstructiune = tipInstructiune;
                this.PC = PC;
                this.Destinatie = Destinatie; 
            }
        }
        static void Main(string[] args)
        {
            string filePath = "Date_Intrare/FBUBBLE.TRA";
            List<Instructiune> Instructiuni = new List<Instructiune>();
            foreach (string line in File.ReadLines(filePath))
            {
                string[] lineText = line.Split(' ');
                Instructiune instructiune = new Instructiune(lineText[0], int.Parse(lineText[1]), int.Parse(lineText[2]));
                Instructiuni.Add(instructiune);
            }
            foreach( Instructiune instructiune in Instructiuni)
            {
                Console.WriteLine("{0} {1} {2}",instructiune.tipInstructiune,instructiune.PC,instructiune.Destinatie);
                
            }
        }
    }
}
