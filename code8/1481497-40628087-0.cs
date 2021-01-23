    // Paste this snippet in the beginning of your method
    if (InvokeRequired)
    {
       this.Invoke(new MethodInvoker(/*Enter the name of your method here*/));
       return;
    }
    // Method code goes here ......
    /*
        Example:
        private void SomeMethod(object sender, EventArgs e) {
           if (InvokeRequired)
           {
             this.Invoke(new MethodInvoker(SomeMethod)); // Name of current method is 'SomeMethod'
             return;
           }
           // Code continues here
           int x,y,z;
           // Do something .....
        }
    */
