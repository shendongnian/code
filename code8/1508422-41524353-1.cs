    private PictureBox[] GetPictureBoxes(int start, int end) {
      int size = - 1;
      if (IndexsAreValid(start, end, out size)) {
        PictureBox curPic = null;
        PictureBox[] allPics = new PictureBox[size];
        int index = 0;
        for (int i = start; i <= end; i++) {
          if (IsValidPic(i, out curPic)) {
            allPics[index] = curPic;
            index++;
          }
        }
        return allPics;
      }
      else {
        return new PictureBox[0];
      }
    }
    private Boolean IndexsAreValid(int start, int end, out int size) {
      if (start < 1 || end < 1) {
        size = -1;
        return false;
      }
      if (start > end) {
        size = -1;
        return false;
      }
      size = end - start + 1;
      return true;
    }
    private Boolean IsValidPic(int index, out PictureBox picture) {
      string targetName = "pictureBox" + index;
      try {
        PictureBox target = (PictureBox)Controls.Find(targetName, true)[0];
        if (target != null) {
          picture = target;
          return true;
        }
        picture = null;
        return false;
      }
      catch (IndexOutOfRangeException e) {
        picture = null;
        return false;
      }
    }
    private void ResetAll() {
      foreach (PictureBox pb in this.Controls.OfType<PictureBox>()) {
        pb.Visible = true;
      }
    }
    private void button1_Click(object sender, EventArgs e) {
      int start = 11;
      int end = 30;
      PictureBox[] pictureBoxesToChange = GetPictureBoxes(start, end);
      foreach (PictureBox pb in pictureBoxesToChange) {
        if (pb != null)
          pb.Visible = false;
      }
    }
     private void button3_Click(object sender, EventArgs e) {
      int start = 30;
      int end = 11;
      PictureBox[] pictureBoxesToChange = GetPictureBoxes(start, end);
      foreach (PictureBox pb in pictureBoxesToChange) {
        if (pb != null)
          pb.Visible = false;
      }
    }
    private void button4_Click(object sender, EventArgs e) {
      int start = 1;
      int end = 7;
      PictureBox[] pictureBoxesToChange = GetPictureBoxes(start, end);
      foreach (PictureBox pb in pictureBoxesToChange) {
        if (pb != null)
          pb.Visible = false;
      }
    }
    private void button2_Click(object sender, EventArgs e) {
      ResetAll();
    }
 
