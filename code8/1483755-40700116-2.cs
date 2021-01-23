    private void sorted(List<int> arr)
    {
        int temp = 0;
        for (int write = 0; write < arr.Count; write++)
        {
            for (int sort = 0; sort < arr.Count - 1; sort++)
            {
                if (arr[sort] > arr[sort + 1])
                {
                    temp = arr[sort + 1];
                    arr[sort + 1] = arr[sort];
                    arr[sort] = temp;
                }
            }
        }
        lstHoldValue.Items.Clear();
        for (int i = 0; i < arr.Count; i++)
            lstHoldValue.Items.Add("\t" + arr[i]);
    }
