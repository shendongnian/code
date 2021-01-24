      For Each Items In sellerlist
                    Dim ApiOneItem As GetItemCall = New GetItemCall(Context)
                    ApiOneItem.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)
    
                    Item = ApicallItem.GetItem(Items.ItemID)
                    If Item.Quantity <> 0 Then
                    End if
      Next
