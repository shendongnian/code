    public class Example
    {
        double[][] items;
    
        public void AddToItem(int i, int j, double addendum)
        {
            var spin = new SpinWait();
    
            while (true)
            {
                var valueAtStart = Volatile.Read(ref items[i][j]);
                var newValue = valueAtStart + addendum;
    
                var oldValue = Interlocked.CompareExchange(ref items[i][j], newValue, valueAtStart);
    
                if (oldValue.Equals(valueAtStart))
                    break;
                spin.SpinOnce();
            }
        }
    }
