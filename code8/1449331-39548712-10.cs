        private static IEnumerable<int> ShiftLeft(IEnumerable<int> sequence)
        {
            if (!sequence.Any())
                yield break;
            foreach (var i in sequence.Skip(1))
            {
                yield return i;
            }
            yield return sequence.First();
        }
        private static IEnumerable<IEnumerable<int>> getAllModulusSequences(int modulus)
        {
            var sequence = Enumerable.Range(0, modulus);
            for (var i = 0; i < modulus; i++)
            {
                yield return sequence;
                sequence = sequence.ShiftLeft();
            }
        }
