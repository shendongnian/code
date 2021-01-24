    public static IEnumerable<TControl> GetAllChildControls<TControl>(this Control control) where TControl : Control
{
        var children = (control.Controls != null) ? control.Controls.OfType<TControl>() : Enumerable.Empty<TControl>();
        return children.SelectMany( c => GetAllChildControls<TControl>(c)).Concat( children );
    }
    List<Control> allEmptyTextBoxControls = this.GetAllChildControls()
        .OfType<TextBox>()
        .Where( c => c => String.IsNullOrEmpty( c.Text ) )
        .ToList();
    foreach(Control c in allEmptyTextBoxControls ) c.Parent.Controls.Remove( c );
