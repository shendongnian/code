    public int[] moveElement(int[] array, int index)
    {
        int[] save = new int[] { array[index] };
        var rest = array.Take(index).Concat(array.Skip(index + 1));
        return save.Concat(rest).ToArray();
    }
