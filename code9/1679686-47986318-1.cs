    int count = soilData.Count;
    
    var result = await ProgressDialog.Execute(this, "Loading data", async () => {
          for (int i = 1; i <= count; i = i + 1000)
          {
             await soilDataMigration.MigrateSoilData(soilData.GetRange(i, i + 1000 >= count ? count - i : 1000));    
          }
       }, ProgressDialogSettings.WithSubLabel);
    
    if (result.OperationFailed)
       MessageBox.Show("Soil data upload failed failed.");
    else
       MessageBox.Show("Soil data successfully executed.");
    soilData.Clear();
