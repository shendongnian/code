    public static class MyEnumerableExtensions
    {
        public IEnumerable<System.Tuple<T, T>> EqualityZip<T>(this IEnumerable<T> sourceA,
            IEnumerable<T> sourceB)
        {
            // TODO: check for parameters null
            var enumeratorA = sourceA.GetEnumerator();
            var enumeratorB = sourceB.GetEnumerator();
            
            // enumerate as long as we have elements in A and in B:
            bool aAvailable = enumeratorA.MoveNext();
            bool bAvailable = enumeratorB.MoveNext();
            while (aAvailable && bAvailable)
            {   // we have an A element and a B element
                T a = enumeratorA.Current;
                T b = enumeratorB.Current;
                // compare the two elements:
                if (a == b)
                {   // equal: return tuple (a, b)
                    yield return Tuple.Create(a, b)
                }
                else
                {   // not equal, return (a, null)
                    yield return Tuple.Create(a, (T)null)
                }
                // move to the next element
                aAvailable = enumeratorA.MoveNext();
                bAvailable = enumeratorB.MoveNext();
            }
            // now either we are out of A or out of B
            while (aAvailable)
            {   // we still have A but no B, return (A, null)
                T A = enumeratorA.Current;
                yield return Tuple.Create(A, (T)null);
                aAvailable = enumeratorA.MoveNext();
            }
            while (bAvailable)
            {   // we don't have A, but there are still B, return (null, B)
                T B = enumeratorB.Current;
                yield return Tuple.Create((T)null, B);
                bAvailable = enumeratorB.MoveNext();
            }
            // if there are still A elements without B element: return (a, null)
            while (enumaratorA.Nex
        }
    }
