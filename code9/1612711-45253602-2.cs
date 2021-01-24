    Public Class PerformanceForm
    
        Sub New()
            ' This call is required by the designer. '
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call. '
            PrimaryWeightNumsAr = {num_Primary_Billing, num_Primary_Rutine, num_Primary_Seker, num_Primary_Sla}
        End Sub
        Private PrimaryWeightNumsAr() As NumericUpDown
    
        Private Sub PrimaryWeightsValueChanged()
    	
            If PrimaryWeightNumsAr Is Nothing Then Exit Sub
    		' do other stuff... '
    		
        End Sub
    
    End Class
