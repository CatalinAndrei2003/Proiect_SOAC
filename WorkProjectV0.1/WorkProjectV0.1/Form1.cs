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
        Perceptron[] tabelPerceptroni;
        int[] HR;
        public Form1()
        {
            InitializeComponent();
            string filePath = "Date_Intrare/FPERM.TRA";
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
        private void AfiseazaStatistici(int total, int tReal, int ntReal, int tCorect, int ntCorect)
        {
            double acurateteTotala = ((double)(tCorect + ntCorect) / total) * 100;
            double procentTakenCorect = (tReal > 0) ? ((double)tCorect / tReal) * 100 : 0;
            double procentNotTakenCorect = (ntReal > 0) ? ((double)ntCorect / ntReal) * 100 : 0;

            Console.WriteLine("\n======= REZULTATE SIMULARE =======");
            Console.WriteLine($"Numarul total de salturi: {total}");
            Console.WriteLine($"Numarul total de salturi TAKEN: {tReal}");
            Console.WriteLine($"Numarul de salturi TAKEN prezise corect: {tCorect} ({procentTakenCorect:F2}%)");
            Console.WriteLine($"Numarul total de salturi NOT-TAKEN: {ntReal}");
            Console.WriteLine($"Numarul de salturi NOT-TAKEN prezise corect: {ntCorect} ({procentNotTakenCorect:F2}%)");
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"ACURATETE TOTALA SIMULATOR: {acurateteTotala:F2}%");
            Console.WriteLine("==================================\n");
        }
        private void StartBtn_MouseClick(object sender, MouseEventArgs e)
        {
            int totalSalturi = 0;
            int totalTakenReale = 0;
            int totalNotTakenReale = 0;
            int predictiiTakenCorecte = 0;    
            int predictiiNotTakenCorecte = 0;

            int nrPerceptroni = (int)NrPerceptroni.Value;
            int nrWeights = (int)this.NrBitiHG.Value;
            int nrBitiHR = nrWeights;

            tabelPerceptroni = new Perceptron[nrPerceptroni];
            for (int i = 0; i < nrPerceptroni; i++)
            {
                tabelPerceptroni[i] = new Perceptron(nrWeights);
            }

            HR = new int[nrBitiHR];
            for (int i = 0; i < HR.Length; i++)
            {
                HR[i] = -1;
            }
            foreach (Instructiune instructiune in Instructiuni)
            {
                totalSalturi += 1;
                int PC = instructiune.PC;
                string tipInstructiune = instructiune.tipInstructiune;
                int Destinatie = instructiune.Destinatie;

                int index = PC % nrPerceptroni;
                Perceptron perceptronAles = tabelPerceptroni[index];
                int suma = 0;
                for (int i = 0; i < nrBitiHR; i++)
                {
                    if (HR[i] == 1)
                        suma += perceptronAles.WT[i];
                    else
                        suma += perceptronAles.WNT[i];
                }
                int predictie;
                if (suma >= 0)
                    predictie = 1;
                else
                    predictie = -1;

                int tipSaltReal = (tipInstructiune[0] == 'N') ? -1 : 1;

                if (tipSaltReal == 1)
                {
                    totalTakenReale++;
                    if (predictie == 1) predictiiTakenCorecte += 1;
                }
                else
                {
                    totalNotTakenReale++;
                    if (predictie == -1) predictiiNotTakenCorecte += 1;
                }

                // --- ACTUALIZARE (Exact cum ai facut tu) ---
                perceptronAles.ChangeWeights(tipSaltReal);

                for (int i = 0; i < HR.Length-1; i++)
                {
                    HR[i] = HR[i + 1];
                }
                HR[HR.Length - 1] = tipSaltReal;
                
            }
            AfiseazaStatistici(totalSalturi, totalTakenReale, totalNotTakenReale, predictiiTakenCorecte, predictiiNotTakenCorecte);
        }
    }
}
