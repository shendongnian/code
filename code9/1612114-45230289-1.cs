    Dim ListItems As New List(Of String)()
    For Each el_loopVariable As ListViewItem In shipments.Items
	    Dim checkBox As CheckBox = TryCast(el_loopVariable.FindControl("chk"), CheckBox)
    	If checkBox IsNot Nothing AndAlso checkBox.Checked Then
	    	ListItems.Add(checkBox.ToolTip)
    	End If
    Next
