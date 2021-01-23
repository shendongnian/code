    private static IEnumerable<int> generateNUmbers(ImmutableStack<string> digits, IEnumerable<string> set, int length)
    {
        if (digits.Count == length)
        {
            yield return int.Parse(string.Concat(digits));
        }
        else
        {
            foreach (var digit in set)
            {
                var newDigits = digits.Push(digit);
                foreach (var newNumber in generateNUmbers(newDigits, set, length))
                {
                    yield return newNumber;
                }
            }
        }
    }
