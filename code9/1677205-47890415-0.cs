      public string Formatsfunction(List<Metadata> mmds)
        {
           Dictionary<string, int> formatNumber = new Dictionary<string, int>();
            foreach (Metadata mmd in mmds)
            {
                var type = mmd.Format.Type;
                var found = formatNumber.ContainsKey(type);
                if (found == true)
                {
                    formatNumber[type]++;
                }
                else
                {
                    formatNumber[type] = 1;
                }
            }
            var temp = formatNumber
                .OrderByDescending(p=>p.Value)
                .Select(mmd => mmd.Key +" ("+ mmd.Value+")");
            string keyvalues = string.Join(", ", temp);
            return keyvalues;
        }
        private string MeldingInformatie(string impact, string type, List<Metadata> mmds)
        {
            var temp = Formatsfunction(mmds);
            
            var formats = mmds.Select(mmd => mmd.Format.Type +"("+temp+")");
            var trackTrace = mmds.Select(mmd => mmd.TrackTrace);
            string messageTypes = string.Join(", ", formats);
         }
    Output is now: Lion(8), Fish(7), Koala(6), Seagull(5), etc.
