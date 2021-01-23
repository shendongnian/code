        private void btn_start_Click(object sender, EventArgs e)
        {
            //new added code
            if (btn_start.Text == "Start")
            {
                btn_start.Text = "Pause";
                sorting = true;
                sort();
            }
            else if (btn_start.Text == "Pause")
            {
                btn_start.Text = "Continue"; // '= "Start"' in the old code
                tmr_sorting.Stop();
                sorting = false;
            } 
            // new added code
            else if (btn_start.Text == "Continue")
            {
                btn_start.Text = "Pause";
                sorting = true;
            }
        }
