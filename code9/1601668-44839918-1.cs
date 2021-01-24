        public override string ToString()
        {
            string result = "";
            foreach (System.Reflection.PropertyInfo p in this.GetType().GetProperties())
            {
                if (!string.IsNullOrEmpty(result)) result += Environment.NewLine;
                result += p.Name + ": " + p.GetValue(this);
            }
            return result;
        }
