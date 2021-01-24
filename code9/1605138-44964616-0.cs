    class MyForm : Form
    {
        ...
        private void MyEventHandler(object sender, ...)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker( () => this.MyEventHandler(sender, ...));
        }
        else
        {
            ProcessMyEvent(...);
        }
