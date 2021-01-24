        List<Fields> RemoveDuplicates(List<Fields> fields)
        {
            List<Fields> removedDuplicates = new List<Fields>();
            fields.ForEach(f =>
            {
                if (removedDuplicates.FindAll(d => 
                    d.Field1 == f.Field1 && 
                    d.Field2 == f.Field2).Count == 0)
                {
                    removedDuplicates.Add(f);
                }
            });
            return removedDuplicates;
        }
