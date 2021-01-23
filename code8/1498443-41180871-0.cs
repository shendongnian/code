       private void ComputeSmallTps() {
         decimal perCorso;
         decimal smallVelocita;
    
         // first, parse arguments...
         if (!decimal.TryParse(textBoxPercorso.Text, out perCorso) ||
             !decimal.TryParse(textBoxAgilitySmallVelocita.Text, out smallVelocita)) {
           // invalid input data
           textBoxAgilitySmallTps.Text = "???"; 
    
           return;
         }
         
         try { 
           // ...then compute: put the right formula here 
           decimal result = smallVelocita / perCorso;
    
           textBoxAgilitySmallTps.Text = result.ToString(); 
         }
         catch (ArithmeticException) {
           // Division by zero, overflow 
           textBoxAgilitySmallTps.Text = "???";
         }
       }
    
       ...
    
       void TextBoxPercorsoTextChanged(object sender, EventArgs e) {
         // Just a simple call, no complex logic here
         ComputeSmallTps();
       }
    
       void TextBoxAgilitySmallVelocitaTextChanged(object sender, EventArgs e) {
         ComputeSmallTps();
       }
