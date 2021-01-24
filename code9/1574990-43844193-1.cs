    YourItemSourceType temp = YourDataGridItmesSource.Where(ThatItemYouWant => ThaItemYouWant.PartNumber == InputPartNumber).FirstOrDefault();
    //①:Get the item with specific Part Number.
    //use'?.' in case there is no match for InputPartNumber.
    if(temp?.Qty !< 0)
    {
        temp.Qty --;
        NotifyTheChange();
        //update your view  if you need to update it manually
    }
    else
        CalculateTheItemPositionAndPaintItGreen();
        //②
