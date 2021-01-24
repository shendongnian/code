    private void KeepSelectedColumns<T>(List<T> OperateList) where T : MyObject
    {
            List<string> ToBeRemoved = new List<string>();
            foreach (T fVal in OperateList)
            {
                // error in fVal.Columns
                foreach (DictionaryEntry Col in fVal.Columns)
                {
                }
            }
    }
 
