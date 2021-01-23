    private void timer1_Tick(object sender, EventArgs e)
        {
            string ls_status = "";
            var currentSecond = DateTime.Now.Second;
            ls_status = "Current second: " + currentSecond.ToString() + " starting on: " + Il_offset.ToString();
            lbl_status.Text = ls_status;
            if (currentSecond == Il_offset && Ib_processing_completed)
            {
                //Main processing method
                ue_action();
            }
        }
