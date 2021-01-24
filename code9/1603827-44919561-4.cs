        private List<string> getSubGroupPerID()
        {
            List<string> outcome = new List<string>();
            if (getSubGroupsBelongingToUser().Contains(1))
            {
                outcome.Add("Apple");
            }
            if (getSubGroupsBelongingToUser().Contains(2))
            {
                outcome.Add("Oranges");
            }
            if (getSubGroupsBelongingToUser().Contains(3))
            {
                outcome.Add("Pineapples");
            }           
            if(outcome.Count == 0)
            {
                outcome.Add("All");
            }
            return outcome;
        }
