    var results = query.Select(m => new {
	Column1= col1,
	Column2= col2
	}).AsEnumerable()
    	.Select(m => new MyViewModel
    {
        MyCalculation = Foo(m.Column1, m.Column2)
    });
