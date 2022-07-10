﻿using System;
using cPoint3D = Plot3D.Graph3D.cPoint3D;
using MyResult = Phase_problem_main.MainForm.MyResult;

namespace Phase_problem_main
{
    public static class DefaultSurface
    {
        public static MyResult Surface()
        {
            int[,] devVlad = new int[,]
            {
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,15,15,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,53,0,164,93,56,142,39,45,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,65,198,166,244,243,198,206,110,191,71,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,141,65,243,233,245,243,239,236,231,214,217,145,28,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,141,254,243,248,245,243,239,236,232,227,223,219,214,161,62,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,141,254,251,249,245,243,239,235,232,228,223,218,214,209,205,145,45,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,141,254,252,248,246,243,239,235,231,228,223,219,214,210,204,200,186,51,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,141,254,251,249,245,243,239,235,231,227,223,219,215,210,204,199,195,189,89,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,141,254,252,248,246,242,239,235,231,227,223,178,212,210,205,199,194,189,184,176,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,141,254,251,249,245,243,239,235,183,227,85,149,89,184,205,200,194,189,184,179,173,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,141,254,251,248,245,243,239,236,183,20,87,0,0,23,93,176,194,189,184,178,173,167,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,141,254,252,248,245,243,239,235,184,20,0,0,0,0,0,0,68,151,184,178,172,167,161,0,0,30,0,15,31,6,0,0,2,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,141,254,251,249,245,243,239,235,183,20,0,0,0,0,0,0,0,20,120,178,172,167,161,156,68,31,129,82,58,94,86,48,17,10,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,141,254,252,249,246,243,239,235,183,20,0,0,0,0,0,0,0,0,0,116,172,167,162,156,150,128,129,133,126,122,109,109,100,86,59,19,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,141,254,252,249,246,242,239,235,231,20,0,0,0,0,0,0,0,0,0,0,154,167,162,156,150,144,138,133,127,121,115,110,104,97,93,87,57,16,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,254,251,249,245,243,238,235,231,227,125,35,1,0,0,0,0,0,0,0,29,167,161,156,150,144,139,133,127,121,116,109,104,98,92,87,81,69,41,8,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,252,248,246,243,239,235,231,227,223,203,107,10,0,0,0,0,0,0,0,90,162,156,150,144,139,133,127,121,116,110,104,98,92,87,81,75,70,65,44,14,0,0,0,0,0,0 },
                { 0,0,0,0,0,146,226,243,239,235,232,227,223,218,214,181,99,20,0,0,0,0,0,65,162,156,150,144,139,133,127,122,116,110,104,98,92,87,81,75,70,65,59,52,24,0,0,0,0,0,0 },
                { 0,0,0,0,0,58,177,239,235,231,228,223,218,214,210,204,200,109,25,0,0,0,65,161,156,150,144,139,133,127,120,115,88,86,98,83,87,81,75,70,65,60,55,51,23,1,0,0,0,0,0 },
                { 0,0,0,0,0,0,38,143,213,227,223,219,214,209,204,199,195,160,83,0,0,65,162,156,150,145,139,133,127,114,94,60,51,12,41,50,81,75,70,66,60,55,50,46,34,2,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,39,149,223,219,214,209,204,199,194,189,184,177,97,65,162,157,150,144,139,133,127,115,29,46,0,7,0,0,0,34,59,65,59,55,51,45,41,37,5,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,4,52,150,210,209,204,200,195,189,184,178,173,149,162,156,150,144,139,133,127,114,28,0,0,0,0,0,0,0,9,35,60,55,50,46,41,37,33,24,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,8,125,192,200,195,189,184,178,173,167,162,156,150,144,139,133,127,115,29,0,0,0,0,0,0,0,0,0,6,55,50,45,41,37,33,28,25,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,2,51,146,194,189,184,178,172,168,161,157,150,144,139,133,127,114,28,0,0,0,0,0,0,0,0,0,0,0,50,45,40,37,33,28,24,18,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,22,112,168,178,173,167,162,156,151,144,139,133,127,119,28,0,0,0,0,0,0,0,0,0,0,0,0,45,41,36,33,28,25,20,3,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,38,124,173,168,162,156,150,145,139,133,127,121,93,17,0,0,0,0,0,0,0,0,0,0,0,0,41,37,32,28,24,21,17,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,1,37,109,154,156,150,144,139,133,127,121,116,95,47,0,0,0,0,0,0,0,0,0,0,0,0,36,33,28,24,20,17,11,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,95,145,144,139,132,127,121,115,110,104,90,50,13,0,0,0,0,0,0,0,0,0,12,32,28,25,20,16,14,5,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,37,105,139,133,126,121,115,109,105,98,92,82,41,5,0,0,0,0,0,0,0,12,32,28,24,21,16,14,8,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,78,117,121,116,110,104,99,93,87,81,65,33,6,0,0,0,0,0,12,32,28,24,20,17,14,11,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,29,89,115,110,104,98,93,88,81,76,71,65,34,8,0,0,0,12,33,28,25,20,16,14,11,9,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,21,68,97,98,92,87,82,75,71,65,60,47,22,0,0,12,33,28,25,21,17,14,11,8,2,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,63,92,87,81,76,70,66,60,55,50,44,22,12,33,28,24,21,17,14,11,8,2,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,22,61,82,76,71,65,60,55,51,45,40,32,33,28,25,20,17,14,11,8,2,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,45,66,65,60,55,51,46,41,36,33,28,24,21,16,14,11,9,2,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,18,47,60,55,50,46,41,37,32,28,24,20,17,14,11,8,2,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,33,46,45,41,36,33,28,24,20,16,14,11,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,10,31,41,37,32,28,25,20,17,14,11,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,9,24,32,28,24,21,16,14,11,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,17,24,20,17,14,11,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,6,15,17,14,11,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,9,8,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            };

            double[,] visualArea = new double[51, 51];

            double xAxis;
            double yAxis;

            cPoint3D[,] IPoints3D = new cPoint3D[devVlad.GetLength(0), devVlad.GetLength(1)];
            for (int X = 0; X < devVlad.GetLength(0); X++)
            {
                for (int Y = 0; Y < devVlad.GetLength(1); Y++)
                {
                    IPoints3D[X, Y] = new cPoint3D(X, Y, devVlad[X, Y]);
                    xAxis = -1.0 + 2.0 * X / (51 - 1);
                    yAxis = -1.0 + 2.0 * Y / (51 - 1);
                    visualArea[X, Y] = Math.Sqrt(xAxis * xAxis + yAxis * yAxis);
                }
            }

            return new MyResult
            {
                i_Points3DCalc = IPoints3D,
                RadiusVector = visualArea
            };
        }
    }
}
