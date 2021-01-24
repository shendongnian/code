    static private bool[][] GetSelectionState(DataGridView input)
    {
        int rowCount = input.Rows.Count;
        int columnCount = input.Columns.Count;
        var result = new List<int[]>();
        for (var r = 0; r < rowCount; r++)
        {
            for (var c = 0; c < columnCount; c++)
            {
                if(input.Rows[r].Cells[c].Selected==true)
               {
                result.add(new int[]{r,c});//will keep only the integer of selected items
               }
            }
        }
        return result;//this for me was a recycled variable it can be used or recycled from somewhere else
    }
           
    private void SetSelectionState(DataGridView input,result)
        {
            for (int i=0;i<result.Count;i++)
            {
                input.Rows[result[i][0]].Cells[result[i][1]].Selected = true;
            }
        }
    public void SetupToggledSelectionMode(DataGridView input,result)
        {
         for (int i=0;i<result.Count;i++)
                {
                    if(result[i].SequenceEqual(new int[] { e.RowIndex, e.ColumnIndex }))
                    {
                        result.RemoveAt(i);
                        continueer = 1;
                        break;
                    }
                }
                if (continueer == 0)
                {
                    ResRoomSelections.Add(new int[] { e.RowIndex, e.ColumnIndex });
                }
            SetSelectionState(input);
             //whatever else you need to do 
     }
