    public new Point PointToClient(Point p)
    {
       if (MyControl.InvokeRequired)
       {
           pointToClientCallBack ptcb = new pointToClientCallBack(PointToClient);
           GetWindow().Invoke(ptcb, new object[] { p });
           return;  // <------ ADD ME
       }
       return MyControl.PointToClient(p);
    }
