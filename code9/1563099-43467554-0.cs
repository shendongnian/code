    public void TestMethod1()
    {
        var handle = Isolate.Fake.NextInstance<Table>(Members.CallOriginal, context =>
        {
            var tempcells = context.Parameters[0] as Cell[,];
    
            for (int i = 0; i < tempcells.GetLength(0); i++)
            {
                for (int j = 0; j < tempcells.GetLength(1); j++)
                {
                    tempcells[i, j] = cellFactory.Create(i, j);
                }
            }
            context.Parameters[0] = tempcells;
    		
    		//calling the original ctor with tempcells as the parameter
            context.WillCallOriginal();
        });
    	
    	// calling the ctor with the custom logic
        var testTable = new Table(new Cell[2,2]);
    	
    
        testTable.Reset();
        // calling the private property
        var resTable = Isolate.Invoke.Method(testTable, "get_Cells") as Cell[,];
    
    	// for asserting
        var emptyCell = new Cell { Value = string.Empty };
        for (int i = 0; i < 2; i++)
        {
            for(int j=0; j<2; j++)
            {
                Assert.AreEqual(emptyCell.Value, resTable[i, j].Value);
            }
        }
    }
 
