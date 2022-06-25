using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phase_problem_main
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var front = new WaveFront();
            front.DiscretizationPupil = 50;
            front.NumberCoefficients = 10;
            var form = new FormationPolynomials();
            form.FormationZernike(front.NumberCoefficients, front.DiscretizationPupil);
            front.Polinoms = form;
            front.CalcWaveFront();
            var view = front.WaveFrontMatrix;


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
