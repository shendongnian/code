      double fuenfh = 500.00, zweit = 2000.00, fuenft = 5000.00;
                //zweiPro = 2.00, fuenfPro = 5.00, zehnPro = 10.00;
                do
                {
                    Console.WriteLine("\nWie groß war Ihr Rechnungsbetrag? ");
                    var eingabe = double.TryParse(Console.ReadLine(), out var rebe);
                    if (eingabe)
                    {
                        if (rebe >= fuenft) { Console.Write($"Die eingabe ist größer oder gleich {fuenft}"); }
                        else if (rebe >= zweit) { Console.Write($"Die eingabe ist größer oder gleich {zweit} aber kleiner als {fuenfh}"); }
                        else if (rebe >= fuenfh) { Console.Write($"Die eingabe ist größer oder gleich {fuenfh} aber kleiner als {zweit}"); }
                        else { Console.Write($"Die eingabe ist kleiner als {fuenfh}"); }
                    }
                    else { Console.WriteLine("Bitte Zahl eingeben!"); }
                } while (true);
