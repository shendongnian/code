    string fn = Dts.Variables["fileName"].Value; 
    string[] parts = fn.Split('_');
         
    //Assuming it's always the 7th part 
    // You could extract the other    parts as well. 
    Dts.Variables["WO"].Value = part(6);
