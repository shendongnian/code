    private static IEnumerable<int> generateNumbers(ImmutableStack<string> digits, IEnumerable<string> set, int length)
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
                foreach (var newNumber in generateNumbers(newDigits, set, length))
                {
                    yield return newNumber;
                }
            }
        }
    }
