    <ParseChildren(True)>
    Public Class MyUserCtrl
        Inherits Control
        
        Private plhFirst As PlaceHolder
        
        <TemplateInstance(TemplateInstance.Single),
         PersistenceMode(PersistenceMode.InnerProperty)>
        Public Property FirstTemplate As ITemplate
        
        Private Sub Page_Init(sender As Object, e As EventArgs) Handles MyBase.Init
            plhFirst = New PlaceHolder()
            Controls.Add(plhFirst)
            
            If FirstTemplate IsNot Nothing Then
                FirstTemplate.InstantiateIn(plhFirst)
            End If
        End Sub
        
        Protected Overrides Sub Render(writer As HtmlTextWriter)
            ' <div class="myUserCtrl">
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "myUserCtrl")
            writer.RenderBeginTag(HtmlTextWriterTag.Div)
            
            ' <div class="firstControls">
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "firstControls")
            writer.RenderBeginTag(HtmlTextWriterTag.Div)
            
            plhFirst.RenderControl(writer)
            
            ' </div>
            writer.RenderEndTag()
            
            ' </div>
            writer.RenderEndTag()
        End Sub
    End Class
