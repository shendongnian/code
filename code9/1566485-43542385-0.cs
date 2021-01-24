    public static List<int> RemoveSmallest(List<int> numbers)
    {
        var lowestIndex = -1;
        var lowest = 0;
        for (var i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] < lowest) {
                lowest = numbers[i];
                lowestIndex = i;
            }
        }
        var newList = new List<int>(numbers);
        newList.RemoveAt(lowestIndex);
        return newList;
}
