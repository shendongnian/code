    protected void jugar_Click(object sender, ImageClickEventArgs e) {
     if (sender is ImageButton) {
      var turNo = Session["Turno"];
      var buttonSender = (ImageButton)sender;
      switch (turNo) {
       case 1:
        buttonSender.ImageUrl = "C:\Users\Epyros\documents\visual studio 2015\Projects\EnTA TE TI\EnTA TE TI\Imagenes\Tic-tac-toe-cross.png";
        Session["Turno"] = 2;
        break;
       case 2:
        buttonSender.ImageUrl = "C:\Users\Epyros\documents\visual studio 2015\Projects\EnTA TE TI\EnTA TE TI\Imagenes\Tic-tac-toe-nought-e1461667111145.png";
        Session["Turno"] = 1;
        break;
       default:
        // Logic for turNo != 1 or 2
        break;
      }
     }
     else
     {
         // sender is not the expected type (ImageButton)
         Trace.WriteLine(string.Format("Sender is an unexpected type. Expected: (ImageButton), got ({0}).", sender.GetType().Name),"WARN");
     }
    }
