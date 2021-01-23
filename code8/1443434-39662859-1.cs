    private void M_workItem_Saving(object sender, WorkItemEventArgs e)
    {
        if (sender != null)
        {
            string areaPath = m_workItem.AreaPath.ToString();
            if ((int)areaPath.Split('\\').Length < 4)
            {
                throw new Exception("Please insert at least 4 levels");
            }
        }
    }
