    public class MyListItem
    {
        //some code ID, Name properties and so on
        public string Description => ToString();
        public override string ToString()
        {
            return $"{ID} {Name}";
        }
    }
