    private BindingList<ProjectInfo> projectInfoList1 = new BindingList<ProjectInfo>();
            Public void loadfunction()
            {
            
            lstbx.ItemsSource=null;
            lstbx.Items.Clear();
            ProjectInformationList1=null;
            foreach (DtoProRow row in table.Rows)
            {
                projectInfoList1.Add(new ProjectInfo(row));
            }
            lstbx.DataContext = projectInfoList1;
            }
