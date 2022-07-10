using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using MathNet.Numerics;

namespace Phase_problem_main
{
    // Класс определяющий способ формирования полиномов
    public class FormationPolynomials
    {
        public double[,,] Vector { get; private set; }

        private double[,] radiusVector;
        public double[,] RadiusVector
        {
            get { return radiusVector; }
            set
            {
                if (value == null ||
                    value.GetLength(0) != value.GetLength(1) ||
                    value.GetLength(0) == 0) throw new ArgumentException();
                radiusVector = value;
            }
        }

        // Формирование вектора полиномов Цернике
        public void FormationZernike(int NumberCoefficients, int DiscretizationPupil, BackgroundWorker worker, DoWorkEventArgs e)
        {
            Vector = new double[NumberCoefficients, DiscretizationPupil, DiscretizationPupil];
            RadiusVector = new double[DiscretizationPupil, DiscretizationPupil];

            var xAxis = new double[DiscretizationPupil];
            var yAxis = new double[DiscretizationPupil];

            var angle = new double[DiscretizationPupil, DiscretizationPupil];

            for (int x = 0; x < DiscretizationPupil; x++)
            {
                // Сообщение о прогрессе выполения
                worker.ReportProgress((int)(100 * (x / (double)DiscretizationPupil)));

                // Проверка остановки выполения
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                for (int y = 0; y < DiscretizationPupil; y++)
                {
                    // Нормировка диапазона координат выходного зрачка от -1 до 1
                    xAxis[x] = -1.0 + 2.0 * x / (DiscretizationPupil - 1);
                    yAxis[y] = -1.0 + 2.0 * y / (DiscretizationPupil - 1);

                    // Расчёт радиус вектора для перехода из полярной в декатову систему координат
                    RadiusVector[x, y] = Math.Sqrt(xAxis[x] * xAxis[x] + yAxis[y] * yAxis[y]);

                    // За пределами еденичного круга волновой фронт равен нулю
                    if (RadiusVector[x, y] <= 1.0)
                    {
                        // Расчёт полярного угла для перехода из полярной в декатову систему координат
                        angle[x, y] = Math.Atan2(yAxis[y], xAxis[x]);

                        // Счётчик числа полиномов
                        int l = 0;

                        // Расчёт полиномов Цернике по формулам полярной системы координат
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
