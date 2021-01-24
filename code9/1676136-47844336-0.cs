            var listA = new List<Property>
            {
                new Property{ Name = "A" },
                new Property{ Name = "A" },
                new Property{ Name = "A" },
                new Property{ Name = "B" }
            };
            var listB = new List<Property>
            {
                new Property{ Name = "A" },
                new Property{ Name = "B" },
                new Property{ Name = "B" }
            };
            var joinedList = new List<JoinedProperty>();
            for (int i = 0; i < listA.Count; i++)
            {
                var property = new JoinedProperty
                {
                    AName = listA[i].Name,
                    BName = null
                };
                if (listB.Count < i + 1)
                {
                    continue;
                }
                if (listA[i].Name == listB[i].Name)
                {
                    property.BName = listA[i].Name;
                }
                joinedList.Add(property);
            }
            for (int i = 0; i < listB.Count; i++)
            {
                var property = new JoinedProperty
                {
                    AName = null,
                    BName = listB[i].Name
                };
                if (listA.Count < i + 1)
                {
                    continue;
                }
                if (listB[i].Name == listA[i].Name)
                {
                    property.AName = listB[i].Name;
                }
                joinedList.Add(property);
            }
            public class JoinedProperty
            {
                 public string AName { get; set; }
                 public string BName { get; set; }
            }
