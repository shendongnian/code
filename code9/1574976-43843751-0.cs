        private void toolStripButtonFloodMaps_Click(object sender, EventArgs e)
    {
        SetChildVisibleForPanel(typeof(FloodMaps), splitContainer1.Panel2);
    }
        static void SetChildVisibleForPanel(Type visChildType, Panel pnl)
        {
            if (pnl.Controls.Count==0)
            {
                //Create your controls with Visible=false;
            }
            foreach (Control ctl in pnl.Controls)
            {
                ctl.Visible = (ctl.GetType() == visChildType);
            }
        }
