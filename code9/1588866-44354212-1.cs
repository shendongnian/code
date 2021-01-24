    Public Delegate Sub _TAXCALC(itemname As String, rackrate As Double, discountedrate As Double, billdate As Date)
    Public Sub TAXCALC(itemname As String, rackrate As Double, discountedrate As Double, billdate As Date)
    	If BodyGridView.InvokeRequired Then
    		BodyGridView.Invoke(New _TAXCALC(AddressOf TAXCALC), itemname, rackrate, discountedrate, billdate)
    	Else
    		'Your code here'
    	End If
    End Sub
