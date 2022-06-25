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
            Vector = new double[NumberCoefficients, DiscretizationPupil+1, DiscretizationPupil+1];
            RadiusVector = new double[DiscretizationPupil+1, DiscretizationPupil+1];

            var xAxis = new double[DiscretizationPupil+1];
            var yAxis = new double[DiscretizationPupil+1];

            var angle = new double[DiscretizationPupil+1, DiscretizationPupil+1];

            for (int x = 0; x <= DiscretizationPupil; x++)
            {
                for (int y = 0; y <= DiscretizationPupil; y++)
                {
                    xAxis[x] = -1.0 + 2.0 * x / DiscretizationPupil;
                    yAxis[y] = -1.0 + 2.0 * y / DiscretizationPupil;

                    // Перевод полярной системы координат в декартову
                    RadiusVector[x, y] = Math.Sqrt(xAxis[x] * xAxis[x] + yAxis[y] * yAxis[y]);

                    if (RadiusVector[x, y] <= 1)
                    {
                        if ((xAxis[x] > 0 && yAxis[y] >= 0) || (xAxis[x] > 0 && yAxis[y] <= 0))
                            angle[x, y] = Math.Atan2(yAxis[y], xAxis[x]);
                        else if ((xAxis[x] < 0 && yAxis[y] >= 0) || (xAxis[x] < 0 && yAxis[y] <= 0))
                            angle[x, y] = Math.PI + Math.Atan2(yAxis[y], xAxis[x]);
                        else if ((xAxis[x] == 0 && xAxis[x - 1] > 0 && yAxis[y] > 0) || (xAxis[x] == 0 && xAxis[x - 1] < 0 && yAxis[y] < 0))
                            angle[x, y] = -Math.PI / 2.0;
                        else if ((xAxis[x] == 0 && xAxis[x - 1] < 0 && yAxis[y] > 0) || (xAxis[x] == 0 && xAxis[x - 1] > 0 && yAxis[y] < 0))
                            angle[x, y] = Math.PI / 2.0;

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
