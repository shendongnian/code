    static Random ran = new Random();
    public static List<Point3d> RandomptGenerator(int num)
    {
      var <Point3d> ptList = new List<Point3d>();
      int count = num; 
      for (int i = 0;i < count;i++)
      {
        for (int j = 0;j < count;j++)
        {
          double x = i;
          double y = j;
          x = ran.Next(0, 40);
          y = ran.Next(0, 30);
          ptList.Add(new Point3d(x, y, 0.0));
        }
      }
      return ptList;
    }
