using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase_problem_main
{
    public class WaveFront
    {
        public int NumberCoefficients { get; set; }
        public FormationPolynomials Polinoms { get; set; }
        public int DiscretizationPupil { get; set; }
        public double[] CoefficientsPolynomials { get; set; }

        public double[,] WaveFrontMatrix { get; set; }

        public void CalcWaveFront()
        {
            WaveFrontMatrix = new double[DiscretizationPupil+1, DiscretizationPupil+1];
            CoefficientsPolynomials = new double[NumberCoefficients];

            Random rnd = new Random();
            for (int i = 0; i < NumberCoefficients; i++)
            {
                CoefficientsPolynomials[i] = (double)rnd.Next(-10,11)/10;
            }

            for (int x = 0; x <= DiscretizationPupil; x++)
            {
                for (int y = 0; y <= DiscretizationPupil; y++)
                {
                    for (int i = 0; i < NumberCoefficients; i++)
                    {
                        WaveFrontMatrix[x, y] += CoefficientsPolynomials[i] * Polinoms.Vector[i, x, y];
                    }
                }
            }

        }


    }
}
