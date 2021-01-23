	private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
	{
		bool handled = true;
		if (!Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
		{
			switch (e.Key)
			{
				case Key.F1:
				    {
						Play();
						break;
					}
				// ...
				case Key.F6
					{
						LogOut();
						break;
					}
				default:
					handled = false;
					break;
			}
		}
		else
		{
			switch (e.Key)
			{
				case Key.C:
					{
						Copy();
						break;
					}
				case Key.V:
					{
						Paste();
						break;
					}
				case Key.Z:
					{
						Undo();
						break;
					}
				case Key.Y:
					{
						Redo();
						break;
					}
				default:
					handled = false;
					break;
			}
		}
		e.Handled = handled;
	}
