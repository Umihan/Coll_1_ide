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
                Random Richtung = new Random();
                int Direction = Richtung.Next(4);
                switch (Direction)
                { 
                    case 0:             //links
                        if (posx != 0)
                            posx -= 1;
                        else
                            posx = seite;
                        break;

                    case 1:             //rechts
                        if (posx != seite)
                            posx += 1;
                        else
                            posx = 0;
                        break;

                    case 2:             //oben
                        if (posy != 0)
                            posy += 1;
                        else
                            posy = seite;
                        break;

                    case 3:             //unten
                        if (posy != seite)
                            posy -= 1;
                        else
                            posy = 0;
                        break;

                    default:
                        break;
                
                }
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

        /// <summary>
        /// Hier wird die Standard-Konfigurationsdatei config.ini erstellt oder geändert und die Anzahl eingetragen.
        /// Sollte die Datei nicht erstellt werden können, wird ein Rückgabewert false retourniert.
        /// Ansonsten ist der Rückgabewert true.
        /// </summary>
        /// <param name="Anzahl"></param>
        /// <returns></returns>
        static bool SaveConfig(int Anzahl)
        {
            var pfad = @"..\config.ini"; // Dementsprechend Pfad ändern
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

        /// <summary>
        /// Hier wird die Standard-Konfigurationsdatei config.ini ausgelesen und die Anzahl zurückgegeben.
        /// Sollte die Datei nicht existieren oder keine Anzahl enthalten,
        /// wird in Anzahl der Wert 0 und ein Rückgabewert false retourniert.
        /// Ansonsten ist der Rückgabewert true.
        /// </summary>
        /// <param name="Anzahl"></param>
        /// <returns></returns>
        public static bool LoadConfig(ref int Anzahl)
        {
            var pfad = @"..\config.ini";
            string nummerntext = File.ReadAllText(pfad);
            int uebergabe = Convert.ToInt32(nummerntext); // Um die Zahl zu speichern -> um später zu kontrollieren/ überprüfen oder überschreiben

            if ((File.Exists(pfad)) & (uebergabe > 0))     // Wenn der Pfad existiert UND die Zahl größer als 0 ist...
            {
                Anzahl = uebergabe;      // Anzahl wird nun umgeändert. Anzahl erhält nun die Zahl, die von der config.ini Datei rausegelesn worden ist und über string nummerntext in int kontrolle abgespeichert worden ist.
                return true;            //... true
            }
            else
            {
                return false;           //... false 
            }
        }

    }
}
