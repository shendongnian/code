    List<string> planetOrder = new List<string>();
            List<string> planetName = new List<string>();
            List<string> planetColor = new List<string>();
            planets.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(p =>
            {
                planetOrder.Add(p.Split(" ".ToCharArray())[0]);
                planetName.Add(p.Split(" ".ToCharArray())[1]);
                planetColor.Add(p.Split(" ".ToCharArray())[2]);
            });
