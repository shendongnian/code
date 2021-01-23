    float b1=0;
    if(float.TryParse(ExcelWorkSheet.Cells[4, 5].Text, out b1))
    {
        tried add .ToString = the same result 
    }
    else
    {
        throw exception;
    }
    if(float.TryParse(ExcelWorkSheet.Cells[4, 5].Text.ToString(), out b1))
    {
        then to do something;
    }
    else
    {
        throw exception;
    }
