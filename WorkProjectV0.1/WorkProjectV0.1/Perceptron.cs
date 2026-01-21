using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkProjectV0._1
{
    public class Perceptron
    {
        public int[] WT; 
        public int[] WNT; 

        public Perceptron(int k)
        {
            WT = new int[k];
            WNT = new int[k];

            
            for (int i = 0; i < k; i++)
            {
                WT[i] = 1;   
                WNT[i] = -1;  
            }
        }
        public void ChangeWeights(int tipSalt)
        {
            for (int i = 0; i < WT.Length; i++)
            {
                if( WT[i] <127 && WT[i] > -128 ) 
                    WT[i] += tipSalt;
                if(WNT[i] < 127 && WNT[i] > -128)
                    WNT[i] += tipSalt;
            }
            
        }
    }
}
