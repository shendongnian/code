    internal void InvokeUIControl(Action action)
        {
            // Call the provided action on the UI Thread using Control.Invoke() does not work in MONO
            //this.Invoke(action);
            // do it manually
            this.lblTemp.Invoke(new Action(() => this.lblTemp.Text = ((MainViewModel)(((Delegate)(action)).Target)).Temperature));
            this.lblTime.Invoke(new Action(() => this.lblTime.Text = ((MainViewModel)(((Delegate)(action)).Target)).Clock));           
        }
