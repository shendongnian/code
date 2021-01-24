    [Test]
    public void GetTableColumns_WhenCalled_ShouldReturnTableColumnList()
    {
        // Act
        var dt= _sut.GetTableColumns(Statics.SystemUsersTableName);
    
        // Assert
        Assert.That(!dt.HasRow());
    
    }
    public static bool HasRow(this DataTable dt)
    {
     return dt != null && dt.Rows.Count > 0;
    }
