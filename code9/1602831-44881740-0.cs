      ToolStripSeparator toolStripSeparator = new ToolStripSeparator()
                {
                    Alignment = ToolStripItemAlignment.Left,
                    Overflow = ToolStripItemOverflow.Never,
                    BackColor = Color.White
                };
                toolStrip1.Items.Add(toolStripSeparator);
    
                ToolStripControlHost toolStripControl = new ToolStripControlHost(mainFiltersControl)
                {
                    Alignment = ToolStripItemAlignment.Left,
                    Overflow = ToolStripIte`enter code here`mOverflow.Always,
                    BackColor = Color.White,
                    Dock = DockStyle.Fill
                };
                toolStrip1.Items.Add(toolStripControl);
        
    
                ToolStripButton toolStripButton = new ToolStripButton(Messages.AdditionalFiltersTitle)
                {
                    Alignment = ToolStripItemAlignment.Right,
                    Overflow = ToolStripItemOverflow.Never,
                    ToolTipText = Messages.AdditionalFiltersTooltipDisabled,
                    BackCol`enter code here`or = Color.White
                };
                toolStripButton.Click += additionalFiltersButton_Click;
    
                toolStrip1.Items.Add(toolStripButton);
