    private void DoWork()
    {
       int increment = (100 / count);
       _progress += (increment);
       if(_progress + increment >= 100)
       {
          WorkProgress1(100);
          _progress = 0;
       }
       else
       {
          WorkProgress1(_progress);
       }
    }
