        public void InOwnersRecordsWindowClickOnListItemAtIndex(int index)
        {
            #region Variable Declarations
            WinList uIListBoxOwnersRecordsList = this.UIOwnersRecordsWindow.UIListBoxOwnersRecordsWindow.UIListBoxOwnersRecordsList;
            #endregion
            Mouse.Click(uIListBoxOwnersRecordsList.Items[index]);
        }
