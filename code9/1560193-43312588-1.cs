        public MyModel GetBy(string name, string value)
        {
            var getter = typeof(MyModel).GetProperty(name).GetGetMethod();
            return GetAll().SingleOrDefault(d => 
                string.Equals(getter.Invoke(d, null).ToString(), value, StringComparison.OrdinalIgnoreCase));
        }
