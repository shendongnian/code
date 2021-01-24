    for(var i = 1; i <= rowCount; i++)
    {
        if (i % 2 == 0)
        {
            for(var j = 1; i <= colCount; i++)
            {
                 var checkBox = Find(i, j);
    
                 if (checkBox != null)
                     checkBox.Checked = true;
            }
        } 
    }
