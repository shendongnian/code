    private bool _hasTicked = false;
        
    private void Elapsed_Time_Tick(object sender, EventArgs e)
    {
         if(!_hasTicked)
         {
             Messagebox.show("Hi just once");
             _hasTicked = true;
         }
    }
