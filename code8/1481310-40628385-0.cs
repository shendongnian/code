			//0. Here i am getting list users as an Object:
            OpsManagementController OM = new OpsManagementController();
            //1. Getting Users List:
            var result = OM.UsersGetforInvoice();
            //2. Creating folder for Invoices:
            string folderName = @"D:\Google Drive\MonthlyInvoices";
            string fileName = ("Invoices_" + DateTime.Now.ToString("yyyy-MM-dd").ToString());
            string pathString = System.IO.Path.Combine(folderName, fileName);
            System.IO.Directory.CreateDirectory(pathString);
            string folderNameEmail = @"D:\Google Drive\MonthlyInvoices\Email";
            string fileNameEmail = ("Invoices_" + DateTime.Now.ToString("yyyy-MM-dd").ToString());
            string pathStringEmail = System.IO.Path.Combine(folderNameEmail, fileNameEmail);
            System.IO.Directory.CreateDirectory(pathStringEmail);
			
			//3. Generating invoices by user name:
            for (int i = 0; i < result.UserDetail.Count; i++)
            {
                var userId = result.UserDetail[i].UserID;
                var userEmail = result.UserDetail[i].Email;
                var userName = result.UserDetail[i].FullName;
                userName = userName.Replace(@"C\O", "CO");
                userName = userName.Replace(@"C/O", "CO");
                // Directories for reports:
                var invoicePath = "D:/Google Drive/MonthlyInvoices/" + fileName + "/" + userId + " " + userName + ".pdf";
                var invoicePath_email = "D:/Google Drive/MonthlyInvoices/Email/" + fileNameEmail + "/" + userId + " " + userName + ".pdf";
                report2.SetParameterValue("UserID", result.UserDetail[i].UserID);
 
                report2.ExportToDisk(ExportFormatType.PortableDocFormat, invoicePath);
                 // using sendgrip Api :
                EmailUtils.SendEmail_Att(
                                    new string[] { userEmail }, //TO : userEmail
                                    new string[] { "email@gmail.com" }, //
                                    invoiceSubject,
                                    invoiceBody,
                                    invoicePath_email
                                    );
            }
