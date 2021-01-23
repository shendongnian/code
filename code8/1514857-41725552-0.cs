    Private Sub DataGridID_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DataGridID.ItemDataBound
    
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
    
            ' Do the mouseover and mouseout javascript
            Dim oBGcolour As String
    
            If e.Item.ItemType = ListItemType.Item Then
                oBGcolour = Right(Hex(DataGridID.ItemStyle.BackColor.ToArgb()), 6)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem Then
                oBGcolour = Right(Hex(DataGridID.AlternatingItemStyle.BackColor.ToArgb()), 6)
            End If
    
            e.Item.Attributes.Add("onmouseover", "this.style.background='#cdcdcd';")
            e.Item.Attributes.Add("onmouseout", "this.style.background='#" & oBGcolour & "';")
    
        End If
    
    End Sub
