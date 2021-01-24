    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    static readonly ThreadLocal<Random> _random = new ThreadLocal<Random>(() => new Random());
    static IEnumerable<T> Choice<T>(IList<T> sequence, int size, double[] distribution) {
        double sum = 0;
        // first change shape of your distribution probablity array
        // we need it to be cumulative, that is:
        // if you have [0.1, 0.2, 0.3, 0.4] 
        // we need     [0.1, 0.3, 0.6, 1  ] instead
        var cumulative = distribution.Select(c => {
            var result = c + sum;
            sum += c;
            return result;
        }).ToList();
        for (int i = 0; i < size; i++) {
            // now generate random double. It will always be in range from 0 to 1
            var r = _random.Value.NextDouble();
            // now find first index in our cumulative array that is greater or equal generated random value
            var idx = cumulative.BinarySearch(r);
            // if exact match is not found, List.BinarySearch will return index of the first items greater than passed value, but in specific form (negative)
            // we need to apply ~ to this negative value to get real index
            if (idx < 0)
                idx = ~idx; 
            if (idx > cumulative.Count - 1)
               idx = cumulative.Count - 1; // very rare case when probabilities do not sum to 1 becuase of double precision issues (so sum is 0.999943 and so on)
            // return item at given index
            yield return sequence[idx];
        }
    }
