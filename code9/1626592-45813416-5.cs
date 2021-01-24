            [System.Serializable]
            public abstract class Base
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public Employee(string Name, int ID)
            {
                this.Name = Name;
                this.ID = ID;
            }
        }
