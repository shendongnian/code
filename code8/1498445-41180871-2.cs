       private void ComputeSmallTps() {
         decimal perCorso;
         decimal smallVelocita;
    
         // first, parse arguments...
         if (!decimal.TryParse(textBoxPercorso.Text, out perCorso) ||
             !decimal.TryParse(textBoxAgilitySmallVelocita.Text, out smallVelocita)) {
           // invalid input data, e.g. "bla-bla-bla"
           textBoxAgilitySmallTps.Text = "???"; 
    
           return;
         }
         
         try { 
           // ...then compute: put the right formula here 
           // put break point here, check smallVelocita and perCorso values
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
