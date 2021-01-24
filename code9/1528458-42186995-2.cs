    MethodInfo method = this.GetType().GetMethod("B_Click" + i.ToString());
    boxes[i].Click += (o,e) =>
    {
        if (null != method)
        {
            method.Invoke(this, new object[2] { o, e });
        }
    };
...
     public void B_Click1(object sender, EventArgs e)
     public void B_Click2(object sender, EventArgs e)
     etc...
