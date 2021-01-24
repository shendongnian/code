        public void OnChange(Office.IRibbonControl control, string text)
        {
            try
            {
                switch (control.Id)
                {
                    case "cbo_Division":
                        ribbon.InvalidateControl("cbo_Category");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
