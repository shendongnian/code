    [XmlInclude(typeof(Sword))]
    [XmlInclude(typeof(Axe))]
    [XmlInclude(typeof(Helmet))]
    [XmlInclude(typeof(Shell))]
    public class Item
    {
        [XmlAttribute("title")]
        public string Title;
    }
    public class Weapon : Item
    {
        [XmlAttribute("damage")]
        public float Damage;
    }
    public class Armor : Item
    {
        [XmlAttribute("protection")]
        public float Protection;
    }
    public class Sword : Weapon { }
    public class Axe : Weapon { }
    public class Helmet : Armor { }
    public class Shell : Armor { }
