    public static void RemoveFromListBox(ListControl listToRmvthings)
        {
            int numberOfIdx = listToRmvthings.Items.Count;
            if (numberOfIdx > 0)
            {
                for (int inc = numberOfIdx - 1; inc >= 0; --inc)
                {
                    listToRmvthings.Items.RemoveAt(inc);
                }
            }
        }
