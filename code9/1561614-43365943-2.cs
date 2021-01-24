    static void Main(string args[]) {
            WriteLine("Please enter a number...");
            var num = ReadLine();
            // Check if input is a number
            if (!long.TryParse(num, out _)) {
                WriteLine("NaN!");
                return;
            }
            var evenChars = 0;
            var oddChars = 0;
            // Convert string to char array, rid of any non-numeric characters (e.g.: -)
            num.ToCharArray().Where(c => char.IsDigit(c)).ToList().ForEach(c => {
                byte.TryParse(c.ToString(), out var b);
                if (b % 2 == 0)
                    evenChars++;
                else
                    oddChars++;
                // Alternative method:
                IsEven(b) ? evenChars++ : oddChars++;
            });
            // Continue with code
            
            bool IsEven(byte b) => b % 2 == 0;
        }
