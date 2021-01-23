        private void changeDisplayToSelectedClient(object sender, ListChangedEventArgs e)
        {
            Mouse.SetCursor(Cursors.Wait);
            if (MainWindow.theSelectedClient[0] != null)
            {
                for (int uc = 1; uc < ToDisplayUCContentList.Count; uc++)
                {
                    List<AllRowsDetails> theFilteredList = (from item in AllUCContentList[uc].RowDetails
                                           where item.codeClient == MainWindow.theSelectedClient[0].Code
                                           select item).ToList();
                    ToDisplayUCContentList[uc].RowDetails = new BindingList<AllRowsDetails>(theFilteredList);
                    myDataGridXamlObject.DataContext = ToDisplayUCContentList[uc].RowDetails;
                }
            }
        }
