    Label[] IbItemName = new Label[YourList.Count];
    Label[] IbIQuantity = new Label[YourList.Count];
    for(int i = 0; i < YourList.Count; i++){
       IbItemName[i] = new Label { Text = YourList[i].Name };
       IbIQuantity[i] = new Label { Text = YourList[i].Quantity.ToString() };
    }
