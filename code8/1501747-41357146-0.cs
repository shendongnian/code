    public string AddSignToDate(string date)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < date.Length; i++)
            {
                if (i == 4)
                {
                    sb.Append("/" + date[i]);
                }
                else if (i == 6)
                {
                    sb.Append("/" + date[i]);
                }
                else
                {
                    sb.Append(date[i]);
                }                
            }
            return sb.ToString();
        }  
