    public List<string> GetListOfDifferentVariables(string propertyName)
        {
            List<string> listOfResults = new List<string>();
            foreach (Product prod in listOfProducts)
            {
                string propertyValue = (string)prod.GetType().GetProperty(propertyName).GetValue(prod);
                if (listOfResults.Contains(propertyValue.ToLower()) == false)
                    listOfResults.Add(propertyValue.ToLower());
            }
            return listOfResults.Distinct().ToList();
        }
