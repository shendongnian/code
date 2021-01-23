    public new Point PointToClient(Point p)
    {
       if (MyControl.InvokeRequired)
       {
           pointToClientCallBack ptcb = new pointToClientCallBack(PointToClient);
           return GetWindow().Invoke(ptcb, new object[] { p }) as Point;
       }
       return MyControl.PointToClient(p);
    }
