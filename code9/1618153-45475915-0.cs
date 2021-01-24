     List<string> planetOrder = new List<string>();
            planets.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList().ForEach(p => planetOrder.Add(p.Split(" ".ToCharArray()).First()));
            List<string> planetName = new List<string>();
            planets.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(p => planetName.Add(p.Split(" ".ToCharArray()).Skip(1).First()));
            List<string> planetColor = new List<string>();
            planets.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(p => planetColor.Add(p.Split(" ".ToCharArray()).Last()));
