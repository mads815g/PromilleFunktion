using PromilleKlasse;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PromilleFunktion
{
    class Program
    {
        public static double Pust(double promille)
        {
            Random rng = new Random();
            promille += rng.NextDouble();
            return promille;
        }

        public static List<Promille> liste = new List<Promille>
        { 
            new Promille { Name = "Mads", Id = 1, Time = DateTime.Now, AlkoholNiveau = 0 },
            new Promille { Name = "Peter", Id = 2, Time = DateTime.Now, AlkoholNiveau = 0 }
        };

        public static void PustAlle()
        {
            foreach (var person in liste)
            {
                if (person.AlkoholNiveau < 3)
                {
                    person.AlkoholNiveau += Pust(person.AlkoholNiveau);
                }
                Console.WriteLine(person);
                Thread.Sleep(1000);
            }
        }
        static void Main(string[] args)
        {
            PustAlle();
            PustAlle();
            PustAlle();

            List<Promille> fulde = new List<Promille>();
            do
            {
                foreach (Promille person in liste)
                {
                    if (person.AlkoholNiveau > 0.5)
                    {
                        fulde.Add(person);
                        person.AlkoholNiveau -= 0.15;
                        Console.WriteLine(person);
                    } else
                    {
                        fulde.Remove(person);
                    }
                }
                Thread.Sleep(1000);
            } while (fulde.Count > 0);
        }
    }
}
