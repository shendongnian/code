    MethodInfo method = this.GetType().GetMethod("B_Click" + i.ToString());
    EventHandler handler = (EventHandler)Delegate.CreateDelegate(typeof(EventHandler), this, method);
    boxes[i].Click += handler;
...
     public void B_Click1(object sender, EventArgs e)
     public void B_Click2(object sender, EventArgs e)
     etc...
