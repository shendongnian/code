    Imports System.ComponentModel
    Imports System.ComponentModel.Design
    
    Public Class HUDForm : Inherits Form
    
    	<TypeConverter(GetType(OpacityConverter2))>
    	 <Browsable(True)>
    	 <Category("Window Style")>
    	 <Description("The opacity level of this HUDForm.")>
    	 <EditorBrowsable(EditorBrowsableState.Always)>
    	 Public Shadows Property Opacity As Double
    		  Get
    				Return MyBase.Opacity
    		  End Get
    		  Set(ByVal value As Double)
    				If (value >= 1.0R) Then
    					 value = 0.99R
    				End If
    				MyBase.Opacity = value
    		  End Set
    	 End Property
    End Class
