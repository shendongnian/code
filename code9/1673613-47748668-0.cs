    IEnumerable<Table1Element> Table1 = ...
    IEnumerable<Table2Element> Table2 = ...
    IEnumerable<Table3Element> Table3 = ...
    from table1Element in Table1
    join table2Element in Table2
        on new
        {
            Col1 = table1Element.Col1,
            Col2 = table1Element.Col2,
            Col3 = table1Element.Col3,
            Col4 = table1Element.Col4,
        }
        equals new
                on new
        {
            Col1 = table2Element.Col1,
            Col2 = table2Element.Col2,
            Col3 = table2Element.Col3,
            Col4 = table2Element.Col4,
        }
    join table3Element in Table3
        on new
        {
            Col1 = table2Element.Col1,
            Col2 = table2Element.Col2,
            Col3 = table2Element.Col3,
            Col4 = table2Element.Col4,
        }
        equals new
        {
            Col1 = table3Element.Col1,
            Col2 = table3Element.Col2,
            Col3 = table3Element.Col3,
            Col4 = table3Element.Col4,
        }
    select new
    {
        Col1 = table1Element.Col1,
        Col2 = table1Element.Col2,
        Col3 = table1Element.Col3,
        Col4 = table1Element.Col4,
        // only if required: col5 and col6 from table1
        FromTable1 = new
        {
             Col5 = table1Element.Col5,
             Col6 = table1Element.Col6,
        }
        FromTable2 = new
        {
             Col5 = table2Element.Col5,
             Col6 = table2Element.Col6,
        }
        FromTable3 = new
        {
             Col5 = table3Element.Col5,
             Col6 = table3Element.Col6,
        }
    }
