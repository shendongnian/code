    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      if (SelectionCompleteCheckBox.Checked == true)
      {
          List<TestResult> results = new List<TestResult>();
          foreach (DataGridViewRow row in AssayData.SelectedRows)
          {
              try
              {
                  var temp = new TestResult();
                  temp.StudyID = row.Cells["STUDYID"].Value.ToString()
                  temp.AssyDescription = row.Cells["ASSAYDESCRIPTION"].Value.ToString()
                  results.Add(temp);
              }
              catch (Exception ee)
              {
                  //Do something?
              }
          }
          if (results.Count > 0)
          {
              controller.GetResult(results);
          }
   
    }
