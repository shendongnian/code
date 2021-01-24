        bool isChecked = false;
        private void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {
            if (barEditItem1.EditValue.ToString() == "False")
            {
               isChecked = false;
            }
            else
            {
               isChecked = true;
            }
        }
