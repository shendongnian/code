    private class Planet
            {
                public string Name { get; set; } = string.Empty;
                public IEnumerable<Planet> Children { get; set; } = new List<Planet>();
            }
