     bool flag = false;
        for (int i = 0; i < iplist.Length; i++)
        {
        if(iplist[i] == WebIP)
         {
           flag = true;
           break;
         }
       }
    
    if(flag)
      MessageBox.Show("Passed");
    else
      this.Close();
