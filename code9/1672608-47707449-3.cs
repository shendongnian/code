    List<MyLabel> MyLabels = new List<MyLabel>();
    
    public class MyLabel : Label
    {
       public MyLabel()
       {
          //Define some default properties
          this.TextAlign = ContentAlignment.MiddleCenter;
          this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          this.Font = new Font("Calibri", 9f, FontStyle.Regular);
          this.BackColor = Color.White;
          this.ForeColor = Color.Black;
          this.Size = new Size(50, 20);
       }
    }
