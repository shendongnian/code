    public float ReadFloat()
            {
                float ReadValue = 0;
                string KeySequence = "";
                string TempKey = "";
                bool CommaUsed = false;
                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey(true);
                    if ((key.Key >= ConsoleKey.D0 && key.Key <= ConsoleKey.D9) || (key.Key >= ConsoleKey.NumPad0 && key.Key <= ConsoleKey.NumPad9))
                    {
                        TempKey = Convert.ToString(key.Key);
                        TempKey = TempKey.Remove(0, 1);
                        KeySequence += TempKey;
                        Console.Write(TempKey);
                    };
                    if (key.Key == ConsoleKey.OemComma || key.Key == ConsoleKey.Decimal)
                    {
                        if (!CommaUsed)
                        {
                            KeySequence += ".";
                            Console.Write(".");
                            CommaUsed = true;
                        };
                    };
                    if ((key.Key == ConsoleKey.Backspace) && KeySequence != "")
                    {
                        string LastChar = KeySequence.Substring(KeySequence.Length - 1);
                        //MessageBox.Show("Last char: "+LastChar);
                        //Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                        char SepDeci = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                        if (Convert.ToChar(LastChar) == SepDeci)
                        {
                            CommaUsed = false;
                        };
                        KeySequence = KeySequence.Remove(KeySequence.Length - 1);
                        Console.Write("\b \b");
                    };
                }
                while (key.Key != ConsoleKey.Enter);
                if (KeySequence == "")
                {
                    return 0;
                };
                ReadValue = Convert.ToSingle(KeySequence);
                return ReadValue;
            }
