    var list = new List<int> { 1, 3, 7, 13, 20, 54 };
    var numToSearch = 54;
    int point1 = int.MinValue, point2 = int.MinValue;
    var inx = list.BinarySearch(numToSearch); //<---
    if (inx >= 0) //search item is in the list
    {
        if (inx == 0)
        {
            point1 = list[0];
            point2 = list[1];
        }
        else if (inx == list.Count - 1)
        {
            point1 = list[inx - 1];
            point2 = list[inx];
        }
        else
        {
            int val1 = list[inx - 1];
            int val2 = list[inx + 1];
            if (Math.Abs(val1 - list[inx]) < Math.Abs(list[inx] - val2))
            {
                point1 = list[inx - 1];
                point2 = list[inx];
            }else
            {
                point1 = list[inx];
                point2 = list[inx+1];
            }
        }
    }
    else {
        point1 = list[~inx - 1];
        point2 = list[~inx];
    }
