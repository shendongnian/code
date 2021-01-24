    Imports System.Windows.Forms.Design
    
    <Designer(GetType(RTBElektroDesigner))>
    Public Class RTBElektro
        Inherits RichTextBox
    
        Public Sub New()
        End Sub
    End Class
    
    Public Class RTBElektroDesigner
        Inherits System.Windows.Forms.Design.ControlDesigner
    
        Public Overrides ReadOnly Property SelectionRules() As SelectionRules
            Get
                Dim rtb = TryCast(MyBase.Control, RTBElektro)
                If rtb Is Nothing Then
                    Return MyBase.SelectionRules
                Else
                    If rtb.Multiline Then
                        Return SelectionRules.AllSizeable Or
                                SelectionRules.Moveable
                    Else
                        Return SelectionRules.LeftSizeable Or
                                SelectionRules.RightSizeable Or
                                SelectionRules.Moveable
                    End If
                End If
            End Get
        End Property
    End Class
