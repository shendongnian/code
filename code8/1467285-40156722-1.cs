    private void DoWork()
    {
       int increment = (100 / count);
       if(_progress + increment >= 100)
       {
          WorkProgress1(100);
          _progress = 0;
       }
       else
       {
          _progress += (increment);
          WorkProgress1(_progress);
       }
    }
