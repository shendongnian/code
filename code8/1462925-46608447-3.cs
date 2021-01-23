    protected override void OnManipulationBoundaryFeedback(ManipulationBoundaryFeedbackEventArgs e)
    {
    	Debug.WriteLine("OnManipulationBoundaryFeedback");
    }
    
    private void MyControl_ManipulationBoundaryFeedback(object sender, ManipulationBoundaryFeedbackEventArgs e)
    {
    	Debug.WriteLine("MyControl_ManipulationBoundaryFeedback");
    }
