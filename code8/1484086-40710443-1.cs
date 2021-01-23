    private bool edited = false;
    
    private void button1_Click(object sender, EventArgs e) {
        try {
             // Execute Query 
             edited = true ; 
         }
        catch(SqlException ex) {
            // ("there was an sql issue!");
        }
        catch(Exception ex){
            // ("there was another issue!");
        }
    }
    private void button2_Click(object sender, EventArgs e){
        if(edited){
            // (Close)
        }else {
           // (Don't Close)
        }
    }
