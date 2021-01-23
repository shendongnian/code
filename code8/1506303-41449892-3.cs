    public class ValueManipulator
    {
        public void Manipulate<T>(IEnumerable<IValue<T>> pool)
        {
            foreach (int i in Enumerable.Range(0, pool.Count()))
            {
                IValue<T> firstValue = pool.ElementAt(i);
    
                foreach (IValue<T> secondValue in pool.Skip(i))
                {
                    if (firstValue.Check(secondValue))
                        firstValue.InteractionA(secondValue);
    
                    else
                        firstValue.InteractionB(secondValue);
                }
            }
        }
    }
