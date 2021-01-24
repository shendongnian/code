    public static string GetLastFour(string str)
    {
        string[] arr = str.Split('.');
        System.Text.StringBuilder lastFour = new System.Text.StringBuilder();
        if (arr.Length >= 4)
        {
            for (int k = arr.Length - 4; k < arr.Length; k++)
            {
                if (k == arr.Length - 1)
                {
                    lastFour.Append(arr[k]);
                }
                else
                {
                    lastFour.Append(arr[k] + ".");
                }
            }
        }
    
        return lastFour.ToString();
    }
