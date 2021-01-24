        public List<Dictionary<string, string>> TestDynamicModel(string SortBy)
        {
            var ret = new List<Dictionary<string, string>>();
            //Get the column names first
            //These below just a sample
            var columnNames = new List<string>(); 
            columnNames.Add("projectid"); columnNames.Add("company"); columnNames.Add("date");
            //You may iterate through every row by the column names count. Something like "foreach(var column in columnNames) {};"
            //These below just a sample
            ret.Add(new Dictionary<string, string>()); ret[0].Add("projectid", "1"); ret[0].Add("company", "company B"); ret[0].Add("date", "1/2/2018");
            ret.Add(new Dictionary<string, string>()); ret[1].Add("projectid", "2"); ret[1].Add("company", "company A"); ret[1].Add("date", "1/2/2017");
            ret.Add(new Dictionary<string, string>()); ret[2].Add("projectid", "3"); ret[2].Add("company", "company C"); ret[2].Add("date", "1/2/2016");
            //Sort by your own customized IComparer
            ret.Sort(new DynamicSortBy(SortBy));
            return ret;
        }
