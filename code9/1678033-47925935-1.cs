    private readonly List<TreatmentZone> treatmentZones = new List<TreatmentZone>();
    public Form1()
    {
      this.InitializeComponent();
      this.treatmentZones.Add(new TreatmentZone(1, "a", "b", Color.Blue, 10, 10, 200, 400));
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
      foreach (var treatmentZone in this.treatmentZones)
      {
        using(var brush = new SolidBrush(treatmentZone.Color))
          e.Graphics.FillEllipse(brush, treatmentZone.X, treatmentZone.Y, treatmentZone.Width, treatmentZone.Height);
      }
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
      foreach (var treatmentZone in this.treatmentZones)
      {
        if(treatmentZone.HitTest(e.Location))
          this.toolTip1.Show(treatmentZone.Description, this.pictureBox1, e.Location);
      }
    }
    private void pictureBox1_Click(object sender, EventArgs e)
    {
      var location = this.pictureBox1.PointToClient(Cursor.Position);
      foreach (var treatmentZone in this.treatmentZones)
      {
        if (treatmentZone.HitTest(location))
          MessageBox.Show("Handle the click of " + treatmentZone.Code + ".");
      }
    }
   }
