    var maxStockId = stockv.Max(x => x.Id);
    var stockGetWithId = stockv.Find(x => x.Id == maxStockId);
    var SystemStockNo = stockGetWithId.SystemStockNo;
    if (SystemStockNo != null && SystemStockNo.Length == 7)
    {
    var lastFourDigits = SystemStockNo.Substring(SystemStockNo.Length - 4);
    var incrementlastFourDigits = Numerics.GetInt(lastFourDigits) + 1;
    var newStockNoWithZeros = string.Format("{0:0000}", incrementlastFourDigits);
    st.SystemStockNo = customerCompanyName.Substring(0, 1).ToUpper() + DateTime.Now.ToString("MM") + newStockNoWithZeros.ToString();
    }
    else
    {
    st.SystemStockNo = customerCompanyName.Substring(0, 1).ToUpper() + DateTime.Now.ToString("MM") + "0001";
    }
