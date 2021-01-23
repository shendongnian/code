	public class ColorListControl : CheckedListBox
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
					for( int i = 0; i < this.Items.Count; i++ )
					{
						Color itemColor = (Color)this.Items[i];
						if( itemColor == Color.None )
							this.SetItemChecked( i, value == Color.None );
						else
							this.SetItemChecked( i, value.HasFlag( itemColor ) );
					}
					SelectedColorChanged?.Invoke( this, EventArgs.Empty );
				}
			}
		}
		public ColorListControl()
		{
			foreach( Color value in Enum.GetValues( typeof( Color ) ) )
				this.Items.Add( value );
		}
		protected override void OnItemCheck( ItemCheckEventArgs ice )
		{
			base.OnItemCheck( ice );
			Color checkedColor = (Color)this.Items[ice.Index];
			if( ice.NewValue == CheckState.Checked )
				SelectedColor |= checkedColor;
			else
				SelectedColor &= ~checkedColor;
		}
	}
