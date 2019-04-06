using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_1
{
    class Program
    {
        int liczbaPrzypadkow;
        string[,] dodawaneLiczby;

        void wczytajDane(string[,] liczby)
        {
            string liniaWejscia;
            string[] podzieloneliczby;
            for (int i = 0; i < liczby.GetLength(0); i++)
            {
                liniaWejscia = Console.ReadLine();
                podzieloneliczby = liniaWejscia.Split(' ');
                liczby[i, 0] = podzieloneliczby[0];
                liczby[i, 1] = podzieloneliczby[1];
            }
        }

        string[] DodajDuzeLiczby(string[,] liczby)
        {
            int[] pierwszaLiczba, drugaLiczba;
            string[] wyniki = new string[liczbaPrzypadkow];
            int iloscCyfr;
            for (int i = 0; i < liczby.GetLength(0); i++)
            {
                if (liczby[i, 0].Length >= liczby[i, 1].Length)
                    iloscCyfr = liczby[i, 0].Length;
                else
                    iloscCyfr = liczby[i, 1].Length;
                pierwszaLiczba = new int[iloscCyfr + 1];
                drugaLiczba = new int[iloscCyfr + 1];
                int sumaLokalna = 0;
                int nadmiarZeSlupka = 0;
                for (int j = 0; j < iloscCyfr + 1;  j++)
                {
                    if (j < (iloscCyfr + 1 - liczby[i, 0].Length))
                        pierwszaLiczba[j] = 0;
                    else
                    {
                        //pierwszaLiczba[j] = Convert.ToInt32(liczby[i, 0]);
                        pierwszaLiczba[j] = Convert.ToInt32(liczby[i, 0].Substring(Math.Abs(j - (iloscCyfr + 1 - liczby[i, 0].Length)),1));
                    }
                    if (j < (iloscCyfr + 1 - liczby[i, 1].Length))
                        drugaLiczba[j] = 0;
                    else
                    {
                        // = Convert.ToInt32(liczby[i, 1]);
                        drugaLiczba[j] = Convert.ToInt32(liczby[i, 1].Substring(Math.Abs(j - (iloscCyfr + 1 - liczby[i, 1].Length)),1));
                    }
                }
                //dodawanie pisemne
                string[] wynik = new string[iloscCyfr + 1];
                for (int k = iloscCyfr; k>=0; k--)
                {
                    sumaLokalna = pierwszaLiczba[k] + drugaLiczba[k] + nadmiarZeSlupka;
                    nadmiarZeSlupka = 0;
                    if (sumaLokalna >= 10)
                    {
                        sumaLokalna = sumaLokalna % 10;
                        nadmiarZeSlupka = 1;
                    }
                    wynik[k] = Convert.ToString(sumaLokalna);
                }
                string tymczasowyWynik = "";
                for (int m = 0; m < wynik.Length; m++)
                {
                    if (m>0 || wynik[0] != "0")
                    {
                        tymczasowyWynik += wynik[m];
                    }
                }
                wyniki[i] = tymczasowyWynik;
            }
            return wyniki;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("W pierwszej linii podaj ilosc par liczb, ktore chcesz dodac, w nastepnych podaj pary liczb, oddzielone spacja");
            Console.WriteLine("Wejscie:");
            program.liczbaPrzypadkow = Convert.ToInt32(Console.ReadLine());
            program.dodawaneLiczby = new string[program.liczbaPrzypadkow, 2];
            program.wczytajDane(program.dodawaneLiczby);
            string[] wynikiDodawania = program.DodajDuzeLiczby(program.dodawaneLiczby);
            Console.WriteLine("Wyjscie:");
            for (int i = 0; i < program.liczbaPrzypadkow; i++)
            {
                Console.WriteLine(wynikiDodawania[i]);
            }
            Console.ReadKey();
        }
    }
}
