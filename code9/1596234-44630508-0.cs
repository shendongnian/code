    public enum foo{
      r1,
      g2
    }
    public void urMom(){
      PictureBox[] obj = new object[2];
      obj[Convert.ToInt32(foo.r1)] = pic_position_r1;
      obj[Convert.ToInt32(foo.r2)] = pic_position_r2;
      foreach(PictureBox b in obj)
        b.Visible = false;
      obj[Convert.ToInt32(foo.r2)].Visible = true;
    }
