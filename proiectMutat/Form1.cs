using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace jocDeTable
{
    public partial class Form1 : Form
    {
        private TablaDeJoc tablaDeJoc;
        private LogicaJocului logicaJocului;
        private bool mJocPornit = false;
        private Piesa piesaSelectata = null;
        private bool estePiesaSelectata = false;
        private List<int> pozitiiPosibile = new List<int>();

        public Form1()
        {
            InitializeComponent();
            tablaDeJoc = new TablaDeJoc();
            logicaJocului = new LogicaJocului();
        }

        private void buttonZaruri_Click(object sender, EventArgs e)
        {
            mJocPornit = true;
            logicaJocului.AruncaZarurile();
            panelZaruri.Invalidate();
            Console.WriteLine($"Zar1={logicaJocului.Zar1}, Zar2={logicaJocului.Zar2}, miscariRamase={logicaJocului.miscariRamase}");
        }

        private void panelZaruri_Paint(object sender, PaintEventArgs e)
        {
            if (!mJocPornit) return;

            Graphics g = e.Graphics;
            int zarSize = 80;
            int spacing = 30;

            logicaJocului.DeseneazaZaruri(g, logicaJocului.Zar1, 20, 20, zarSize);
            logicaJocului.DeseneazaZaruri(g, logicaJocului.Zar2, 20 + zarSize + spacing, 20, zarSize);
        }

        private void Tabla_Paint(object sender, PaintEventArgs e)
        {
            tablaDeJoc.DeseneazaTabla(e.Graphics);
            tablaDeJoc.DeseneazaPiese(e.Graphics);

            foreach (int poz in pozitiiPosibile)
            {
                int x, y;
                if (poz < 12)
                {
                    x = tablaDeJoc.pieceDiameter / 2 - 5 + (poz * 60);
                    y = tablaDeJoc.pieceDiameter / 2 - 5;
                }
                else
                {
                    int i = 23 - poz;
                    x = tablaDeJoc.pieceDiameter / 2 - 5 + (i * 60);
                    y = 375 + 225 - tablaDeJoc.pieceDiameter / 2 - 5;
                }

                e.Graphics.FillEllipse(Brushes.Green, x + 10, y, 10, 10);
            }
        }

        private bool ToatePieseleAlbInCasa()
        {
            foreach (Piesa p in tablaDeJoc.GetPiese())
            {
                if (p.Culoare == "Alb" && p.Pozitie < 18)
                    return false;
            }
            return true;
        }

        private bool ToatePieseleNegruInCasa()
        {
            foreach (Piesa p in tablaDeJoc.GetPiese())
            {
                if (p.Culoare == "Negru" && p.Pozitie > 5)
                    return false;
            }
            return true;
        }
        private void Tabla_MouseClick(object sender, MouseEventArgs e)
        {
            Piesa piesaAtingere = GetPiesaDeSubCursor(e.X, e.Y);
            if (piesaAtingere != null)
            {
                if (piesaAtingere.Culoare != logicaJocului.GetPlayer())
                {
                    Console.WriteLine("Nu poti muta piesa adversarului!");
                    return;
                }

                bool albInCasa = ToatePieseleAlbInCasa();
                bool negruInCasa = ToatePieseleNegruInCasa();

                int z1 = logicaJocului.Zar1;
                int z2 = logicaJocului.Zar2;

                if (piesaAtingere.Culoare == "Alb" && albInCasa)
                {
                    if (piesaAtingere.Pozitie >= 18 && piesaAtingere.Pozitie <= 23)
                    {
                        if (z1 != 0 && piesaAtingere.Pozitie == (24 - z1))
                        {
                            tablaDeJoc.ScoatePiesa(piesaAtingere);
                            Console.WriteLine($"Piesă Albă scoasă cu zar {z1}");
                            VerificaCastigator();

                            if (logicaJocului.SuntDubla())
                            {
                                logicaJocului.miscariRamase -= 1;
                                if (logicaJocului.miscariRamase <= 0)
                                {
                                    logicaJocului.Zar1 = 0;
                                    logicaJocului.Zar2 = 0;
                                    logicaJocului.SwitchPlayer();
                                    panelZaruri.Invalidate();
                                }
                            }
                            else
                            {
                                logicaJocului.Zar1 = 0;
                                logicaJocului.miscariRamase -= 1;

                                if (logicaJocului.Zar2 == 0 || logicaJocului.miscariRamase <= 0)
                                {
                                    logicaJocului.SwitchPlayer();
                                    panelZaruri.Invalidate();
                                }
                            }

                            Tabla.Invalidate();
                            return;
                        }
                        else if (z2 != 0 && piesaAtingere.Pozitie == (24 - z2))
                        {
                            tablaDeJoc.ScoatePiesa(piesaAtingere);
                            Console.WriteLine($"Piesă Albă scoasă cu zar {z2}");
                            VerificaCastigator();

                            if (logicaJocului.SuntDubla())
                            {
                                logicaJocului.miscariRamase -= 1;
                                if (logicaJocului.miscariRamase <= 0)
                                {
                                    logicaJocului.Zar1 = 0;
                                    logicaJocului.Zar2 = 0;
                                    logicaJocului.SwitchPlayer();
                                    panelZaruri.Invalidate();
                                }
                            }
                            else
                            {
                                logicaJocului.Zar2 = 0;
                                logicaJocului.miscariRamase -= 1;
                                if (logicaJocului.Zar1 == 0 || logicaJocului.miscariRamase <= 0)
                                {
                                    logicaJocului.SwitchPlayer();
                                    panelZaruri.Invalidate();
                                }
                            }

                            Tabla.Invalidate();
                            return;
                        }
                    }
                }
                else if (piesaAtingere.Culoare == "Negru" && negruInCasa)
                {
                    if (piesaAtingere.Pozitie >= 0 && piesaAtingere.Pozitie <= 5)
                    {
                        if (z1 != 0 && piesaAtingere.Pozitie == (z1 - 1))
                        {
                            tablaDeJoc.ScoatePiesa(piesaAtingere);
                            Console.WriteLine($"Piesă Neagră scoasă cu zar {z1}");
                            VerificaCastigator();

                            if (logicaJocului.SuntDubla())
                            {
                                logicaJocului.miscariRamase -= 1;
                                if (logicaJocului.miscariRamase <= 0)
                                {
                                    logicaJocului.Zar1 = 0;
                                    logicaJocului.Zar2 = 0;
                                    logicaJocului.SwitchPlayer();
                                    panelZaruri.Invalidate();
                                }
                            }
                            else
                            {
                                logicaJocului.Zar1 = 0;
                                logicaJocului.miscariRamase -= 1;

                                if (logicaJocului.Zar2 == 0 || logicaJocului.miscariRamase <= 0)
                                {
                                    logicaJocului.SwitchPlayer();
                                    panelZaruri.Invalidate();
                                }
                            }

                            Tabla.Invalidate();
                            return;
                        }
                        else if (z2 != 0 && piesaAtingere.Pozitie == (z2 - 1))
                        {
                            tablaDeJoc.ScoatePiesa(piesaAtingere);
                            Console.WriteLine($"Piesă Neagră scoasă cu zar {z2}");
                            VerificaCastigator();

                            if (logicaJocului.SuntDubla())
                            {
                                logicaJocului.miscariRamase -= 1;
                                if (logicaJocului.miscariRamase <= 0)
                                {
                                    logicaJocului.Zar1 = 0;
                                    logicaJocului.Zar2 = 0;
                                    logicaJocului.SwitchPlayer();
                                    panelZaruri.Invalidate();
                                }
                            }
                            else
                            {
                                logicaJocului.Zar2 = 0;
                                logicaJocului.miscariRamase -= 1;
                                if (logicaJocului.Zar1 == 0 || logicaJocului.miscariRamase <= 0)
                                {
                                    logicaJocului.SwitchPlayer();
                                    panelZaruri.Invalidate();
                                }
                            }

                            Tabla.Invalidate();
                            return;
                        }
                    }
                }

                piesaSelectata = piesaAtingere;
                estePiesaSelectata = true;
                Console.WriteLine($"Selectat: {piesaSelectata.Culoare} la {piesaSelectata.Pozitie}");

                CalculeazaPozitiiPosibile();
                Tabla.Invalidate();
                return;
            }

            if (estePiesaSelectata)
            {
                int triangleIndex = tablaDeJoc.GetTriunghiIndex(e.X, e.Y);

                if (pozitiiPosibile.Contains(triangleIndex))
                {
                    Console.WriteLine($"Mut {piesaSelectata.Culoare} de la {piesaSelectata.Pozitie} la {triangleIndex}");

                    string culoare = piesaSelectata.Culoare;
                    int direction = (culoare == "Alb") ? 1 : -1;
                    int distanta = direction * (triangleIndex - piesaSelectata.Pozitie);

                    bool eDubla = logicaJocului.SuntDubla();
                    int z1 = logicaJocului.Zar1;
                    int z2 = logicaJocului.Zar2;

                    if (eDubla)
                    {
                        if (distanta == z1 && z1 != 0)
                        {
                            if (logicaJocului.miscariRamase > 0)
                            {
                                piesaSelectata.Pozitie = triangleIndex;
                                logicaJocului.miscariRamase -= 1;

                                if (logicaJocului.miscariRamase <= 0)
                                {
                                    logicaJocului.Zar1 = 0;
                                    logicaJocului.Zar2 = 0;
                                    logicaJocului.SwitchPlayer();
                                    panelZaruri.Invalidate();
                                }
                            }
                        }
                    }
                    else
                    {
                        if (distanta == z1 && z1 != 0)
                        {
                            if (logicaJocului.miscariRamase >= 1)
                            {
                                piesaSelectata.Pozitie = triangleIndex;
                                logicaJocului.miscariRamase -= 1;
                                logicaJocului.Zar1 = 0;

                                if (logicaJocului.Zar2 == 0 || logicaJocului.miscariRamase <= 0)
                                {
                                    logicaJocului.SwitchPlayer();
                                    panelZaruri.Invalidate();
                                }
                            }
                        }
                        else if (distanta == z2 && z2 != 0)
                        {
                            if (logicaJocului.miscariRamase >= 1)
                            {
                                piesaSelectata.Pozitie = triangleIndex;
                                logicaJocului.miscariRamase -= 1;
                                logicaJocului.Zar2 = 0;

                                if (logicaJocului.Zar1 == 0 || logicaJocului.miscariRamase <= 0)
                                {
                                    logicaJocului.SwitchPlayer();
                                    panelZaruri.Invalidate();
                                }
                            }
                        }
                    }

                    piesaSelectata = null;
                    estePiesaSelectata = false;
                    pozitiiPosibile.Clear();

                    Tabla.Invalidate();
                    return;
                }
                else
                {
                    piesaSelectata = null;
                    estePiesaSelectata = false;
                    pozitiiPosibile.Clear();
                    Tabla.Invalidate();
                    return;
                }
            }

            piesaSelectata = null;
            estePiesaSelectata = false;
            pozitiiPosibile.Clear();
            Tabla.Invalidate();
        }




        private void VerificaCastigator()
        {
            int albeRamase = 0;
            int negreRamase = 0;

            foreach (Piesa piesa in tablaDeJoc.GetPiese())
            {
                if (piesa.Culoare == "Alb")
                    albeRamase++;
                else if (piesa.Culoare == "Negru")
                    negreRamase++;
            }

            if (albeRamase == 0)
            {
                MessageBox.Show("A câștigat jucătorul cu piesele Albe!",
                                "Sfârșit de joc",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else if (negreRamase == 0)
            {
                MessageBox.Show("A câștigat jucătorul cu piesele Negre!",
                                "Sfârșit de joc",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }


        private bool TriunghiAreOponent(int triangleIndex, string myColor)
        {
            foreach (Piesa p in tablaDeJoc.GetPiese())
            {
                if (p.Pozitie == triangleIndex && p.Culoare != myColor)
                {
                    return true;
                }
            }
            return false;
        }

        

        private void CalculeazaPozitiiPosibile()
        {
            pozitiiPosibile.Clear();
            if (piesaSelectata == null) return;

            int poz = piesaSelectata.Pozitie;

            var (z1, z2) = logicaJocului.GetValorileZarurilor();

            int direction = (piesaSelectata.Culoare == "Alb") ? 1 : -1;

            int p1 = poz + direction * z1;
            int p2 = poz + direction * z2;

            if (EsteMutareValidaInTabla(p1, piesaSelectata.Culoare))
            {
                pozitiiPosibile.Add(p1);
            }
            if (EsteMutareValidaInTabla(p2, piesaSelectata.Culoare))
            {
                pozitiiPosibile.Add(p2);
            }

            Tabla.Invalidate();
        }


        private bool EsteMutareValidaInTabla(int newIndex, string myColor)
        {
            if (newIndex < 0 || newIndex > 23)
                return false;

            if (TriunghiAreOponent(newIndex, myColor))
                return false;

            return true;
        }

        private Piesa GetPiesaDeSubCursor(int x, int y)
        {
            foreach (Piesa piesa in tablaDeJoc.GetPiese())
            {
                int triangleIndex = piesa.Pozitie;
                int pieceX, pieceY;

                if (triangleIndex < 12)
                {
                    pieceX = triangleIndex * 60 + (60 - tablaDeJoc.pieceDiameter) / 2;
                    pieceY = 0 + 0 * (tablaDeJoc.pieceDiameter + 5);
                }
                else
                {
                    int i = 23 - triangleIndex;
                    pieceX = i * 60 + (60 - tablaDeJoc.pieceDiameter) / 2;
                    pieceY = 375 + 225 - (tablaDeJoc.pieceDiameter + 5);
                }

                if (x >= pieceX && x <= pieceX + tablaDeJoc.pieceDiameter &&
                    y >= pieceY && y <= pieceY + tablaDeJoc.pieceDiameter)
                {
                    return piesa;
                }
            }
            return null;
        }

        private void buttonSchimbaJucator_Click(object sender, EventArgs e)
        {
            logicaJocului.SwitchPlayer();
            logicaJocului.Zar1 = 0;
            logicaJocului.Zar2 = 0;
            panelZaruri.Invalidate();
        }

    }
}
