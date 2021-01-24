    public class Message<T, U>
    {
        public int ID;
        private readonly Dictionary<T, U> dict;
        public Message(int ID, Dictionary<T, U> Data)
        {
            this.ID = ID;
            dict = Data;
        }
    }
