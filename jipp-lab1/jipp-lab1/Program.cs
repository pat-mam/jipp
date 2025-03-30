using System;
using System.Collections.Generic;

namespace jipp_lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            // //Console.WriteLine("Podaj swoje imię:");
            // //var name = Console.ReadLine();
            // //Console.WriteLine("Hello " + name);

            //// int result = 5 + 9;



            // int number=5;
            // double money=1.2;
            // string text="jakis tekst";
            // bool isLogged=true;
            // char myChar='y';
            // decimal price=2.22m;
            // Console.WriteLine($"number = {number},\nmoney = {money},\ntext = {text},\nisLogged = {isLogged},\nmyChar = {myChar}\nprice = {price} ");


            // string myAge = "Age: ";
            // int wifeAge = 18;
            // string result = myAge + wifeAge;
            // Console.WriteLine(result);
            // operacja zamienia zmienna wifeAge na string, nastepnie dodaje tekst do jednej zmiennej.
            // bool isTrue = true;
            // bool isFalse = false;
            // bool isReallyTrue = true;

            // bool and = isTrue && isFalse;
            // bool or = isTrue || isFalse;
            // bool negative = !isFalse;

            // Console.Write($"and = {and},\nor = {or},\nnegative = {negative}\n");

            // //Utwórz dwie zmienne o nazwach a, b i przypisz do nich wartości 5, 12.
            // //Utwórz zmienne o nazwach add, sub, div, mul, mod i przypisz do nich kolejno wynik dodawania, odejmowania, dzielenia, mnożenia i modulo zmiennych a i b.
            // // Wyświetl zmienne add, sub, div, mul, mod w konsoli.

            // int a = 5, b = 12;
            // int add = a + b;
            // int sub = a - b;
            // int div = a / b;
            // int mul = a * b;
            // int mod = a % b;
            // Console.WriteLine($"a = {a}, b = {b}, a + b = {add}, a - b = {sub}, a / b = {div}, a * b = {mul}, a % b = {mod}");

            //string a = "Ala";
            //string b = "ma";
            //string c = "kota.";

            //string result = a + b + c;
            //Console.WriteLine(result);
            // operacja dodaje zmienne string bez pustych znakow.

            //int n1=10, n2=20;
            //if (n1==n2) Console.WriteLine($"n1 = {n1} jest takie samo jak n2 = {n2}");
            //else if(n1>n2) Console.WriteLine($"n1 = {n1} jest wieksze od n2 = {n2}");
            //else Console.WriteLine($"n1 = {n1} jest mniejsze od n2 = {n2}");

            //Console.WriteLine("Petla for");
            // for(int i=0;i<10;i++)Console.WriteLine("C#");
            //Console.WriteLine("Petla while");
            //int j = 0;
            //while(j<10)
            //{
            //    Console.WriteLine("C#");
            //    j++;
            //}

            //int n = 0;
            //while (n <=10)
            //{
            //    if((n % 2) ==0 ) Console.WriteLine($"{n} - parzysta");
            //    else Console.WriteLine($"{n} - nieparzysta");
            //    n++;
            //}

            //int  n = 5;
            // for (int i = 1; i <= n; i++)
            // {
            //     for (int j = 1; j <= i; j++)
            //     {
            //         Console.Write("*");
            //     }
            //     Console.WriteLine("");
            // }

            //0 - 39 pkt - Ocena Niedostateczna
            //40 - 54 pkt - Ocena Dopuszczająca
            //55 - 69 pkt - Ocena Dostateczna
            //70 - 84 pkt - Ocena Dobra
            //85 - 98 pkt - Ocena Bardzo Dobra
            //99 - 100 pkt - Ocena Celująca

           // int exam = 55;

           //if (exam > 100 || exam < 0)
           //{Console.WriteLine("Wartość poza zakresem");
           //}
           // else if (exam<=39) Console.WriteLine("Ocena Niedostateczna");
           // else if (exam >39 && exam <=54) Console.WriteLine("Ocena Dopuszczająca");
           // else if (exam > 54 && exam <= 69) Console.WriteLine("Ocena Dostateczna");
           // else if (exam > 69 && exam <= 84) Console.WriteLine("Ocena Dobra");
           // else if (exam > 84 && exam <= 98) Console.WriteLine("Ocena Bardzo Dobra");
           // else if (exam > 98 && exam <= 100) Console.WriteLine("Ocena Celująca");

           string[] colors = { "Czerwony", "Zielony", "Fioletowy", "Mietowy" };
           Console.WriteLine($"Mój pierwszy kolor to: {colors[0]}");
           Console.WriteLine($"Mój ostatni kolor to: {colors[3]}");

           int[] tablica = { 1,4,78,5,23,4,67,9,19,12};
           Console.WriteLine("FOR");
           for (int i = 0; i < 10; i++)
           {
                Console.WriteLine($"Liczba: {tablica[i]}");
           }
           Console.WriteLine("while");
            int j = 0;
           while (j < 10)
           {
               Console.WriteLine($"Liczba: {tablica[j]}");
               j++;
           }
           Console.WriteLine("foreach ");

           foreach (int num in tablica)
           {
               Console.WriteLine($"Liczba: {num}");
            }

           List<string> fruits = new List<string> { "Pomidor", "Jabłko", "Marchewka", "Gruszka" };
           Console.WriteLine(string.Join(", ", fruits));
           fruits.RemoveAt(0);
           fruits.Remove(fruits[fruits.Count - 1]);
           Console.WriteLine(string.Join(", ", fruits));

        }
    }
}
