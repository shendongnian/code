    private static void LoopData(List<Data> data, int startItemId, int endItemId)
    {
        for(int i = 0; i < data.Count; i++)
        {
            if(!data[i].Processed &&
                data[i].ItemId >= startItemId && 
                data[i].ItemId <= endItemId)
            {
                //            
                data[i].Processed = True;
            }
        }
    }
