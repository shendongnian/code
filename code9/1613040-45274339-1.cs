        protected override void OnLoad( EventArgs e )
        {
            var tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            Controls.Add( tableLayoutPanel );
            // To reset row and columns use this
            // Reset row count and styles
            tableLayoutPanel.RowCount = 0;
            tableLayoutPanel.RowStyles.Clear();
            // Reset columns count and styles
            tableLayoutPanel.ColumnCount = 0;
            tableLayoutPanel.ColumnStyles.Clear();
            // For horizontal alignment we need add empty columns to fill space
            // |___emty fill___|Realcoulmn|___empty fill___|
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add( new ColumnStyle( SizeType.Percent, 100 ) );  // Fill space
            tableLayoutPanel.ColumnStyles.Add( new ColumnStyle( SizeType.AutoSize ) );      // Real column with controls
            tableLayoutPanel.ColumnStyles.Add( new ColumnStyle( SizeType.Percent, 100 ) );  // Fill space
            tableLayoutPanel.SuspendLayout();
            for ( var i = 0; i < 5; i++ )
            {
                AddControl( tableLayoutPanel, 1 );
            }
            tableLayoutPanel.ResumeLayout( true );
        }
        public void IterateOverControls( TableLayoutPanel table )
        {
            // Iterate over all rows
            for ( var i = 0; i < table.RowCount; i++ )
            {
                var control = table.GetControlFromPosition( 1, i ); // Column 1
            }
        }
        public void AddControl( TableLayoutPanel tableLayoutPanel, int column )
        {
            var btn = new Button { Text = "Hello vertical stack!" };
            btn.Click += button_Click;
            // Add row to tableLayoutPanel and set it style
            tableLayoutPanel.RowCount++;
            tableLayoutPanel.RowStyles.Add( new RowStyle( SizeType.Absolute, btn.Height + 5 ) );
            // Add control to stack
            tableLayoutPanel.Controls.Add( btn, column, tableLayoutPanel.RowCount - 1 );
        }
        private void button_Click( object sender, EventArgs e )
        {
            var btnControl = sender as Control;
            if ( btnControl == null )
                return;
            var tableLayoutPanel = btnControl.Parent as TableLayoutPanel;
            if ( tableLayoutPanel == null )
                return;
            AddControl( tableLayoutPanel, 1 );
        }
    }
