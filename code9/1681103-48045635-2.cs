    static List<NamedColor> ShuffleNames(List<NamedColor> colors)
    {
        var names = colors.Select(c => c.Name).ToList();
        var shuffled = new List<NamedColor>();
        for(int i = 0; i < colors.Count; i++)
        {
            string name;
            // If there are only two items left, and our list of names contains 
            // the *next* item's name, then we must take that name for this item
            if (i == colors.Count - 2 && names.Contains(colors[i + 1].Name))
            {
                name = colors[i + 1].Name;
            }
            else
            {
                // Choose a random name from all names except this item's name
                var candidateNames = names.Where(n => !n.Equals(colors[i].Name)).ToList();
                name = candidateNames[rnd.Next(candidateNames.Count)];
            }
            shuffled.Add(new NamedColor(colors[i].Color, name));
            names.Remove(name);
        }
            
        return shuffled;
    }
