    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
    {
        if ( e.KeyCode == Keys.Tab )
        {
            e.Handled = true;
            var dataGrid = (DataGridView) sender;
            var tabIndex = dataGrid.TabIndex;
            var controls = this.Controls.Cast<Control>().Where( r => r.TabIndex > tabIndex );
            if ( controls.Any() )
            {
                controls.OrderBy(r => r.TabIndex).First().Select();
            }
            else
            {
                this.Controls.Cast<Control>()
                             .Where( r => r.TabIndex <= tabIndex )
                             .OrderBy( r => tabIndex )
                             .First()
                             .Select();
            }
        }
    }
