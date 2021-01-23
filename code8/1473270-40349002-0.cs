            string[] stringA = "503 504 505 506 507 508 503 504 505 506".Split();
            string[] stringB = "503 504 504 505 506 507 505 508 503 506 505 506 504".Split();
            List<int> missingNumbers = new List<int>();
            foreach (string num in stringB.Distinct())
            {
                int difference = stringB.Where(x => x == num).Count() - stringA.Where(x => x == num).Count();
                for (int i = difference; i > 0; i--)
                {
                    missingNumbers.Add(int.Parse(num));
                }
            }
