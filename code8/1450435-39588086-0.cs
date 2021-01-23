    public class Sample
    {
        public Sample()
        {
            UpdateAction = OnUpdate;
        }
    
        Action UpdateAction = null;
    
        private void OnUpdate()
        {
            //some update related stuff
        }
    
    
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            CheckValidation(UpdateAction);
        }
    
        public void CheckValidation(Action action)
        {
            if (txtphysi.Text.Trim() == "")
            {
                lblerrmsg.Visible = true;
                lblerrmsg.Text = "Please Enter Physician Name";
                return;
            }
            action();
        }
    
    }
