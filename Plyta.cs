using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Plyta
    {
        public string TytulPlyty { get; set; }
        public int NumerPlyty { get; set; }
        public string TypPlyty { get; set; }
        public double CzasTrwaniaPlyty { get; set; }
        public List<Utwor> spisUtworow = new List<Utwor>();



        public void PodajTytulPlyty()
        {
            Console.Write("Podaj tytul płyty: ");
            TytulPlyty = Console.ReadLine();
        }



        public void PodajTypPlyty()
        {

            char wybor = '0';

            do
            {

                Console.WriteLine("Typ plyty (CD = 1, DVD = 2): ");
                wybor = Console.ReadKey().KeyChar;

            } while (wybor != '1' && wybor != '2');

            if (wybor == '1') TypPlyty = "CD";

            else
            {
                TypPlyty = "DVD";
            }
        }



        public void ZsumujCzasTrwaniaPlyty()
        {
            CzasTrwaniaPlyty = 0;
            foreach (Utwor utwor in spisUtworow)
            {
                CzasTrwaniaPlyty += utwor.DlugoscUtworu;
            }
        }

        
        
        static public void UstawNumeryPlyt(List <Plyta> plyty)
        {
            for (int i = 0; i < plyty.Count; i++) // przypisanie numeru dla kazdej plyty
            {
                plyty[i].NumerPlyty = i+1;
            }
        }



        public void WyswietlUtwory()
        {
            Console.WriteLine("--------------------------------------------------");
            foreach(Utwor utwor in spisUtworow)
            {
                Console.WriteLine("{0}. {1}", utwor.NumerUtworu, utwor.NazwaUtworu);
            }
        }
        


        public void WyswietlPlyte()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("{0}.Tytuł albumu: {1}, typ płyty: {2}, czas trwania płyty: {3}", NumerPlyty, TytulPlyty, TypPlyty, CzasTrwaniaPlyty);
        }

        public void WyswietlWykonawcowNaPlycie()
        {
            Console.Clear();
            foreach(Utwor utwor in spisUtworow)
            {
                utwor.WyswietlWykonawcow();
            }
        }
    }
}