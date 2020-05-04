using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
/*
 *  Collide
 *  Eine Simulation im 2-dimensionalen Raum 
 * 2020 TFO-Meran
 */

namespace ConsoleApplication1
{
    class Program
    {
        const int seite = 50;
        static int[,] feld = new int[seite, seite];

        class einer
        {
            // Private Eigenschaften

            // Öffentliche Eigenschaften
            public int posx, posy;
            public ConsoleColor farbe;
            // Konstruktor
            public einer()
            {
            }
            //Private Methoden
            void show()
            {
            }
            void hide()
            {
            }
            void collide()
            {
            }
            //Öffentliche Methoden
            public void Move()
            {
            }

        }

        static void Main(string[] args)
        {
            Console.WindowWidth = seite*2;
            Console.WindowHeight = seite;
            Console.Clear();
            Random ZG = new Random();
            int Anzahl=ZG.Next(1,6);
            einer[] meineEiner = new einer[Anzahl];
            for (int i = 0; i < Anzahl; i++)
            {
                meineEiner[i] = new einer();
            }
            Console.CursorVisible = false;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < Anzahl; j++)
                {
                    meineEiner[j].Move();
                }
                System.Threading.Thread.Sleep(10);

            }
        }

        static bool SaveConfig(int Anzahl)
        {
            var pfad = @"C:\Users\Daniel Karasani\Desktop\Collide_d\Coll_1_ide"; // Dementsprechend Pfad ändern
            string text = Convert.ToString(Anzahl);     // Integer Anzahl wird so als string (string text) gespeichert
            File.WriteAllText(pfad, text);

            if (File.Exists(pfad))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool LoadConfig(ref int Anzahl)
        {
            var pfad = @"C:\Users\Daniel Karasani\Desktop\config.ini";
            string nummerntext = File.ReadAllText(pfad);
            int kontrolle = Convert.ToInt32(nummerntext); // Um die Zahl zu speichern -> um später zu kontrollieren/ überprüfen

            if ((File.Exists(pfad)) & (kontrolle > 0))     // Wenn der Pfad existiert UND die Zahl größer als 0 ist...
            {
                Anzahl = kontrolle;     // Anzahl ist nun die Zahl, die von der config.ini Datei rausgelesen wurde
                return true;            //... true
            }
            else
            {
                Anzahl = 0;             // Anzahl wird 0
                return false;           //... false 
            }
        }

    }
}
