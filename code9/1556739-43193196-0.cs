    IMobileServiceTable<Test> TestObj = App.MobileService.GetTable<Test>();
    try
    {
        Test obj = new Test();
        obj.test = test.Text;
        obj.test1 = test1.Text;
        obj.test2 = test2.Text;
        obj.test3 = test3.Text;
        
        TestObj.InsertAsync(obj);
        MessageDialog msgDialog = new MessageDialog("Data Inserted!!!");
        msgDialog.ShowAsync();
    }
    catch (Exception ex)
    {
            MessageDialog msgDialogError = new MessageDialog("Error : " + ex.ToString());    msgDialogError.ShowAsync();
    }
