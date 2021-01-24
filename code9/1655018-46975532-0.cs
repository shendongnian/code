    Imports System.Web.UI
    Imports System.Web.UI.WebControls
    Public Class PasswordTextBox
          Inherits TextBox
          Implements IPostBackDataHandler
    Public Sub New()
        TextMode = TextBoxMode.Password
    End Sub
    Public Property Password As String
        Get
            Dim s As String = CType(ViewState("Password"), String)
            If s Is Nothing Then Return ""
            Return s
        End Get
        Set(value As String)
            ViewState("Password") = value
        End Set
    End Property
    Private Const DEFAULT_PASSWORD As String = "********************"
    Public Overrides Property Text() As String
        Get
            If Password = "" Then Return ""
            Return DEFAULT_PASSWORD
        End Get
        Set
            MyBase.Text = DEFAULT_PASSWORD
            Attributes("value") = DEFAULT_PASSWORD
        End Set
    End Property
    Protected Overrides Sub OnPreRender(e As EventArgs)
        MyBase.OnPreRender(e)
        Attributes("value") = Text
    End Sub
    Protected Overrides Sub Render(ByVal output As System.Web.UI.HtmlTextWriter)
        MyBase.Render(output)
    End Sub
    Public Overridable Shadows Function LoadPostData(postDataKey As String, postCollection As System.Collections.Specialized.NameValueCollection) As Boolean Implements IPostBackDataHandler.LoadPostData
        Dim presentValue As String = Password
        Dim postedValue As String = postCollection(postDataKey)
        If presentValue Is Nothing OrElse Not presentValue.Equals(postedValue) Then
            If postedValue <> DEFAULT_PASSWORD Then Password = postedValue
            Return True
        End If
        Return False
    End Function
    End Class
