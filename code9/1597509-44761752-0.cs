     private string MakeTheType()
        {
            string inList = string.Empty;
            List<string> docType = new List<string>();
            foreach (RadListBoxItem item in rlbDocuments.Items)
            {
                string value = item.Value;
                if (item.Checked)
                {
                    docType.Add(value);
                }
            }
           int intHowMany = docType.Count;
           if (intHowMany == 1)
           {
               inList = "'" + docType.ElementAt(0) + "'";
               return inList;
           }
           else if (intHowMany >= 2)
           {
               inList = "'" + String.Join("','", docType.Take(intHowMany)) + "'";
               return inList;
           }
           else
               return null;
            
        }
