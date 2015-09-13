using System;
using System.Collections;
using System.Collections.Generic;

namespace Taquin
{
    public class Taquin
    {
        //--- Variables d'instance
        private int dimension1;
        private int dimension2;
        private int ligneVide;
        private int colonneVide;
        private int[,] plateau;

        //--- Constructeurs
        public Taquin()
            : this(3)
        {
        }

        public Taquin(int dimension)
            : this(dimension, dimension)
        {
        }

        public Taquin(int dim1, int dim2)
        {
            plateau = new int[dim1, dim2];
            this.dimension1 = dim1;
            this.dimension2 = dim2;
            this.NouveauJeu();
        }

        public void NouveauJeuTest()
        {
            ligneVide = 2;
            colonneVide = 1;
            plateau = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 0, 8 } };
        }

        //--- Méthodes d'interface
        public override string ToString()
        {
            // développer l'objet comme s'il était destiné à quelqu'un d'autre, 
            // rendre indépendant de l'interface utilisateur (console,Windows Form, Web).
            // chaque méthode doit rendre un service et un seul.
            string plateauTaquin = "";
            for (int i = 0; i < 3; i = i + 1)
            {
                for (int j = 0; j < 3; j = j + 1)
                {
                    plateauTaquin = plateauTaquin + String.Format(plateau[i, j].ToString());
                }
                plateauTaquin = plateauTaquin + "\n";
            }
            return plateauTaquin;
        }

        public bool Jouer(int unCoup)
        {
            bool coupJoué = false;

            switch (unCoup)
            {
                // down
                case 2:
                    if ((ligneVide - 1) > -1)
                    {
                        plateau[ligneVide, colonneVide] = plateau[ligneVide - 1, colonneVide];
                        plateau[ligneVide - 1, colonneVide] = 0;
                        ligneVide = ligneVide - 1;
                        coupJoué = true;
                    }
                    break;
                // left
                case 4:
                    if (colonneVide < (this.plateau.GetLength(1) - 1))
                    {
                        plateau[ligneVide, colonneVide] = plateau[ligneVide, colonneVide + 1];
                        plateau[ligneVide, colonneVide + 1] = 0;
                        colonneVide = colonneVide + 1;
                        coupJoué = true;
                    }
                    break;
                // right
                case 6:
                    if ((colonneVide - 1) > -1)
                    {
                        plateau[ligneVide, colonneVide] = plateau[ligneVide, colonneVide - 1];
                        plateau[ligneVide, colonneVide - 1] = 0;
                        colonneVide = colonneVide - 1;
                        coupJoué = true;
                    }

                    break;
                // up    
                case 8:
                    if ((ligneVide + 1) < (this.plateau.GetLength(0)))
                    {
                        plateau[ligneVide, colonneVide] = plateau[ligneVide + 1, colonneVide];
                        plateau[ligneVide + 1, colonneVide] = 0;
                        ligneVide = ligneVide + 1;
                        coupJoué = true;
                    }
                    break;
                default:
                    coupJoué = false;
                    break;
            }
            return coupJoué;
        }

        public bool Gagné()
        {
            bool gagné = true;
            int valeurAttendue = 1;
            for (int ligne = 0; ligne < plateau.GetLength(0) && gagné == true; ligne++)
                for (int colonne = 0; colonne < plateau.GetLength(1) && gagné == true; colonne++)
                {
                    if (plateau[ligne, colonne] != valeurAttendue)
                    {
                        gagné = false;
                    }
                    if (valeurAttendue == (plateau.GetLength(0) * plateau.GetLength(1)) - 1)
                        valeurAttendue = 0;
                    else
                        valeurAttendue++;
                }
            return gagné;
        }


        // pourrait être une méthode privée si on l'utilise uniquement dans 
        // un constructeur, ou faire partie du code du constructeur.
        private void NouveauJeu()
        {
            int position;
            List<int> aPlacer = new List<int>();
            for (int i = 0; i < this.dimension1 * this.dimension2; i++)
            {
                aPlacer.Add(i);
            }

            Random générer = new Random();

            for (int i = 0; i < this.plateau.GetLength(0); i = i + 1)
            {
                for (int j = 0; j < this.plateau.GetLength(1); j = j + 1)
                {
                    position = générer.Next(0, aPlacer.Count);
                    plateau[i, j] = aPlacer[position];
                    if (aPlacer[position] == 0)
                    {
                        ligneVide = i;
                        colonneVide = j;
                    }
                    aPlacer.RemoveAt(position);
                }
            }
        }

        // Accesseurs
        public int ColonneVide { get { return this.colonneVide; } }
        public int LigneVide { get { return this.ligneVide; } }

        // Indexeur 
        public int this[int ligne, int colonne] { get { return this.plateau[ligne, colonne]; } }
    }
}
