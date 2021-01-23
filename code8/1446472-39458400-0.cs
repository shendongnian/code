    public static readonly string NUMBER_FORMAT_CURRENCY = "$#,##0.00;($#,##0.00)";
    public static readonly string NUMBER_FORMAT_THOUSANDS = "#,##0";
    public static readonly string PERCENTAGE_FORMAT = "0.00%;[Red]-0.00%";
    public static readonly string NUMBER_FORMAT_TEXT = "@";
    public static readonly string NUMBER_FORMAT_DOUBLE = "0.00"; 
    
    . . .
    
    using (var percentageCell = priceComplianceWorksheet.Cells[rowToPopulate, SUMMARY_PERCENTAGE_COL])
    {
        ConvertValueToAppropriateTypeAndAssign(percentageCell, totalPercentage);
        percentageCell.Style.Numberformat.Format = PERCENTAGE_FORMAT;
    }
    
    . . .
    
    // Adapted from https://stackoverflow.com/questions/26483496/is-it-possible-to-ignore-excel-warnings-when-generating-spreadsheets-using-epplu
    public static void ConvertValueToAppropriateTypeAndAssign(this ExcelRangeBase range, object value)
    {
        string strVal = value.ToString();
        if (!String.IsNullOrEmpty(strVal))
        {
            decimal decVal;
            double dVal;
            int iVal;
    
            if (decimal.TryParse(strVal, out decVal))
                range.Value = decVal;
            if (double.TryParse(strVal, out dVal))
                range.Value = dVal;
            else if (Int32.TryParse(strVal, out iVal))
                range.Value = iVal;
            else
                range.Value = strVal;
        }
        else
            range.Value = null;
    }
