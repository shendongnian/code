        private void checkBox_AllData_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_AllData.Checked == true)
            {
                AllDataAlertIcon.Visible = true;
                AllDataAlertText.Visible = true;
            }
            if (checkBox_AllData.Checked == false)
            {
                AllDataAlertIcon.Hide();
                AllDataAlertText.Hide();
            }
