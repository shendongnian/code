    using Microsoft.Xna.Framework.Content;
    using System;
    
    namespace XMLMenu
    {
        public class Menu
        {
            public String Title;
            public Background Background = new Background();
            [ContentSerializer(CollectionItemName = "Option")]
            public Option[] Options = new Option[] { };
            public Buttons Buttons = new Buttons();
        }
    }
