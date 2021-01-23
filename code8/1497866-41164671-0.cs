    int[] arr = new int[5];
    int  k;
    arr[0] = int.Parse(Console.ReadLine());
    
    List<int> result = new List<int>(arr.Length);
    
    for (int i = 0; i < arr.Length; i++) {
        int num = int.Parse(Console.ReadLine());
        int insertIndex = result.BinarySearch(num);
        if (insertIndex < 0) {
            insertIndex = ~insertIndex;
        }
        result.Insert(insertIndex, num);
    }
    result.CopyTo(arr);
