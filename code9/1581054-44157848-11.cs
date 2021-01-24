    public void InvokeUpdateControls()
        {
            if (this.InvokeRequired)
                    
            
            {
                this.Invoke(new UpdateControlsDelegate(currentTrackTime));
            }
            else
            {
                currentTrackTime();
            }
        }
