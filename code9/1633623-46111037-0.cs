    int _objectCount = 0;
        public void Put(string key, object value)
        {                          
            int localCount = 0;
            for (int i = 0; i < pArr.Length; i++)
            {
                if (pArr[i] != null)
                {
                    localCount++;
                    if (pArr[i].key == key)
                    { 
                        pArr[i] = new Paar(key, value); 
                        return;
                    }
                }
                if (localCount == _objectCount)
                {
                    return;
                }
            }                      
            for (int i = 0; i < pArr.Length; i++)
            {
                if (pArr[i] == null)
                { 
                    pArr[i] = new Paar(key, value);
                    _objectCount++;
                    return;
                }
                else if (i >= pArr.Length)
                {
                    throw new Exception("All slots full");
                }
            }
        }
