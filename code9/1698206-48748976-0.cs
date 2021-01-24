    private void ValidateArray(string which, int[] array)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array), $"Array {which} is NULL.");
        }
    
        if (array.Length == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(array), $"Array {which} length can't be smaller that 1");
        }
    }
