     public string GetBoolMark(string param1)
        {
            bool condition;
            string returnValue = "0";
            if (bool.TryParse(param1, out condition) && condition)
            {
                returnValue = "1";
            }
            return returnValue;
        }
