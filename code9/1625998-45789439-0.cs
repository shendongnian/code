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
       if (dt != null && dt.Rows.Count > 0)
       {
           return true;
       }
       return false;
    }
