    index   fltCe  fltUTName  fltUT  
    
    1       75     TexBox1    Text1   
    2       75     TexBox2    Text2  
    3       75     TexBox3    Text3  
    4       75     TexBox4    Text4  
    5       75     TexBox5    Text5  
    6       75     TexBox6    Text6
    int fltCE_item = 75;
    using (myDataContext mydc= new myDataContext()){
       List<tblModulRelayConfig> tblModuler = (
                 from CE in mydc.tblCEs 
                 where CE.fltCE == fltCE_item 
                 select CE
       );
       foreach(TextBox tx in GetAll(this, typeof(TextBox)){
          if(tblModuler.Count > 0){ //update table
             foreach(var CE in tblModuler)
                if(CE.fltUTName.Equals(tx.Name))
                   CE.fltUT = tx.Text;
          }else{ //insert: index should be autoseeded into the db;
            tblModulRelayConfig nyModul = new tblModulRelayConfig();
            nyModul.fltCe = fltCE_item;
            nyModul.fltUTName = tx.Name; 
            nyModul.fltUT = tx.Text; 
            mydc.tblModulRelayConfigs.InsertOnSubmit(nyModul);
          }
       }
       mydc.SubmitChanges();
    }
