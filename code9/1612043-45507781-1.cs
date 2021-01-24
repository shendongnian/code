        public string GetModelStateErrors(ModelStateDictionary ms)
        {
            StringBuilder errors = new StringBuilder();
            foreach (string k in ms.Keys)
            {
                if (ms[k].Errors.Count > 0)
                {
                    errors.Append($"\n{k}:\n");
                    foreach (var e in ms[k].Errors)
                    {
                        errors.Append($"   {e.ErrorMessage}\n");
                    }
                }
            }
            return errors.ToString();
        }
 
 
