using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Plyta> plyty = new List<Plyta>();
            char wybor = '0';
            do
            {
                Menu(ref wybor);
                switch (wybor)
                {
                    case '1':
                        DodajPlyte(plyty);
                        break;
                    case '2':
                        WyswietlIWybierzPlyte(plyty);
                        break;
                    case '3':
                        ZapiszDoPlikuXml(plyty);
                        break;
                    case '4':
                        WczytajZPlikuXml(plyty);
                        break;
                }
            } while (wybor != '0');
        }



        static void Menu(ref char wybor)
        {
            Console.Clear();

            Console.WriteLine("1. Dodaj płytę");
            Console.WriteLine("2. Przejrzyj albumy");
            Console.WriteLine("3. Zapisz bazę płyt");
            Console.WriteLine("4. Odczytaj bazę płyt");
            Console.WriteLine("0. Wyjdź z programu");

            wybor = Convert.ToChar(Console.ReadKey().KeyChar);

            Console.Clear();
        }



        static void DodajPlyte(List<Plyta> plyty)
        {
            char wybor = '0';
            Plyta nowaPlyta = new Plyta();
            nowaPlyta.PodajTytulPlyty();
            nowaPlyta.PodajTypPlyty();
            plyty.Add(nowaPlyta);
            Plyta.UstawNumeryPlyt(plyty);
            do
            {
                Console.WriteLine("Czy chcesz dodać utwór do tej płyty?[T/N]");
                wybor = Console.ReadKey().KeyChar;
                if (wybor == 't' || wybor == 'T')
                {
                    DodajUtwor(plyty[plyty.Count - 1]);
                }
                Console.Clear();
            } while (wybor != 'n' && wybor != 'N');
            plyty[plyty.Count - 1].ZsumujCzasTrwaniaPlyty();
        }



        static void DodajUtwor(Plyta plyta)
        {
            Utwor nowyUtwor = new Utwor();

            nowyUtwor.DodajNazweUtworu();
            nowyUtwor.DodajDlugoscUtworu();
            nowyUtwor.DodajWykonawcowUtworu();
            nowyUtwor.DodajKompozytora();
            plyta.spisUtworow.Add(nowyUtwor);
            for (int i = 0; i < plyta.spisUtworow.Count; i++)
            {
                plyta.spisUtworow[i].NumerUtworu = i + 1;
            }
        }



        static void WyswietlIWybierzPlyte(List<Plyta> plyty)
        {
            char wybor = '0';
            do
            {
                Console.Clear();
                Console.WriteLine("Wybierz 1 aby wyświelić albumy\nWybierz 2 aby wyświetlić wykonawców albumu\nWciśnij 0, aby wrocić do menu");
                wybor = Console.ReadKey().KeyChar;
                Console.Clear();
                if (wybor == '1')
                {
                    WybierzPlyte(plyty);
                }
                else if (wybor == '2')
                {
                    WyswietlWykonawcowNaPlycie(plyty);
                }
            } while (wybor != '0');
        }



        static void WybierzPlyte(List<Plyta> plyty)
        {
            Console.Clear();
            Console.WriteLine("Wciśnij 0, aby zrezygnować i wróćić");
            Console.WriteLine("Wybierz numer albumu: ");
            WyswietlListePlyt(plyty);
            char wybor = Console.ReadKey().KeyChar;
            if (wybor != 0)
            {
                int liczba = wybor - '0'; //zamiana chara na integer

                foreach (Plyta plyta in plyty)
                {
                    if (liczba == plyta.NumerPlyty)
                    {
                        WyswietlUtworyNaPlycie(plyta);
                    }
                }
            }
        }



        static void WyswietlUtworyNaPlycie(Plyta plyta)
        {
            Console.Clear();
            Console.WriteLine("Wciśnij 0, aby zrezygnować i wrócić");
            Console.WriteLine("Wybierz numer utworu: ");
            plyta.WyswietlUtwory();
            char wybor = Console.ReadKey().KeyChar;
            if (wybor != 0)
            {
                int liczba = wybor - '0'; //zamiana chara na integer

                foreach (Utwor utwor in plyta.spisUtworow)
                {
                    if (liczba == utwor.NumerUtworu)
                    {
                        utwor.WyswietlNazweINumerUtworu();
                        utwor.WyswietlWykonawcow();
                        utwor.WyswietlKompozytora();
                    }
                }
                Console.WriteLine("Wcisnij dowolny przycisk, aby kontynuować");
                Console.ReadKey();
            }
        }



        static void WyswietlWykonawcowNaPlycie(List<Plyta> plyty)
        {
            Console.Clear();
            WyswietlListePlyt(plyty);
            Console.WriteLine();
            Console.WriteLine("Z której płyty wyświetlić wykonawców?");
            Console.WriteLine("Aby powrocić wciśnij 0");
            char wybor = Console.ReadKey().KeyChar;
            Console.Clear();
            if (wybor != 0)
            {
                int liczba = wybor - '0';
                foreach (Plyta plyta in plyty)
                {
                    if (liczba == plyta.NumerPlyty)
                    {
                        plyta.WyswietlWykonawcowNaPlycie();
                    }
                }
                Console.WriteLine("Wciśnij dowolny przycisk, aby kontynuować");
                Console.ReadKey();
            }
        }



        static void WyswietlListePlyt(List<Plyta> plyty)
        {
            foreach (Plyta plyta in plyty)
            {
                plyta.WyswietlPlyte();
            }
        }



        public static void ZapiszDoPlikuXml(List<Plyta> plyty)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Plyta>));

            using (FileStream stream = File.OpenWrite("filename"))
            {
                serializer.Serialize(stream, plyty);
            }
        }



        public static void WczytajZPlikuXml(List<Plyta> plyty)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Plyta>));
            using (FileStream stream = File.OpenRead("filename"))
            {
                List<Plyta> nowaLista = (List<Plyta>)serializer.Deserialize(stream);
                for(int i = 0; i < nowaLista.Count; i++)
                {
                    plyty.Add(nowaLista[i]);
                }
            }

        }
    }
}
