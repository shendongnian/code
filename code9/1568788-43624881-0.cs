           public bool hasSelected(Hero h)
            {
                return !(h.Equals(default(Hero)));
            }
            public void clearSelected()
            {
                selectedHero = default(Hero); 
            }
