      public string FindParentsOfGrandChildren(string _name)
        {
            List<PopulationUSA> parents = Items.Where(s => s.Items.Any(c => c.Name == _name)).ToList();
            if (parents != null)
            {
                string listparents = string.Empty;
                for (int i = 0; i < parents.Count; i++)
                {
                    if (i == 0)
                    {
                         listparents += parents[i].Name;
                    }
                    else
                    {
                        listparents += ", " + parents[i].Name;
                    }
                }
                return listparents;
            }
            else
            {
                return "Not found";
            }
        }
