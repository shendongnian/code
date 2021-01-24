    Select.AllColumnsFrom<Data.Group>()
        .Where(Data.Group.GroupIDColumn).IsNotEqualTo(m_sRootGroupID)
        .AndExpression(Data.Group.Columns.OwnerPersonID).IsEqualTo("someownerID")
        .Or(Data.Group.Columns.OwnerPersonID).IsEqualTo("SomeContextID")
        .AndExpression(Data.Group.Columns.IsCallList).IsEqualTo(true)
        .CheckLogicalDelete().ToString();
