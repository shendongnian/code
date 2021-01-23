                var myMenu = new ContextMenuStrip(); // works also with tool strip menus, main menu, etc...
				int m = 0;
				if( /* has option A */ )
				{
		         myMenu.Items.Add("Option A");
		         myMenu.Items[m++].Click += OptionA_Click;
				}
				if( /* has option B */ )
				{
		         myMenu.Items.Add("Option B");
		         myMenu.Items[m++].Click += OptionB_Click;
				}
				if( /* has option C or D */ )
				{
		         myMenu.Items.Add(new ToolStripSeparator());
			     m++;
				}
				if( /* has option C */ )
				{
		         myMenu.Items.Add("Option C");
		         myMenu.Items[m++].Click += OptionC_Click;
				}
				if( /* has option D */ )
				{
		         myMenu.Items.Add("Option D");
		         myMenu.Items[m++].Click += OptionD_Click;
				}
				if( /* has option E */ )
				{
		         myMenu.Items.Add(new ToolStripSeparator());
		         myMenu.Items.Add("Option E");
		         myMenu.Items[++m].Click += OptionE_Click;
				}
