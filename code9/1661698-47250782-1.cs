    var visited = new HashSet<Control>();
    // tricky way to have a recursive lambda
    Action<Control, Action<Control>> visitRecursively = null;
    visitRecursively = (control, visit) => {
       // duplicate control test might be unnecessary
       // but avoids infinite recursion or duplicate events
       if (visited.Contains(control))
          return;
       visited.Add(control);
       visit(control);
       control
       .Controls
       .Cast<Control>()
       .ToList()
       .ForEach(subControl => visitRecursively(subControl, visit));
    };
    Action<Control> addMyHandler = control => {
       TextBox textBox = control as TextBox;
       if (textBox != null)
          textBox.TextChanged += handler;
    };
    visitRecursively(this, addMyHandler);
