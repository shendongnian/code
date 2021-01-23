    static class Extensions
    
        public static void Sort<T>(this ObservableCollection<T> collection) where T : IComparable
        {
            List<T> sorted = collection.OrderBy(x => x).ToList();
            for (int i = 0; i < sorted.Count(); i++)
                collection.Move(collection.IndexOf(sorted[i]), i);
        }
    }
    public class YourCollections : ObservableCollection<YourPoints>, ICustomTypeDescriptor, INotifyPropertyChanged
    {
    }
