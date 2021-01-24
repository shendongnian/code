    private void FillDataGridViewWithFilteredStudentAccordingToDisplayCheckBoxes() {
    	var headerText = new Dictionary<string, string> { { "Id", "Numero" }, { "LastName", "Nom" }, { "FirstName", "Prenom" }, { "MiddleName", "Nom Du Pere" },
    	{ "DateOfBirth", "Date De Naissance" } };
    
    	var viewColumns = new List<string> { "Id", "LastName", "FirstName" };
    
    	foreach (var possibleColumn in headerText.Keys) {
    		var displayColumns = Controls.Find(possibleColumn + "DisplayCheckBox", true);
    		if (displayColumns.Length == 1) {
    			if (((CheckBox)displayColumns[0]).Checked)
    				viewColumns.Add(possibleColumn);
    		}
    	}
    
    	//Rest of the code omitted, but same concept.
    
    	foreach (var dataFieldName in viewColumns)
    		FilteredStudentDataGridView.Columns.Add(dataFieldName, headerText[dataFieldName]);
    
    	foreach (var student in _filteredStudents) {
    		var studentType = student.GetType();
    		var rowValues = new List<object>();
    		foreach (var dataFieldName in viewColumns)
    			rowValues.Add(studentType.GetProperty(dataFieldName).GetValue(student, null));
    
    		FilteredStudentDataGridView.Rows.Add(rowValues.ToArray());
    	}
    }
