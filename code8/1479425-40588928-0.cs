     //ItemSelectedEvent
        (diagram.Info as IGraphInfo).ItemSelectedEvent += MainWindow_ItemSelectedEvent;
        void MainWindow_ItemSelectedEvent(object sender, DiagramEventArgs args)
        {
        INode node = args.Item as INode;
        //Way 1:casting
        string des = (node.Content as Employee).EmpId.ToString();
        Console.WriteLine(des);
        //Way 2: Iterate the Propeties via foreach
        foreach(var prop in node.Content.GetType().GetProperties())
        {
           string des= prop.GetValue(node.Content).ToString();
           Console.WriteLine(des);
        }
        }
