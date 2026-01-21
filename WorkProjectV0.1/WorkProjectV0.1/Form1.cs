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
        int totalSalturi;
        int totalTakenReale;
        int totalNotTakenReale;
        int predictiiTakenCorecte;
        int predictiiNotTakenCorecte;
        public Form1()
        {
            InitializeComponent();
        }
        private void StartBtn_MouseClick(object sender, MouseEventArgs e)
        {
            rtbStatistici.Clear();
            string folderPath = @"Date_Intrare";
            var allFiles = Directory.EnumerateFiles(folderPath, "*.TRA");
            foreach ( var file in allFiles) 
            {
                IncarcaIntructiuni(file);
                RunSimulation();
                AfiseazaStatisticiPeInterfata(totalSalturi,
                    totalTakenReale,
                    totalNotTakenReale,
                    predictiiTakenCorecte,
                    predictiiNotTakenCorecte,
                    file);
            }
        }


        public void IncarcaIntructiuni(string filePath)
        {
            Instructiuni.Clear();

            foreach (string line in File.ReadLines(filePath))
            {
                string[] lineText = line.Split(' ');
                if (lineText.Length >= 3)
                {
                    Instructiune instr = new Instructiune(
                        lineText[0],
                        int.Parse(lineText[1]),
                        int.Parse(lineText[2])
                    );
                    Instructiuni.Add(instr);
                }
            }
        }
        public void RunSimulation()
        {
            totalSalturi = 0;
            totalTakenReale = 0;
            totalNotTakenReale = 0;
            predictiiTakenCorecte = 0;
            predictiiNotTakenCorecte = 0;

            int nrPerceptroni = (int)NrPerceptroni.Value;
            int nrWeights = (int)this.NrBitiHG.Value;
            int nrBitiHR = nrWeights;

            InitializeTableOfPerceptrons(nrPerceptroni, nrWeights);

            InitializeHR(nrBitiHR);

            foreach (Instructiune instructiune in Instructiuni)
            {
                totalSalturi += 1;
                //make the basic initializations
                int PC = instructiune.PC;
                string tipInstructiune = instructiune.tipInstructiune;
                int Destinatie = instructiune.Destinatie;

                Perceptron perceptronAles = ChoosePerceptron(PC, nrPerceptroni);

                int suma = CalculateSumOfWeights(perceptronAles, nrBitiHR);

                int predictie = MakePrediction(suma);

                int tipSaltReal = FindTheTypeOfTheCurrentJump(tipInstructiune);

                VerifyIfThePredictionWasCorrect(
                    predictie,
                    tipSaltReal,
                    ref totalTakenReale,
                    ref totalNotTakenReale,
                    ref predictiiTakenCorecte,
                    ref predictiiNotTakenCorecte);

                perceptronAles.ChangeWeights(tipSaltReal);

                RotateBitsOfHRAndPutTheNewJump(tipSaltReal);

            }

        }
        private void AfiseazaStatisticiPeInterfata(
            int total,
            int tReal,
            int ntReal,
            int tCorect,
            int ntCorect,
            string filePath)
        {
            double acurateteTotala = ((double)(tCorect + ntCorect) / total) * 100;
            double procentTakenCorect = (tReal > 0) ? ((double)tCorect / tReal) * 100 : 0;
            double procentNotTakenCorect = (ntReal > 0) ? ((double)ntCorect / ntReal) * 100 : 0;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"======= REZULTATE: {filePath} =======");
            sb.AppendLine($"Total salturi: {total}");
            sb.AppendLine($"TAKEN Reale: {tReal} | Prezise Corect: {tCorect} ({procentTakenCorect:F2}%)");
            sb.AppendLine($"NOT-TAKEN Reale: {ntReal} | Prezise Corect: {ntCorect} ({procentNotTakenCorect:F2}%)");
            sb.AppendLine($"ACURATETE TOTALA: {acurateteTotala:F2}%");
            sb.AppendLine("==========================================\n");

            // Afisăm în RichTextBox
            rtbStatistici.AppendText(sb.ToString());

            // Scroll automat la finalul textului
            rtbStatistici.ScrollToCaret();
        }


        public void InitializeTableOfPerceptrons(int nrPerceptroni, int nrWeights)
        {
            tabelPerceptroni = new Perceptron[nrPerceptroni];
            for (int i = 0; i < nrPerceptroni; i++)
            {
                tabelPerceptroni[i] = new Perceptron(nrWeights);
            }
        }
        public void InitializeHR(int nrBitiHR)
        {
            HR = new int[nrBitiHR];
            for (int i = 0; i < HR.Length; i++)
            {
                HR[i] = -1;
            }
        }
        public Perceptron ChoosePerceptron(int PC, int nrPerceptroni)
        {
            int index = PC % nrPerceptroni;
            return tabelPerceptroni[index];
        }
        public int CalculateSumOfWeights(Perceptron perceptronAles, int nrBitiHR)
        {
            int suma = 0;
            for (int i = 0; i < nrBitiHR; i++)
            {
                if (HR[i] == 1)
                    suma += perceptronAles.WT[i];
                else
                    suma += perceptronAles.WNT[i];
            }
            return suma;
        }
        public int MakePrediction(int suma)
        {
            if (suma >= 0)
                return 1;
            else
                return -1;
        }
        public int FindTheTypeOfTheCurrentJump(string tipInstructiune)
        {
            return tipInstructiune[0] == 'N' ? -1 : 1;
        }
        public void VerifyIfThePredictionWasCorrect(
            int predictie,
            int tipSaltReal,
            ref int totalTakenReale,
            ref int totalNotTakenReale,
            ref int predictiiTakenCorecte,
            ref int predictiiNotTakenCorecte)
        {
            if (tipSaltReal == 1)
            {
                totalTakenReale += 1;
                if (predictie == 1) predictiiTakenCorecte += 1;
            }
            else
            {
                totalNotTakenReale += 1;
                if (predictie == -1) predictiiNotTakenCorecte += 1;
            }
        }
        public void RotateBitsOfHRAndPutTheNewJump(int tipSaltReal)
        {
            for (int i = 0; i < HR.Length - 1; i++)
            {
                HR[i] = HR[i + 1];
            }
            HR[HR.Length - 1] = tipSaltReal;
        }


    }
}
