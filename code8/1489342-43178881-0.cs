        public IEnumerable<int> ListToIenumerable(IEnumerable enumerable)
        {
            List<int> list = new List<int>();
            foreach (object obj in enumerable)
            {
                list.Add(Convert.ToInt32(obj.ToString()));
            }
            IEnumerable<int> returnValue = list.ToArray();
            return returnValue;
        }
