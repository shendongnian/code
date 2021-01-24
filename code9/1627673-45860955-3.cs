    'Child Form 1
    	Sub BtSumClick(ByVal sender As Object, ByVal e As EventArgs) Handles btSum.Click
            ProcAuxiliar.BaseForm_Sum(Textbox1.Text, Textbox2.Text)
        End Sub
    	
    	'Child Form 2
    	Sub BtDecreaseClick(ByVal sender As Object, ByVal e As EventArgs) Handles BtDecrease.Click
            ProcAuxiliar.BaseForm_decrease(Textbox1.Text, Textbox2.Text)
        End Sub
