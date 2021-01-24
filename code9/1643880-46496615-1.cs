    public void CheckArray()
        {
            var songs = new string[] { "Hello", "Heya", "Piano Man", "Seven Years" };
            
            foreach(var title in songs)
            {
                if (title.Equals("Seven Years"))
                {
                    // Do The Thing
                }
                else
                {
                    // Do Nothing
                }
            }
        }
