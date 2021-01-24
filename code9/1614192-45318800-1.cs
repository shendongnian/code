    int[] paramArray = new int[] { 100, 102, 104, 106 };
    StringBuilder sB = new StringBuilder("SELECT * FROM TABLE WHERE");
    for (int i = 0; i < paramArray.Length - 1; i++)
    {
        if (i > 0)
        {
            sB.Append(" OR");
        }
        sB.Append(" (Amount_USD >= " + paramArray[i].ToString() + " AND Amount_USD < " + (paramArray[i] + 1).ToString() + ")");
    }
    string sQL = sB.ToString();
