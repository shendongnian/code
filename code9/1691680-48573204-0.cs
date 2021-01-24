		static void TreeView_HandleMouseButtonDown_shim(TreeView @this)
		{
			// Fix as seen in: https://developercommunity.visualstudio.com/content/problem/190202/button-controls-hosted-in-popup-windows-do-not-wor.html
			if (!@this.IsKeyboardFocusWithin)
			{
				// BEGIN NEW LINES OF CODE
				var keyboardFocusedControl = Keyboard.FocusedElement;
				var focusPathTrace = keyboardFocusedControl as DependencyObject;
				while (focusPathTrace != null)
				{
					if (ReferenceEquals(@this, focusPathTrace))
						return;
					focusPathTrace = VisualTreeHelper.GetParent(focusPathTrace) ?? LogicalTreeHelper.GetParent(focusPathTrace);
				}
				// END NEW LINES OF CODE
				var selectedContainer = (System.Windows.Controls.TreeViewItem)TreeView_selectedContainer_field.GetValue(@this);
				if (selectedContainer != null)
				{
					if (!selectedContainer.IsKeyboardFocused)
						selectedContainer.Focus();
				}
				else
				{
					// If we don't have a selection - just focus the treeview
					@this.Focus();
				}
			}
		}
