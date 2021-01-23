    private void ord_Click(object sender, EventArgs e) {
      // Ensure that suggested form size doesn't exceed the screen width and height
      this.Size = new System.Drawing.Size(
        Screen.GetWorkingArea(this).Width >= 1308 ? 1308 : Screen.GetWorkingArea(this).Width,
        Screen.GetWorkingArea(this).Height >= 599 ? 599 : Screen.GetWorkingArea(this).Height);
    
      // locate the form in the center of the working area 
      this.Location = new System.Drawing.Point(
         (Screen.GetWorkingArea(this).Width - Width) / 2,
         (Screen.GetWorkingArea(this).Height - Height) / 2);
    }
