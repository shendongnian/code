        public class PrintableList<T> : List<T>
        {
            public override string ToString()
            {
                string result = "";
                foreach (T obj in this)
                {
                    result += obj.ToString() + "\n";
                }
                return result;
            }
        }
