        public bool IsDataGridViewEmpty(ref DataGridView dataGridView)
    {
    	bool isEmpty = true;
    	foreach (DataGridViewRow row in dataGridView.Rows) {
    		foreach (DataGridViewCell cell in row.Cells) {
    			if (!string.IsNullOrEmpty(cell.Value)) {
    				if (!string.IsNullOrEmpty(Strings.Trim(cell.Value.ToString()))) {
    					isEmpty = false;
    					break; // TODO: might not be correct. Was : Exit For
    				}
    			}
    		}
    	}
    	return isEmpty;
    }
