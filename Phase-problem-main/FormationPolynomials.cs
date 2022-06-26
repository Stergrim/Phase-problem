using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathNet.Numerics;

namespace Phase_problem_main
{
    public class FormationPolynomials
    {
        public double[,,] Vector { get; set; }
        public double[,] RadiusVector { get; set; }

        public void FormationZernike(int NumberCoefficients, int DiscretizationPupil)
        {
            Vector = new double[NumberCoefficients, DiscretizationPupil, DiscretizationPupil];
            RadiusVector = new double[DiscretizationPupil, DiscretizationPupil];

            var xAxis = new double[DiscretizationPupil];
            var yAxis = new double[DiscretizationPupil];

            var angle = new double[DiscretizationPupil, DiscretizationPupil];

            for (int x = 0; x < DiscretizationPupil; x++)
            {
                for (int y = 0; y < DiscretizationPupil; y++)
                {
                    xAxis[x] = -1.0 + 2.0 * x / (DiscretizationPupil-1);
                    yAxis[y] = -1.0 + 2.0 * y / (DiscretizationPupil-1);

                    // Перевод полярной системы координат в декартову
                    RadiusVector[x, y] = Math.Sqrt(xAxis[x] * xAxis[x] + yAxis[y] * yAxis[y]);

                    if (RadiusVector[x, y] <= 1)
                    {
                        angle[x, y] = Math.Atan2(yAxis[y], xAxis[x]);

                        // Счётчик числа полиномов
                        int l = 0;

                        for (int n = 1; n <= NumberCoefficients; n++)
                        {
                            for (int m = -n; m <= n; m += 2)
                            {
                                if (m < 0)
                                {
                                    for (int s = 0; s <= (n + m) / 2; s++)
                                    {
                                        Vector[l, x, y] += Math.Sqrt(2 * (n + 1)) * (Math.Pow(-1, s) *
                                            SpecialFunctions.Factorial(n - s) / (SpecialFunctions.Factorial(s) *
                                            SpecialFunctions.Factorial((n - m) / 2 - s) *
                                            SpecialFunctions.Factorial((n + m) / 2 - s))) * Math.Sin(-m * angle[x, y]) *
                                            Math.Pow(RadiusVector[x, y], n - 2 * s);
                                    }
                                }
                                else if (m == 0)
                                {
                                    for (int s = 0; s <= n / 2; s++)
                                    {
                                        Vector[l, x, y] += Math.Sqrt(n + 1) * (Math.Pow(-1, s) *
                                        SpecialFunctions.Factorial(n - s) / (SpecialFunctions.Factorial(s) *
                                        SpecialFunctions.Factorial(n / 2 - s) *
                                        SpecialFunctions.Factorial(n / 2 - s))) *
                                        Math.Pow(RadiusVector[x, y], n - 2 * s);
                                    }
                                }
                                else if (m > 0)
                                {
                                    for (int s = 0; s <= (n - m) / 2; s++)
                                    {
                                        Vector[l, x, y] += Math.Sqrt(2 * (n + 1)) * (Math.Pow(-1, s) *
                                        SpecialFunctions.Factorial(n - s) / (SpecialFunctions.Factorial(s) *
                                        SpecialFunctions.Factorial((n - m) / 2 - s) *
                                        SpecialFunctions.Factorial((n + m) / 2 - s))) * Math.Cos(m * angle[x, y]) *
                                        Math.Pow(RadiusVector[x, y], n - 2 * s);
                                    }
                                }

                                l++;
                                if (l >= NumberCoefficients) break;
                            }
                            if (l >= NumberCoefficients) break;
                        }
                    }
                }
            }
        }

    }



}
