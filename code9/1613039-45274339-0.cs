        protected override void OnLoad( EventArgs e )
        {
            var tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
            };
            Controls.Add( tableLayoutPanel );
            // To reset row and columns use this
            // Reset row count and styles
            tableLayoutPanel.RowCount = 0;
            tableLayoutPanel.RowStyles.Clear();
            // Reset columns count and styles
            tableLayoutPanel.ColumnCount = 0;
            tableLayoutPanel.ColumnStyles.Clear();
            // Add one columns for our stack
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add( new ColumnStyle( SizeType.AutoSize ) );
            tableLayoutPanel.SuspendLayout();
            for ( var i = 0; i < 5; i++ )
            {
                var text = new TextBox { Text = "Hello vertical stack!" };
                // Add row to tableLayoutPanel and set it style
                tableLayoutPanel.RowCount++;
                tableLayoutPanel.RowStyles.Add( new RowStyle( SizeType.Absolute, text.Height ) );
                // Add control to stack
                tableLayoutPanel.Controls.Add( text, 0, i );
            }
            tableLayoutPanel.ResumeLayout( true );
        }
