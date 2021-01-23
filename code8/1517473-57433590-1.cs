    public static int ExtractID(this ListViewGroup group)
        {
            try
            {
                return (int) group
                    .GetType()
                    .GetProperty("ID", BindingFlags.NonPublic | BindingFlags.Instance)
                    .GetValue(group, new object[0]);
            }
            catch 
            {
                return -1;
            }
        }
