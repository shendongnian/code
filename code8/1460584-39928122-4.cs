	private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
	{
		switch (e.Key)
		{
			// Enable copy/paste and selection of all text.
			case Key.C:
			case Key.V:
			case Key.A:
				if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
					return;
				break;
			// Enable keyboard navigation/selection.
			case Key.Left:
			case Key.Up:
			case Key.Right:
			case Key.Down:
			case Key.PageUp:
			case Key.PageDown:
			case Key.Home:
			case Key.End:
				return;
		}
		e.Handled = true;
	}
