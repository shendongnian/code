        public void UpdatePopList()
        {
            CRPopentities = CRPopentities.Where(p => p.MU_Identifier == selectmu).ToList();
            CRmappings2.Clear();
            foreach (var item in CRPopentities)
            {
                CRmappings2.Add(item);
            }
        }
