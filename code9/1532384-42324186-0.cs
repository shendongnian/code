    protected void txtWeight_TextChanged(object sender, EventArgs e)
      {     
        Boolean transSuccess = false;      
        String myScript = "";       
        String sqlStmt = "";      
    
        OracleConnection conOra = new OracleConnection(conOraStr);
        conOra.Open();
        OracleTransaction transOra;
        transOra = conOra.BeginTransaction();
    
            double weight = Convert.ToDouble(txtWeight.Text);
            double height = Convert.ToDouble(txtHeight.Text);
            double bmi; 
    
            bmi=Math.Round(( weight / ( height * height))* 10000, 1);
    
            lblbmi.Text= String.Format(bmi.ToString(),"0,0");
      }
    protected void txtHeight_TextChanged(object sender, EventArgs e)
      {     
        Boolean transSuccess = false;      
        String myScript = "";       
        String sqlStmt = "";      
    
        OracleConnection conOra = new OracleConnection(conOraStr);
        conOra.Open();
        OracleTransaction transOra;
        transOra = conOra.BeginTransaction();
    
            double weight = Convert.ToDouble(txtWeight.Text);
            double height = Convert.ToDouble(txtHeight.Text);
            double bmi; 
    
            bmi=Math.Round(( weight / ( height * height))* 10000, 1);
    
            lblbmi.Text= String.Format(bmi.ToString(),"0,0");
      }
