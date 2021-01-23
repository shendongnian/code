    private class Execute
    {
       public PictureBox pBox {get; set;}
       public Execute(PictureBox  pb)
       {
            pBox  = pb;
       }
       private void valueChecker(char value)  // or maybe public ?!
       {
          ...
          ...
          if (pBox != null) pBox.Image = photos[x];
          x++;
        }
    }
