    public class PersistentList<T> : List<T> where T : class, new(), IItem
    {
        public void Update(T item)
        {
            // T must derive from the interface by constraint
            var old = la.Find(p => p.Id == item.Id);
            /* Changes to list */
            SaveChanges();
        }
    }
