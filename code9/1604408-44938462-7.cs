    private void DoFoo() {
        if (myFormControl1.InvokeRequired) {
            myFormControl1.Invoke(new MethodInvoker(() => { DoFoo(); }));
        } else {
            object1.Visible = true;
            object2.Visible = false;
        }
    }
