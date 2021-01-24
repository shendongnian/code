    Private Object GetColIdx(String MyStringName)
    {
    	Int16 ColIdx = default(Int16);
    	For (ic = 0; ic <= this.DataGridView1.Columns.Count - 1; ic++) {
    		DataGridViewColumn dc = this.DataGridView1.Rows(ic);
    		If (dc.Name == MyStringName) {
    			ColIdx = ic;
    			break; 
    		}
    	}
    	Return ColIdx;
    }
