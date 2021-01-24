    public class PersistentList<T> : List<T> where T : class, new(), IItem
    {
        public void Update(T item)
        {
            // T must derive from the interface by constraint
            T old = base.Find(p => p.Id == item.Id);
            int index = base.IndexOf(old);
            base[index] = item;
            SaveChanges();
        }
    }
