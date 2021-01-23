    public void EnableAddMenu(bool blnStatus)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).miAdd.IsEnabled = blnStatus;
        }
        public void EnableAddSubMenus(bool blnStatus)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).smiAddCheckinDate.IsEnabled = blnStatus;
            ((MainWindow)System.Windows.Application.Current.MainWindow).smiAddMonthlyVisitDate.IsEnabled = blnStatus;
            ((MainWindow)System.Windows.Application.Current.MainWindow).smiAddCardIssueDate.IsEnabled = blnStatus;
            ((MainWindow)System.Windows.Application.Current.MainWindow).smiAddDependent.IsEnabled = blnStatus;
            ((MainWindow)System.Windows.Application.Current.MainWindow).smiAddNote.IsEnabled = blnStatus;
        }
