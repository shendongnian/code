    Private Sub Repeater1_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles Repeater1.ItemDataBound
        Try
            If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
                If CType(e.Item.FindControl("hdf1"), Label).Text = False Then
                    CType(e.Item.FindControl("rbtDinamic"), RadioButton).Visible = True
                    CType(e.Item.FindControl("rbtDinamic"), RadioButton).GroupName = CType(e.Item.FindControl("groupvalue"), Label).Text = False
                End If
            End If
    
            ' put the proper client-side handler for RadioButton
            Dim radio As RadioButton = CType(e.Item.FindControl("rbtDinamic"), RadioButton)
            Dim script As String = "setExclusiveRadioButton('Repeater1.*[RadioButton_GroupName]', this)"
    
            radio.Attributes.Add("onclick", script)
    
        Catch ex As Exception          
        End Try
    End Sub
