        using CsvHelper;
          if (string.IsNullOrEmpty(txtFirstN.Text) || string.IsNullOrEmpty(txtLName.Text) || string.IsNullOrEmpty(cbDirection.Text) || string.IsNullOrEmpty(cbPhoneSystem.Text) || string.IsNullOrEmpty(txtCustPhone.Text) || string.IsNullOrEmpty(txtManager.Text) || string.IsNullOrEmpty(txtProgram.Text) || string.IsNullOrEmpty(cbLocation.Text) || string.IsNullOrEmpty(txtPhoneNumber.Text) || string.IsNullOrEmpty(cbIssue.Text) || string.IsNullOrEmpty(cbPhoneSystem.Text))
            {
                MessageBox.Show("Please Fill out the WHOLE Form. Thank you!");
            }
            else
            {
                CloudStorageAccount storageAccount =
                   CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=myaccountname;AccountKey=my-account-key
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
                CloudTable table = tableClient.GetTableReference("TelephonyIssueLog");
                //Await is a good command to use here so we don't try to go forward before we verify the table actually exists and error out.
                //Notice I made the function async.  C# is annoying as all out when using async and await so yeah have fun with that :D. -=Chris
                await table.CreateIfNotExistsAsync();
                IssueEntity IssueLog = new IssueEntity("Issues", lblRandom.Text);
                IssueLog.FirstName = txtFirstN.Text;
                IssueLog.LastName = txtLName.Text;
                IssueLog.CallDirection = cbDirection.Text;
                IssueLog.CustNumber = txtCustPhone.Text;
                //IssueLog.FirstName = tbFirstName.Text;
                //IssueLog.LastName = tbLastName.Text;
                IssueLog.Location = cbLocation.Text;
                IssueLog.Manager = txtManager.Text;
                IssueLog.PhoneNumber = txtPhoneNumber.Text;
                IssueLog.PhoneSystem = cbPhoneSystem.Text;
                IssueLog.PrimaryIssue = cbIssue.Text;
                IssueLog.Program = txtProgram.Text;
                TableOperation insertOperation = TableOperation.Insert(IssueLog);
                table.Execute(insertOperation);
