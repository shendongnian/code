    public class Foo : Collection<string>
    {
        public void AddWithoutDoingStuff(string item)
        {
            InsertItem(Count, item);
            // do stuff here
        }
        protected override void InsertItem(int index, string item)
        {
            base.InsertItem(index, item);
        }
    }
