        private static void Main(string[] args)
        {
            string sentence = "This 15 i2s the45best str7ng 1n th3 w0r17ld";
            List<int> primes = new List<int>();
            for (int i = 0; i < sentence.Length; i++)
            {  
                // iterate through 'sentence' and add up valid digits to a string
                string nStr = string.Empty;
                while (char.IsDigit(sentence[i]))
                {
                    nStr += sentence[i];
                    i++;
                }
                 
                // if a number was detected and it is a prime number, add it to our list
                if (!string.IsNullOrWhiteSpace(nStr))
                {
                    int n = int.Parse(nStr);
                    if (IsPrime(n))
                        primes.Add(n);
                }
            }
            Console.WriteLine(primes.Count > 0 ? $"The prime numbers in\n\n\t{sentence}\n\nare {string.Join(", ", primes.ToArray())}" : $"There exist no primes in\n\n\t{sentence}");
            Console.ReadLine();
        }
        public static bool IsPrime(int number)
        {
            if (number == 1)
                return false;
            if (number == 2)
                return true;
            if (number % 2 == 0)
                return false;
            var boundary = (int)Math.Floor(Math.Sqrt(number));
            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
