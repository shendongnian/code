    public void Put(string key, object value)
    {
        for (int i = 0; i < getArray.Length; i++)
        {
            if (getArray[i] != null && getArray[i].key == key)
            {
                getArray[i] = new Paar(key, value);
                return;
            }         
        }
        for (int i = 0; i < getArray.Length; i++)
            {
                if (getArray[i] == null)
                {
                    getArray[i] = new Paar(key, value);
                    break;
                }
                else
                {
                    if (i >= getArray.Length)
                    {
                        throw new Exception("All slots full");
                    }
                }
            }
        }
