using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase_problem_main
{
    // Расчёт волнового фронта
    public class WaveFront
    {
        private int numberCoefficients;
        public int NumberCoefficients
        {
            get { return numberCoefficients; }
            set
            {
                if (value < 1) throw new ArgumentException();
                numberCoefficients = value;
            }
        }

        private int discretizationPupil;
        public int DiscretizationPupil
        {
            get { return discretizationPupil;}
            set
            {
                if (value < 1) throw new ArgumentException();
                discretizationPupil = value;
            }
        }

        // Класс в котором определяется способ расчёта полиномов
        private readonly FormationPolynomials polinoms = new FormationPolynomials();
        public FormationPolynomials Polinoms
        {
            get { return polinoms; }
            private set { }
        }

        public double[] CoefficientsOfPolynomials { get; set; }
        public double[,] WaveFrontMatrix { get; private set; }

        // Расчёт волнового фронта на основе вектора Полиномов и вектора коэффициентов
        public void CalcWaveFront()
        {
            WaveFrontMatrix = new double[DiscretizationPupil, DiscretizationPupil];

            for (int x = 0; x < DiscretizationPupil; x++)
            {
                for (int y = 0; y < DiscretizationPupil; y++)
                {
                    for (int i = 0; i < NumberCoefficients; i++)
                    {
                        WaveFrontMatrix[x, y] += CoefficientsOfPolynomials[i] * Polinoms.Vector[i, x, y];
                    }
                }
            }
        }
    }
}
