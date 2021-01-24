     await System.Threading.Tasks.Task.Run(() => LoadData());
    
     private async System.Threading.Tasks.Task LoadData()
        {
          LoadAllQCDetails();
          btn.Enabled = true;
        }
