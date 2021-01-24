    int[] array = { 2, 1, 3 };
    var ordered = array.OrderBy(x => x);
    foreach (int i in ordered)
    {
        array[1] = 0;
        Debug.Write(i);             // 123
    }
    foreach (int i in ordered)
        Debug.Write(i);             // 023
