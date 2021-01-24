    public class Item
    {
        private string description;
        public void SetDescription(string description)
        {
            this.description = description; // without this you would just be setting the local variable to itself
        }
    }
