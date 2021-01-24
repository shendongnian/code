    Protected Sub DayButton_Click(sender As Object, e As EventArgs)
        Dim TR As New HtmlTableRow
        Dim TD1 As New HtmlTableCell
        TD1.Attributes.Add("style", "text-align:right;")
        TD1.InnerHtml = "<p>Day " & txtLeaveTakenDays.Text & " : </p>"
        Dim TD2 As New HtmlTableCell
        Dim TB As New TextBox
        TB.ID = "DayDateDay" & txtLeaveTakenDays.Text
        TB.Attributes.Add("style", "text-align:center;")
        TB.Width = 210
        TB.Text = txtLeaveTakenDays.Text
        TD2.Controls.Add(TB)
        TR.Controls.Add(TD1)
        TR.Controls.Add(TD2)
        DayTable.Controls.Add(TR)
    End Sub
