    public new Point PointToClient(Point p)
    {
       if (MyControl.InvokeRequired)
       {
           pointToClientCallBack ptcb = new pointToClientCallBack(PointToClient);
           GetWindow().Invoke(ptcb, new object[] { p });
       }
       return MyControl.PointToClient(p);
    }
