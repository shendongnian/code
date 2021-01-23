    List<Table1> itemsTable 1 = 
        items.select(i => new Table1() {
    		p1 = i.p1,
    		p2 = i.p2,
    		p3 = i.p3,
    		Table2 = i.p4.select(p4 => MapToTable2(p4)).ToList()
        }).ToList();
    
    private Table2 MapToTable2(P4 p4Items){
    	return new Table2() {
    		t1 = p4.T1,
    		t2 = p4.T2
    		Table3 = new Table3() {
    			t3 = p4.T3,
    			t4 = p4.T4
    		}
    	};
    }
