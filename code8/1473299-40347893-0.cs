        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator obj2val = (CustomValidator) source;
            TextBox ctrl = (TextBox)FindControl(obj2val.ControlToValidate);
            bool is_valid = args.Value != "";
            ctrl.BackColor = is_valid ? System.Drawing.Color.White : System.Drawing.Color.Red;
            updPanel1.Update();
            args.IsValid = is_valid;
        } 
