    Imports System.ComponentModel
    
    Public Class myDocDesigner
      Inherits System.Windows.Forms.Design.DocumentDesigner
    
    	Private Property Opacity As Double
    		Get
    				Return CDbl(MyBase.ShadowProperties.Item("Opacity"))
    		End Get
    		Set(ByVal value As Double)
    		If (value >= 0.99R) Then
    				value = 0.99R
    		End If
    
    				MyBase.ShadowProperties.Item("Opacity") = value
    		End Set
    	End Property
    
    	Protected Overrides Sub PreFilterProperties(ByVal properties As IDictionary)
    		Dim descriptor As PropertyDescriptor
    		MyBase.PreFilterProperties(properties)
    		Dim strArray As String() = New String() {"Opacity"}
    		Dim attributes As Attribute() = {}
    		Dim i As Integer
    		For i = 0 To strArray.Length - 1
    				descriptor = DirectCast(properties.Item(strArray(i)), PropertyDescriptor)
    				If (Not descriptor Is Nothing) Then
    					properties.Item(strArray(i)) = TypeDescriptor.CreateProperty(GetType(myDocDesigner), descriptor, attributes)
    				End If
    		Next i
    	End Sub
    End Class
