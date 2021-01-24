    class Obj2 : IComparable
    {
        public string Name { get; set; }
        public int Id { get; set; }
        // ...
        public int CompareTo(object obj)
        {
            Obj2 other = obj as Obj2;
            return Id.CompareTo(other.Id);
        }
    }
    class Obj1 : IComparable
    {
        public string Name { get; set; }
        public List<Obj2> Objects { get; set; }
        // ...
        
        public int CompareTo(object obj)
        {
            Obj1 other = obj as Obj1;
            /* loop until one list ends */
            for (int idx = 0; idx < Objects.Count && idx < other.Objects.Count; ++idx)
            {
                int comparison = Objects[idx].Id.CompareTo(other.Objects[idx].Id);
                /* if not equal return */
                if (comparison != 0)
                {
                    return comparison;
                }
            }
            /* if they were equal until now use count to compare */
            return Objects.Count - other.Objects.Count;
        }
    }
