        Public Class Textarea
        Inherits System.Web.UI.HtmlControls.HtmlTextArea
        Private m_sExtraStuff As String = ""
        Public Property ExtraStuff As String
            Get
                Return m_sExtraStuff
            End Get
            Set(value As String)
                m_sExtraStuff = value
            End Set
        End Property
        Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
            writer.Write("<textarea ")
            writer.Write(m_sExtraStuff)
            writer.Write("></textarea>")
        End Sub
    End Class
