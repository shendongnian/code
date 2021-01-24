    protected void OnExpose(object sender, ExposeEventArgs args) {
        using (Context cr = Gdk.CairoHelper.Create(this.GdkWindow)) {
              int top = Allocation.Top;
              int left = Allocation.Left;  
              
              cr.Rectangle(left + 8, top + 8, 10, 10);
              cr.SetSourceRGB(255, 0, 0);
              cr.Fill();
        }
    }
