        string retval = string.Empty;
            foreach (var property in pi)
            {
                if (!(property.Name.ToLower().Equals(prop.ToLower())))
                    {
                       continue; //jump out of this iteration and go to the next                  
                    }
                retval = property.GetValue(prop).ToString();              
            }
            return retval;
