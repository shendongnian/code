	public class ColorListControl : ListView
	{
		public event EventHandler SelectedColorChanged;
		private Color selectedColor = Color.None;
		[DefaultValue( Color.None )]
		public Color SelectedColor
		{
			get { return selectedColor; }
			set
			{
				if( selectedColor != value )
				{
					selectedColor = value;
					foreach( ListViewItem item in this.Items )
					{
						Color itemColor = (Color)item.Tag;
						if( itemColor == Color.None ) //see http://stackoverflow.com/questions/15436616
							item.Checked = value == Color.None;
						else
							item.Checked = value.HasFlag( itemColor );
					}
					SelectedColorChanged?.Invoke( this, EventArgs.Empty );
				}
			}
		}
		public ColorListControl()
		{
			this.CheckBoxes = true;
			this.HeaderStyle = ColumnHeaderStyle.None;
			this.View = View.List;
			foreach( Color value in Enum.GetValues( typeof( Color ) ).Cast<Color>() )
			{
				this.Items.Add( new ListViewItem()
				{
					Name = value.ToString(),
					Text = value.ToString(),
					Tag = value
				} );
			}
		}
		protected override void OnItemChecked( ItemCheckedEventArgs e )
		{
			base.OnItemChecked( e );
			Color checkedColor = (Color)e.Item.Tag;
			if( e.Item.Checked )
				SelectedColor |= checkedColor;
			else
				SelectedColor &= ~checkedColor;
		}
	}
