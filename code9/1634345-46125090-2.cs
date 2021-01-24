        Public Class Textarea
        Inherits System.Web.UI.HtmlControls.HtmlTextArea
        Private m_sSpecialID As String = ""
        Private m_sSpecialClass As String = ""
        Public Property SpecialID As String
            Get
                Return m_sSpecialID
            End Get
            Set(value As String)
                m_sSpecialID = value
            End Set
        End Property
        Public Property SpecialClass As String
            Get
                Return m_sSpecialClass
            End Get
            Set(value As String)
                m_sSpecialClass = value
            End Set
        End Property
        Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
            writer.Write("<textarea :class=""")
            writer.Write(m_sSpecialClass)
            writer.Write(""" :id=""")
            writer.Write(m_sSpecialID)
            writer.Write("""></textarea>")
        End Sub
    End Class
