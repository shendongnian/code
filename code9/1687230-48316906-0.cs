    public sealed class CustomMediaTransportControls : MediaTransportControls
    {
        private DispatcherTimer KeepTransportControlsVisibleTimer;
        private Border ControlPanelGrid;
    
        public CustomMediaTransportControls()
        {
            this.DefaultStyleKey = typeof(CustomMediaTransportControls);
            KeepTransportControlsVisibleTimer = new DispatcherTimer();
            KeepTransportControlsVisibleTimer.Interval = TimeSpan.FromMilliseconds(200);
            KeepTransportControlsVisibleTimer.Tick += KeepTransportControlsVisibleTimer_Tick;
            KeepTransportControlsVisibleTimer.Start();
        }
              
        private void KeepTransportControlsVisibleTimer_Tick(object sender, object e)
        {
            var opacity = ControlPanelGrid.Opacity;
            System.Diagnostics.Debug.WriteLine(opacity);
             // do some stuff
        }  
   
        //overriding OnApplyTemplate
        protected override void OnApplyTemplate()
        {
            ControlPanelGrid = GetTemplateChild("ControlPanel_ControlPanelVisibilityStates_Border") as Border; 
            base.OnApplyTemplate();  
        }
    }
    
