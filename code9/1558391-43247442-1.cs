        List<string> fromTable = new List<string>();  
              
        for (int j = 1; j <= records_in_page.Count; j++)
        {
        string firstName = driver.FindElement(By.XPath(".//*
        [@id = 'injectview'] / div / div / div / table[1] / tbody[" + (j + 1) + 
        "]/tr/td[1]")).Text
        firstNames.Add(firstName)
        }
        public bool  Comparer(List<string> fromTabel, List<string> fromDb)
        {
            bool equals = false;
            if(fromDb.Count().Equals(fromTabel.Count()))
            foreach (var name in fromDb)
            {
                    equals = fromTabel.Any(n => n == name);
                    if(equals == false)
                      return equals
            }
            return equals
        }
