        // Override is optional to remove unnecessary behavior
        protected override void OnManipulationBoundaryFeedback(ManipulationBoundaryFeedbackEventArgs e)
        {
            // uncomment this to use base class implementation
            //base.OnManipulationBoundaryFeedback(e); 
            e.Handled = true;
        }
