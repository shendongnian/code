    private void btnPrepare_Click(object sender, EventArgs e) { 
      //DONE: foreach - no magic numbers (8)
      foreach (var lbl in labels) {
        lbl.BackColor = System.Drawing.Color.Red;
        lbl.Update(); // <- Update == force label repainting
        System.Threading.Thread.Sleep(2000);
      }
    }
