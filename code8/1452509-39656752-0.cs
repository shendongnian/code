    private class Execute
    {
       public PictureBox pBox {get; set;}
       public Execute(PictureBox  pb)
       {
            pBox  = pb;
       }
       private void valueChecker(char value)
       {
          ...
          ...
          if (pBox != null) pBox.Image = photos[x];
          x++;
        }
    }
