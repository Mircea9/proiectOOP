using System;
using System.Collections.Generic;
using System.Drawing;

namespace jocDeTable
{
    public class LogicaJocului
    {
        public int Zar1;
        public int Zar2;
        public int miscariRamase;
        
        private string currentPlayer = "Alb";

        public LogicaJocului()
        {
            Zar1 = 0;
            Zar2 = 0;
            miscariRamase = 0;
            
        }

        public void AruncaZarurile()
        {
            Random rand = new Random();
            Zar1 = rand.Next(1, 7);
            Zar2 = rand.Next(1, 7);

            if (SuntDubla())
            {
                miscariRamase = 4;
            }
            else
            {
                miscariRamase = 2;
            }
        }

        public void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == "Alb") ? "Negru" : "Alb";
            Console.WriteLine("Este randul jucatorului: " + currentPlayer);
        }

        public (int, int) GetValorileZarurilor()
        {
            return (Zar1, Zar2);
        }

        public string GetPlayer()
        {
            return currentPlayer;
        }

        public bool SuntDubla()
        {
            return Zar1 == Zar2;
        }

        public void DeseneazaZaruri(Graphics g, int valoare, int x, int y, int size)
        {
            g.FillRectangle(Brushes.White, x, y, size, size);
            g.DrawRectangle(Pens.Black, x, y, size, size);

            int dotSize = size / 6;
            int padding = size / 8;

            int centerX = x + size / 2 - dotSize / 2;
            int centerY = y + size / 2 - dotSize / 2;

            int topLeftX = x + padding;
            int topLeftY = y + padding;

            int topRightX = x + size - padding - dotSize;
            int topRightY = y + padding;

            int bottomLeftX = x + padding;
            int bottomLeftY = y + size - padding - dotSize;

            int bottomRightX = x + size - padding - dotSize;
            int bottomRightY = y + size - padding - dotSize;

            int middleLeftX = x + padding;
            int middleLeftY = y + size / 2 - dotSize / 2;

            int middleRightX = x + size - padding - dotSize;
            int middleRightY = y + size / 2 - dotSize / 2;

            switch (valoare)
            {
                case 1:
                    g.FillEllipse(Brushes.Black, centerX, centerY, dotSize, dotSize);
                    break;
                case 2:
                    g.FillEllipse(Brushes.Black, topLeftX, topLeftY, dotSize, dotSize);
                    g.FillEllipse(Brushes.Black, bottomRightX, bottomRightY, dotSize, dotSize);
                    break;
                case 3:
                    g.FillEllipse(Brushes.Black, topLeftX, topLeftY, dotSize, dotSize);
                    g.FillEllipse(Brushes.Black, centerX, centerY, dotSize, dotSize);
                    g.FillEllipse(Brushes.Black, bottomRightX, bottomRightY, dotSize, dotSize);
                    break;
                case 4:
                    g.FillEllipse(Brushes.Black, topLeftX, topLeftY, dotSize, dotSize);
                    g.FillEllipse(Brushes.Black, topRightX, topRightY, dotSize, dotSize);
                    g.FillEllipse(Brushes.Black, bottomLeftX, bottomLeftY, dotSize, dotSize);
                    g.FillEllipse(Brushes.Black, bottomRightX, bottomRightY, dotSize, dotSize);
                    break;
                case 5:
                    g.FillEllipse(Brushes.Black, topLeftX, topLeftY, dotSize, dotSize);
                    g.FillEllipse(Brushes.Black, topRightX, topRightY, dotSize, dotSize);
                    g.FillEllipse(Brushes.Black, centerX, centerY, dotSize, dotSize);
                    g.FillEllipse(Brushes.Black, bottomLeftX, bottomLeftY, dotSize, dotSize);
                    g.FillEllipse(Brushes.Black, bottomRightX, bottomRightY, dotSize, dotSize);
                    break;
                case 6:
                    g.FillEllipse(Brushes.Black, topLeftX, topLeftY, dotSize, dotSize);
                    g.FillEllipse(Brushes.Black, topRightX, topRightY, dotSize, dotSize);
                    g.FillEllipse(Brushes.Black, middleLeftX, middleLeftY, dotSize, dotSize);
                    g.FillEllipse(Brushes.Black, middleRightX, middleRightY, dotSize, dotSize);
                    g.FillEllipse(Brushes.Black, bottomLeftX, bottomLeftY, dotSize, dotSize);
                    g.FillEllipse(Brushes.Black, bottomRightX, bottomRightY, dotSize, dotSize);
                    break;
            }
        }
    }
}
