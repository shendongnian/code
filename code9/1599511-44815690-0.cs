    public class MyFixture: Interpreter {
      public void Interpret(CellProcessor processor, Tree<Cell> table) {
        new Traverse<Cell>()
          .Rows.Header(row => FunctionThatDoesSomethingWithTheHeaderRow(row))
          .Rows.Rest(row => FunctionThatDoesSomethingWithEachSubsequentRow(row))
          .VisitTable(table);
      }
      ...
    }
