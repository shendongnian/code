    private void SearchFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (SearchFilter.SelectedValue != null)
        {
            var filter = SearchFilter.SelectedValue as String;
            switch (filter)
            {
                case "Full-Time":
                    EmployeeAutoBox.ItemFilter = PersonFilter_Full;
                    break;
                case "Part-Time":
                    EmployeeAutoBox.ItemFilter = PersonFilter_Part;
                    break;
                case "Retired":
                    EmployeeAutoBox.ItemFilter = PersonFilter_Ret;
                    break;
                case "Stockholder":
                    EmployeeAutoBox.ItemFilter = PersonFilter_Stock;
                    break;
                case "Terminated":
                    EmployeeAutoBox.ItemFilter = PersonFilter_Term;
                    break;
                default:
                    EmployeeAutoBox.ItemFilter = PersonFilter;
                    break;
            }
        }
    }
