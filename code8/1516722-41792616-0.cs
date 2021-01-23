    class GenericStruct<T> where T : struct
    {
        public void M()
        {
            T temp1 = default(T);
            T temp2 = default(T);
            string s = temp1.ToString();
            Type t = temp1.GetType();
            bool b = temp1.Equals(temp2);
        }
    }
