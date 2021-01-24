    using System;
    namespace GridSim
    {
      class Program
      {
        private int _h = 1;
        public int H{
          get{ return _h; }
          set{ _h = value; }
        }
        static void Main()
        {
            CreateWorld.Create();
        }
      }
    }
