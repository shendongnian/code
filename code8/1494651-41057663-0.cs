    public static int GetCombinations(int total, int index, int[] list)
    {  
        if (total == 0)
        {
            return 1;
        }
        if(index == n) {
            return 0;
        }
        int ret = 0;
        for(; total >= 0; total -= list[index])
        {
            ret += GetCombinations(total, index + 1, list);
        }
        return ret;
    }
