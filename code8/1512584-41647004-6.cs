    Imports System.Drawing.Design
    Imports System.Windows.Forms.Design
    Imports System.Windows.Forms
    Imports System
    
    Public Class OpacityEditor : Inherits UITypeEditor
    	Dim editorservice As IWindowsFormsEditorService = Nothing
    
    	Public Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, _
    													ByVal provider As System.IServiceProvider, _
    													ByVal value As Object) As Object
    
    		If (provider IsNot Nothing) Then
    			editorservice = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)
    		End If
    
    		If editorservice Is Nothing Then
    			Return MyBase.EditValue(context, provider, value)
    		Else
    			Dim editorcontrol As New NumericUpDown
    
    			With editorcontrol
    				.Minimum = 0
    				.Maximum = 0.99D
    				.DecimalPlaces = 2
    				.Increment = 0.05D
    				.Value = CDec(value)
    			End With
    
    			' Display the editing control.
    			editorservice.DropDownControl(editorcontrol)
    
    			Return CDbl(editorcontrol.Value)
    
    		End If 'editorservice Isnot Nothing
    
    	End Function ' EditValue
    
    	Public Overrides Function GetEditStyle(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.Drawing.Design.UITypeEditorEditStyle
    		Return UITypeEditorEditStyle.DropDown
    	End Function
    End Class
