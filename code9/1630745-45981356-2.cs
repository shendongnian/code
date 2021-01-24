     public void Put(string key, object value)
     {
        for (var i = 0; i < getArray.Length; ++i)
        {
            if (getArray[i] == null || getArray[i].key == key)
            {
                getArray[i] = new Paar(key, value);
                break;
            }
            if(i == getArray.Length - 1)
                throw new Exception("All slots full");
        }
     }
