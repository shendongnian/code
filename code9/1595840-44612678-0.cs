    public static void Main()
    {
        int[] list1 = new int[4] { 1, 2, 3, 4 };
        int[] list2 = new int[4] { 5, 6, 7, 8 };
        int[] list3 = new int[4] { 1, 3, 2, 1 };
        int[] list4 = new int[4] { 5, 4, 3, 2 };
        int[][] lists = new int[][] { list1, list2, list3, list4 };
        var size = GetSize(lists);
    }
    public static int GetSize(int[][] items)
    {
        var arrAt0 = items[0].Length;
        var arrAt1 = items[1].Length;
        // Etc...
        return items.Length;
    }
