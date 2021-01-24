    private static int[] DoWithIf(List<int> list)
    {
        var res = new int[list.Count - 1];
    
        var bounds = Math.Min(res.Length, list.Count)
    
        for (int i = 0; i < bounds; i++)
        {        
            res[i] = list[i];
        }
        return res;
    }
