    public class Foo : Collection<string>
    {
        public void AddWithoutDoingStuff(string item)
        {
            if (Items.IsReadOnly())
               throw new NotSupportedException();
            base.InsertItem(Count, item);
        }
        protected override void InsertItem(int index, string item)
        {
            base.InsertItem(index, item);
            // Do Some Stuff
        }
    }
