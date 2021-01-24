    public enum foo
    {
      r1,
      g2
    }
    public void urMom()
    {
      PictureBox[] obj = new PictureBox[]
      {
          pic_position_r1,
          pic_position_g2
      };
      foreach(PictureBox b in obj)
        b.Visible = false;
      obj[Convert.ToInt32(foo.g2)].Visible = true;
    }
