using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WorkProjectV0._1
{
    public partial class Form1 : Form
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
        List<Instructiune> Instructiuni = new List<Instructiune>();
        

        public Form1()
        {
            InitializeComponent();
            string filePath = "Date_Intrare/FBUBBLE.TRA";
            foreach (string line in File.ReadLines(filePath))
            {
                string[] lineText = line.Split(' ');
                Instructiune instructiune = new Instructiune(lineText[0],
                                                            int.Parse(lineText[1]),
                                                            int.Parse(lineText[2]));
                Instructiuni.Add(instructiune);
            }
            foreach (Instructiune instructiune in Instructiuni)
            {
                Console.WriteLine("{0} {1} {2}", instructiune.tipInstructiune, instructiune.PC, instructiune.Destinatie);
            }
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach(Instructiune instructiune in Instructiuni)
            {
                int PC = instructiune.PC;
                string tipInstructiune = instructiune.tipInstructiune;
                int Destinatie = instructiune.Destinatie;
                int index = PC % (int)NrPerceptroni.Value;
            }
        }
    }
}
