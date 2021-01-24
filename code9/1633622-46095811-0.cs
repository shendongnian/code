    public static void Put(string key, object value)
    {
        int insertionIndex = -1;
        for (int i = 0; i < pArr.Length; i++)
        {
            if (pArr[i] != null)
            {
                if (pArr[i].Key == key)
                {
                    insertionIndex = i;
                    break;
                }
            }
            else if (insertionIndex < 0)
            {
                insertionIndex = i;
            }
        }
        if (insertionIndex < 0)
        {
            throw new Exception("All slots full");
        }
        else
        {
            pArr[insertionIndex] = new Paar(key, value);
        }
    }
