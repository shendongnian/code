    Public Shared dict As New Collection
    
    Public Function AddTotal(ByVal value as Double, ByVal period As String) As Object
    	
    	Dim subtotal As Double
    	
    	If not dict.Contains(period) Then
    		dict.Add(value, period)
    		subtotal = dict.Item(period)  
    		Return subtotal
    	End If
    	subtotal = dict.Item(period) + value
    	dict.Remove(period)
    	dict.Add(subtotal,period)
    	Return dict.Item(period)
    	
    End Function
