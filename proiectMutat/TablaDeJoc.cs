using System;
using System.Collections.Generic;
using System.Drawing;

namespace jocDeTable
{
    public class TablaDeJoc
    {
        private List<Piesa> piese;
        private Dictionary<int, int> stackIndexes;

        int triangleWidth = 60;
        int triangleHeight = 225;
        int spaceBetween = 150;
        public int pieceDiameter = 40;
        int pieceMargin = 5;
        int tablaStartX = 0;
        int tablaStartY = 0;
        int lowerTrianglesY = 375;

        public TablaDeJoc()
        {
            piese = new List<Piesa>();
            stackIndexes = new Dictionary<int, int>();

            InitializarePiese();
        }

        public void InitializarePiese()
        {
            for (int i = 0; i < 2; i++)
            {
                piese.Add(new Piesa("Alb", 0));
                piese.Add(new Piesa("Negru", 23));
            }

            for (int i = 0; i < 3; i++)
            {
                piese.Add(new Piesa("Alb", 16));
                piese.Add(new Piesa("Negru", 7));
            }

            for (int i = 0; i < 5; i++)
            {
                piese.Add(new Piesa("Negru", 5));
                piese.Add(new Piesa("Alb", 18));
                piese.Add(new Piesa("Negru", 12));
                piese.Add(new Piesa("Alb", 11));
            }
        }

        public List<Piesa> GetPiese()
        {
            return piese;
        }

        public int GetTriunghiIndex(int x, int y)
        {
            if (x < tablaStartX || x > tablaStartX + 12 * triangleWidth)
                return -1;

            int i = (x - tablaStartX) / triangleWidth;

            if (y >= tablaStartY && y <= tablaStartY + triangleHeight)
            {
                return i;
            }
            else if (y >= lowerTrianglesY && y <= lowerTrianglesY + triangleHeight)
            {
                return 23 - i;
            }
            return -1;
        }

        public void DeseneazaTabla(Graphics g)
        {
            Brush lightBrush = Brushes.BurlyWood;
            Brush darkBrush = Brushes.SaddleBrown;

            for (int i = 0; i < 12; i++)
            {
                Brush brush = (i % 2 == 0) ? lightBrush : darkBrush;
                Point[] triangle =
                {
                    new Point(tablaStartX + i * triangleWidth, tablaStartY),
                    new Point(tablaStartX + (i + 1) * triangleWidth, tablaStartY),
                    new Point(tablaStartX + i * triangleWidth + triangleWidth / 2, tablaStartY + triangleHeight)
                };
                g.FillPolygon(brush, triangle);
            }

            int lowerY = tablaStartY + triangleHeight + spaceBetween;
            for (int i = 0; i < 12; i++)
            {
                Brush brush = (i % 2 == 0) ? lightBrush : darkBrush;
                Point[] triangle =
                {
                    new Point(tablaStartX + i * triangleWidth, lowerY + triangleHeight),
                    new Point(tablaStartX + (i + 1) * triangleWidth, lowerY + triangleHeight),
                    new Point(tablaStartX + i * triangleWidth + triangleWidth / 2, lowerY)
                };
                g.FillPolygon(brush, triangle);
            }
            
            
        }

        public void ScoatePiesa(Piesa p)
        {
            piese.Remove(p);
        }
        
        public void DeseneazaPiese(Graphics g)
        {
            Dictionary<int, int> localStacks = new Dictionary<int, int>();

            foreach (var piesa in piese)
            {
                int triangleIndex = piesa.Pozitie;

                if (!localStacks.ContainsKey(triangleIndex))
                    localStacks[triangleIndex] = 0;

                int stackIndex = localStacks[triangleIndex];

                int x, y;
                if (triangleIndex < 12)
                {
                    x = tablaStartX + triangleIndex * triangleWidth + (triangleWidth - pieceDiameter) / 2;
                    y = tablaStartY + stackIndex * (pieceDiameter + pieceMargin);
                }
                else
                {
                    int i = 23 - triangleIndex;
                    x = tablaStartX + i * triangleWidth + (triangleWidth - pieceDiameter) / 2;
                    y = lowerTrianglesY + triangleHeight - (stackIndex + 1) * (pieceDiameter + pieceMargin);
                }

                Brush pieceBrush = (piesa.Culoare == "Alb") ? Brushes.White : Brushes.Black;
                g.FillEllipse(pieceBrush, x, y, pieceDiameter, pieceDiameter);
                g.DrawEllipse(Pens.Black, x, y, pieceDiameter, pieceDiameter);

                localStacks[triangleIndex]++;
            }
        }
    }
}
