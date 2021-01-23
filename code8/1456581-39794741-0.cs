    Int32 Zahl1 = 7;
    Int32 Zahl2 = 4;
    Int32 Rechnung = Zahl1 + Zahl2;
    Console.WriteLine("Rechnung = {0}", Rechnung);
    // If you want the answer to be 74
    Int32 losung = Convert.ToInt32(Zahl1 + Zahl2);
    // If you want the answer to be 11
    Int32 losung = Rechnung;
    Console.WriteLine("Geben sie die Lösung ein {0}", losung);
    Int32 Ergebniss = Convert.ToInt32(Console.ReadLine());
    if (Rechnung == Ergebniss)
        Console.WriteLine("Richtig");
    else
        Console.WriteLine("Falsch");
    Console.ReadLine();
