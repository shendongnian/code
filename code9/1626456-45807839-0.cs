    Task.Factory.StartNew(() => {
        string str = System.DateTime.Now.ToString("fff");
        Debug.WriteLine(str);
        Invoke((MethodInvoker)(() => Log(str)));
    });
