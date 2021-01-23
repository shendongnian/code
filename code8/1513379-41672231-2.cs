        private static bool TryMultiplyDigits(string number, out int product)
        {
            Debug.Assert(number != null && number.Length > 0);
            product = 1;
            foreach (var c in number)
            {
                int digit;
                if (int.TryParse(c.ToString(), out digit))
                {
                    product *= digit;
                }
                else
                    return false;
            }
            return true;
        }
