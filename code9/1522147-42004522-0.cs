        public bool GetEnabled(Office.IRibbonControl control)
        {
            bool active = true;
            string Appointment_body = control.Context.CurrentItem.Body;
            if (!string.IsNullOrEmpty(Appointment_body) && !Appointment_body.Equals(" "))
            {
                active = false;
            }
            return active;
        }
        public void OnAddLinktButton(Office.IRibbonControl control)
        {
            try
            {
                var inspec = this.Application.ActiveInspector().CurrentItem;
                if (inspec is Outlook.AppointmentItem)
                {
                    Appointment_Value gapp = new Appointment_Value(true, inspec, ribbon);
                    gapp.Show();
                }
            }
            catch (Exception ex)
            {
                Logger.Info("The following error occurred: " + ex.Message);
            }
        }
