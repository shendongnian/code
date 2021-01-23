        static void Main(string[] args)
        {
            string line = "";
            using (var api = new KeystrokeAPI())
            {
                api.CreateKeyboardHook((character) => {
                    line += character.ToString();
                    if (character.KeyCode.ToString() == "Space")
                    {
                        Console.Write("Spacebar Hit");
                    }
                    
                    Console.Write(character.KeyCode);
                });
                Application.Run();
            }
        }
