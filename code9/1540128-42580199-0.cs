            private void FilterByOperatorNames(RadGridView radGridView)
            {
                var operatorNameFilter = radGridView.Columns[nameof(Username)].ColumnFilterDescriptor;
    			if (string.IsNullOrEmpty(username))
    			{
    				operatorNameFilter.Clear();
    				return;
    			}
    
                var allOperatorNames = Regex.Split(username, @"\W+");
                var userNamesCompositeFilter = new CompositeFilterDescriptor();
                foreach (var name in allOperatorNames)
                {
                    var filterDescriptor = new FilterDescriptor(nameof(Username), FilterOperator.Contains, name);
                    userNamesCompositeFilter.FilterDescriptors.Add(filterDescriptor);
                }
                userNamesCompositeFilter.LogicalOperator = FilterCompositionLogicalOperator.And;
                radGridView.FilterDescriptors.Add(userNamesCompositeFilter);
            }
