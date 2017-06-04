using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Utwor
    {
        public string NazwaUtworu { get; set; }
        public double DlugoscUtworu { get; set; }
        public List<string> spisWykonawcow = new List<string>();
        public string Kompozytor { get; set; }
        public int NumerUtworu { get; set; }



        public void DodajNazweUtworu()
        {
            Console.Write("Podaj nazwę utworu: ");
            NazwaUtworu = Console.ReadLine();
        }



        public void DodajDlugoscUtworu()
        {
            Console.Write("Podaj dlugość utworu [M,SS] : ");
            DlugoscUtworu = double.Parse(Console.ReadLine());
        }



        public void DodajWykonawcowUtworu()
        {
            int liczbaWykonawcow = 0;
            Console.Write("Podaj ilu wykonawców jest w utworze: ");
            liczbaWykonawcow = Convert.ToInt32(Console.ReadLine());
            if (liczbaWykonawcow == 1)
            {
                Console.Write("Podaj nazwę wykonawcy: ");
                spisWykonawcow.Add(Console.ReadLine());
            }
            else if (liczbaWykonawcow > 1)
            {
                for (int i = 0; i < liczbaWykonawcow; i++)
                {
                    Console.Write("Podaj nazwę wykonawcy nr {0}: ", i + 1);
                    string wykonawca = Console.ReadLine();
                    spisWykonawcow.Add(wykonawca);
                }
            }
        }


        public void DodajKompozytora()
        {
            Console.Write("Podaj nazwę kompozytora: ");
            Kompozytor = Console.ReadLine();
        }


        public void WyswietlNazweINumerUtworu()
        {
            Console.WriteLine("Utwór nr {0}: Nazwa utworu: {1}", NumerUtworu, NazwaUtworu);
        }


        public void WyswietlWykonawcow()
        {
            foreach(string wykonawca in spisWykonawcow)
            {
                Console.WriteLine("Wykonawca: {0}", wykonawca);
            }
        }


        public void WyswietlKompozytora()
        {
            Console.WriteLine("Kompozytor: {0}", Kompozytor);
        }
    }




}
