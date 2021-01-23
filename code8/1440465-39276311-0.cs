    string ErrorMsg = "";
    for (int i = 0; i < dgvTrabajadores.Rows.Count - 1; i++){
    try
    {
	  cmd.SavingOneRowAtOneTime()
    }
    catch(Exception ex)
    {
	  //Example, change it as you need.
      ErrorMsg += (ErrorMsg == "") ?  "Insert failed for Rows: " + i.ToString() : "," + i.ToString();
    }
    }
    //At the end
   	if(ErrorMsg != "")
     MessageBox.Show(ErrorMsg);
    }
