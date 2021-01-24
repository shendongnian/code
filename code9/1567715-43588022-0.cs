    int sum = 0;
    int outVal = 0;
    foreach (DataRow dr in dt.Rows)
    {
        if (!String.IsNullOrEmpty(dr["Hr"].ToString()))
        {
            if (Int32.TryParse(dr["Hr"].ToString(), out outVal))
            {
                sum += outVal;
            }
        }
    }
