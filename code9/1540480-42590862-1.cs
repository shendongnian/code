    public static IEnumerable<Control> GetDescendantControls(this Control control)
    {
        Stack<Control> stack = new Stack<Control>();
        stack.Push( control );
        while( stack.Count > 0 )
        {
            Control c = nodes.Pop();
            yield return c;
            foreach( Control child in c.Controls ) stack.Push( child );
        }
    }
    List<Control> allEmptyTextBoxControls = this.GetDescendantControls()
        .OfType<TextBox>()
        .Where( c => String.IsNullOrWhitespace( c.Text ) )
        .ToList();
    foreach(Control c in allEmptyTextBoxControls ) c.Parent.Controls.Remove( c );
