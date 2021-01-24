     public class Feature
        {
            public string Name { get; set; }
        
            public string DisplayName { get; set; }
        
            public List<Feature> SubFeatures { get; set; } = new List<Feature>();
        }
