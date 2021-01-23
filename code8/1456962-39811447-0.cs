    public static class Demo
    {
        public static void DemoCode()
        {
            // create new profile
            var profile = new UserProfile
            {
                Name = "Bill",
                Gold = 1000000,
                Achievements = new List<Achievement>(new[]
                {
                    Achievement.Warrior
                }),
                Inventory = new Inventory(new[]
                {
                    new FireSpell()
                })
            };
            // save it
            using (var stream = File.Create("profile.bin"))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, profile);
            }
            // load it
            using (var stream = File.OpenRead("profile.bin"))
            {
                var formatter = new BinaryFormatter();
                var deserialize = formatter.Deserialize(stream);
                var userProfile = (UserProfile) deserialize;
                // set everything on fire :)
                var fireSpell = userProfile.Inventory.Items.OfType<FireSpell>().FirstOrDefault();
                if (fireSpell != null) fireSpell.Execute("whatever");
            }
        }
    }
    [Serializable]
    public sealed class UserProfile
    {
        public string Name { get; set; }
        public int Gold { get; set; }
        public List<Achievement> Achievements { get; set; }
        public Inventory Inventory { get; set; }
    }
    public enum Achievement
    {
        Warrior
    }
    [Serializable]
    public sealed class Inventory : ISerializable
    {
        public Inventory() // for serialization
        {
        }
        public Inventory(SerializationInfo info, StreamingContext context) // for serialization
        {
            var value = (string) info.GetValue("Items", typeof(string));
            var strings = value.Split(';');
            var items = strings.Select(s =>
            {
                var type = Type.GetType(s);
                if (type == null) throw new ArgumentNullException(nameof(type));
                var instance = Activator.CreateInstance(type);
                var item = instance as InventoryItem;
                return item;
            }).ToArray();
            Items = new List<InventoryItem>(items);
        }
        public Inventory(IEnumerable<InventoryItem> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            Items = new List<InventoryItem>(items);
        }
        public List<InventoryItem> Items { get; }
        #region ISerializable Members
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            var strings = Items.Select(s => s.GetType().AssemblyQualifiedName).ToArray();
            var value = string.Join(";", strings);
            info.AddValue("Items", value);
        }
        #endregion
    }
    public abstract class InventoryItem
    {
        public abstract void Execute(params object[] objects);
    }
    public abstract class Spell : InventoryItem
    {
    }
    public sealed class FireSpell : Spell
    {
        public override void Execute(params object[] objects)
        {
            // using 'params object[]' a simple and generic way to pass things if any, i.e.
            // var world = objects[0];
            // var strength = objects[1];
            // now do something with these !
        }
    }
