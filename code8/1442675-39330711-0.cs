    public static class CBaseExtensions
    {
        ///<param name="Searchstring"> String nach dem die Lastenliste durchsucht werden soll </param>
        ///<param name="Parameter"> NAME für Lastenname, ALIASNAME oder DESCRIPTION</param>
        public static T GetItem<T>(this Collection<T> self, string Searchstring, string Parameter = "NAME") where T : CBase
        {
            if (self.Count == 0) return null;
            if (Searchstring.Length == 0) return null;
            switch (Parameter)   // Parameter auswerten
            {
                case ("NAME"): return self.FirstOrDefault(item => item.Name == Searchstring);
                case ("DESCRIPTION"): return self.FirstOrDefault(item => item.Description == Searchstring);
                default: throw new System.Exception($"Suchparameter {Parameter} nicht vorhanden");
            }
        }
    }
