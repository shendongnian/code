	class EditableLabel
	{
		private string originalText;
		private Label label;
		private TextBox editor;
		public EditableLabel(Label label, TextBox editor)
		{
			this.label = label ?? throw new ArgumentNullException(nameof(label));
			this.editor = editor ?? throw new ArgumentNullException(nameof(editor));
			originalText = label.Text;
			using (Graphics g = label.CreateGraphics())
			{
				this.editor.Width = (int)g.MeasureString("M", this.editor.Font).Width * label.Text.Length;
			}
			editor.LostFocus += (s, e) => SetText();
			editor.KeyUp += (s, e) =>
			{
				if (e.KeyCode == Keys.Enter)
				{
					SetText();
				}
			};
			label.Click += (s, e) =>
			{
				Swap(label, editor);
				this.editor.Focus();
			};
		}
		private void SetText()
		{
			Swap(editor, label);
			string editorText = editor.Text.Trim();
			label.Text = editorText.Length == 0 ? originalText : editorText;
			using (Graphics g = label.CreateGraphics())
			{
				SizeF textSize = g.MeasureString(label.Text, label.Font);
				label.Width = (int)textSize.Width - 4;
			}
		}
		private void Swap(Control original, Control replacement)
		{
			var panel = original.Parent;
			int index = panel.Controls.IndexOf(original);
			panel.Controls.Remove(original);
			panel.Controls.Add(replacement);
			panel.Controls.SetChildIndex(replacement, index);
		}
	}
