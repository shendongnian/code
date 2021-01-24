    // Add group A of items
    If(conditionA)
    {
        if(conditionA1 || conditionA2)
            myMenuItem.Items.Add(new ToolStripSeparator());
        If(conditionA1)
            myMenuItem.Items.Add("group A: item 1");
        If(conditionA2)
            myMenuItem.Items.Add("group A: item 2");
    }
    // Add group B of items
    If(conditionB)
    {
        if(conditionB1 || conditionB2)
            myMenuItem.Items.Add(new ToolStripSeparator());
        If(conditionB1)
            myMenuItem.Items.Add("group B: item 1");
        If(conditionB2)
            myMenuItem.Items.Add("group B: item 2");
    }
    // Add group C of items
    If(conditionC)
    {
        if(conditionC1 || conditionC2)
            myMenuItem.Items.Add(new ToolStripSeparator());
        If(conditionC1)
            myMenuItem.Items.Add("group C: item 1");
        If(conditionC2)
            myMenuItem.Items.Add("group C: item 2");
    }
