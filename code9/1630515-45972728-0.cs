    Public Class TB : Inherits TextBox
    	Public Sub New()
    		SetStyle(ControlStyles.Selectable, False)
    	End Sub
    
    	Public Property Selectable As Boolean
    		Get
    			Return GetStyle(ControlStyles.Selectable)
    		End Get
    		Set(value As Boolean)
    			SetStyle(ControlStyles.Selectable, value)
    		End Set
    	End Property
    
    	Private Const WM_MOUSEACTIVATE As Integer = &H21
    	Private Const NOACTIVATEANDEAT As Integer = &H4
    
    	 Protected Overrides Sub WndProc(ByRef m As Message)
    		If m.Msg = WM_MOUSEACTIVATE AndAlso Not Me.Selectable Then
    			m.Result = New IntPtr(NOACTIVATEANDEAT)
    			Return
    		End If
    		MyBase.WndProc(m)
    	 End Sub
    End Class
