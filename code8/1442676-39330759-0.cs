    public static class CLoadExtension
    {
        public static CLoad GetItem(this Collection<CLoad> coll, string Searchstring, string Parameter = "NAME")
        {
            if (this.Count == 0) return null;
                if (Searchstring.Length == 0) return null;
                switch (Parameter)   // Parameter auswerten
                {
                    case ("NAME"): return this.Where(item => item.Name == Searchstring).FirstOrDefault();
                    case ("DESCRIPTION"): return this.Where(item => item.Description == Searchstring).FirstOrDefault();
                    default: throw new System.Exception($"Suchparameter {Parameter} nicht vorhanden");
                }
        }
    }
