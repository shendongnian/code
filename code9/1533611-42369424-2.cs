    [Test]
    public void MyTest()
    {
        // Arrange
        var data = GetData();
        
        // Act
        ... test your stuff
        
        // Assert
        .. verify your results
    }
    public MyBigViewModel GetData()
    {
        return JsonConvert.DeserializeObject<MyBigViewModel>(Data);
    }
    public const String Data = @"
    {
        'SelectedOcc': [29,	26,	27,	2,	1,	28],
        'PossibleOcc': null,
        'SelectedCat': [6,	2,	5,	7,	4,	1,	3,	8],
        'PossibleCat': null,
        'ModelName': 'c',
        'ColumnsHeader': 'Header',
        'RowsHeader': 'Rows'
        // etc. etc.
    }";
