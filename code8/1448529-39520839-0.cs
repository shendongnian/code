    enter code here
        private void RadTV_Menu_Principal_NodeMouseEnter(object sender, RadTreeViewEventArgs e)
        {
            ///Paint Node when begining focus
            e.Node.BackColor = Color.LightSteelBlue;
            e.Node.GradientStyle = GradientStyles.Solid;
        }
        private void RadTV_Menu_Principal_NodeMouseLeave(object sender, RadTreeViewEventArgs e)
        {
            ///Return the initial color when leave focus
            e.Node.BackColor = SystemColors.Highlight;
        }
