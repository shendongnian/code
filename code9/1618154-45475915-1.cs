            List<string> planetOrder = new List<string>();
            planets.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(p => planetOrder.Add(p.Split( " ".ToCharArray())[0]));
            List<string> planetName = new List<string>();
            planets.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(p => planetName.Add(p.Split(" ".ToCharArray())[1]));
            List<string> planetColor = new List<string>();
            planets.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(p => planetColor.Add(p.Split(" ".ToCharArray())[2]));
