    public int ArrayProduct(int[] array)
    {
       int p = 1;
       for(int i = 0; i < array.Length; i++)
       {
           p *= array[i];
       }
       return p;
    }
