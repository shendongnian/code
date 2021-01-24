    namespace WhatAnApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool kalkulacka = false;
            bool mocninator = false;
            bool pokracovat = true;
            while (pokracovat == true)
            {
                Console.WriteLine("Vítejte v mé aplikaci, pro začátek si vyber, jestli chceš spustit kalkulačku nebo mocninátor.");
                Console.WriteLine("1 - mocninátor");
                Console.WriteLine("2 - kalkulačka");
                int volba1 = int.Parse(Console.ReadLine());
                switch (volba1)
                {
                    case 1:
                        mocninator = true;
                        Console.Clear();
                        break;
                    case 2:
                        kalkulacka = true;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Zadal jste špatnout hodnotu!");
                        break;
                }
                if (mocninator)
                {
                    Console.WriteLine("Vybrál sis mocninátor");
                    Console.WriteLine("Zadejte číslo, které chcete umocnit");
                    float s = float.Parse(Console.ReadLine());
                    double d = s;
                    double m = 2;
                    Console.WriteLine("Výsledek je: " + Math.Pow(s, m));
                    Console.WriteLine("Přeješ si aplikaci použit znovu? ano/ne");
                    switch (Console.ReadLine().ToString().ToLower())
                    {
                        case "ano":
                            pokracovat = true;
                            mocninator = false;
                            Console.Clear();
                            break;
                        case "ne":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Špatná volba");
                            break;
                    }
                }
                while (kalkulacka == true)
                {
                    Console.WriteLine("Pro začátek musíš zadat dvě čísla, se kterými budeš pracovat");
                    Console.WriteLine("Zadej první číslo: ");
                    float a;
                    while (!float.TryParse(Console.ReadLine(), out a))
                        Console.WriteLine("Zadal jste neplatné číslo");
                    Console.WriteLine("Zadej druhé číslo: ");
                    float b;
                    while (!float.TryParse(Console.ReadLine(), out b))
                        Console.WriteLine("Zadal jste neplatné číslo");
                    Console.WriteLine("Výborně, teď si vyber operaci: ");
                    Console.WriteLine("1 - sčítání");
                    Console.WriteLine("2 - odčítání");
                    Console.WriteLine("3 - násobení");
                    Console.WriteLine("4 - dělení");
                    char volba = Console.ReadKey().KeyChar;
                    Console.ReadKey();
                    Console.WriteLine("Zvolil jste volbu číslo: " + volba);
                    float vysledek = 0;
                    bool platnaVolba = true;
                    switch (volba)
                    {
                        case '1':
                            vysledek = a + b;
                            break;
                        case '2':
                            vysledek = a - b;
                            break;
                        case '3':
                            vysledek = a * b;
                            break;
                        case '4':
                            vysledek = a / b;
                            break;
                        default:
                            platnaVolba = false;
                            break;
                    }
                    if (platnaVolba)
                        Console.WriteLine("Výsledek: {0}", vysledek);
                    else
                        Console.WriteLine("Neplatná volba operace");
                    Console.WriteLine("Přejete si aplikaci použít znovu? ano/ne");
                    platnaVolba = false;
                    while (!platnaVolba)
                    {
                        switch (Console.ReadLine().ToString().ToLower())
                        {
                            case "ano":
                                platnaVolba = true;
                                pokracovat = true;
                                kalkulacka = false;
                                Console.Clear();
                                break;
                            case "ne":
                                platnaVolba = true;
                                pokracovat = false;
                                kalkulacka = false;
                                break;
                            default:
                                Console.WriteLine("Neplatná volba. Zadejte ano/ne !");
                                break;
                        }
                    }
                }
            }
        }
    }
