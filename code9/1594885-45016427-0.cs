     private void HtmlCtrl_ServerChange(object sender, EventArgs e)
        {
            HtmlControl ctrl = sender as HtmlControl;
            if (ctrl != null)
            {
                this.changedControls.Add(ctrl);
            }
        }
