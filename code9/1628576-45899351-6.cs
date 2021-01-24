    static IEnumerable<IEnumerable<int>> GetPermutations(IList<int> input)
    {
        if (input == null)
            throw new ArgumentNullException(nameof(input));
        if (input.Count < 2)
            throw new ArgumentException("Input does not have a valid format.");
        var setSize = input[0];
        var prefixSize = input[1];
        if (prefixSize != input.Count-2)
            throw new ArgumentException("Input does not have a valid format.");
        if (input.Skip(2).Any(i => i > setSize)) //we are assuming, per example, that valid range starts at 1.
            throw new ArgumentException("Input does not have a valid format.");
        //Ok, we've got a valid input, interesting stuff starts here.
        var prefix = input.Skip(2).ToArray();
        var initialSet = Enumerable.Range(1, setSize).Except(prefix);
        foreach (var p in getPermutations(ImmutableStack<int>.Empty, initialSet))
        {
            yield return prefix.Concat(p);
        }
        IEnumerable<IEnumerable<int>> getPermutations(ImmutableStack<int> permutation, IEnumerable<int> set)
        {
            if (permutation.Count == setSize - prefixSize)
            {
                yield return permutation;
            }
            else
            {
                foreach (var i in set)
                {
                    foreach (var p in getPermutations(permutation.Push(i), set.Except(new[] { i })))
                    {
                        yield return p;
                    }
                }
            }
        }
    }
