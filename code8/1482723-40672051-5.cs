	result = true;
    Task tables1Task = WebServices.GetListTable1(null);
    Task tables2Task = WebServices.GetListTable2(null);
    Task tables3Task = WebServices.GetListTable3(null);
	List<Table1> tables1 = await tables1Task;
	// ...
	List<Table2> tables2 = await tables2Task;
	// ...
	List<Table3> tables3 = await tables3Task;
	// ...
