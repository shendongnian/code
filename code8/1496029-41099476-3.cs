    public class Sword : BaseItem {
        public Sword() : base() {
            string[] names = new string[] { "atk", "def", "weight", "something" };
            string choosen = names[new Random().Next() % names.Length];
            SetValue(choosen, new Random().Next() % 1337);
        }
    }
    public class Shield : BaseItem {
        public Shield() : base() {
            int rand = new Random().Next() % _attributes.Count();
            SetValue(_attributes.Keys[rand], new Random().Next() % 1337);
        }
    }
