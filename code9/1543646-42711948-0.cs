    using System;
    using System.Xml.Serialization;
    
    namespace Serialization_Help
    {
        [Serializable()]
        [XmlRoot("locations")]
        public class Cocktail
        {
    
            [XmlElement("id")]
            public int CocktailID { get; set; }
            [XmlElement("name")]
            public string CocktailName { get; set; }
            [XmlElement("alc")]
            public bool alcohol { get; set; }
            [XmlElement("visible")]
            public bool is_visible { get; set; }
            [XmlElement("counter")]
            public int counter { get; set; }
            public Cocktail() {
    
            }
            public Cocktail(int id, string name, bool alc, bool vis, int count)
            {
                this.CocktailID = id;
                this.CocktailName = name;
                this.alcohol = alc;
                this.is_visible = vis;
                this.counter = count;
            }
        }
    }
