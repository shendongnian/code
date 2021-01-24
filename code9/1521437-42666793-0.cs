    private Word.Table getInvisibleTable(long hash , Word.Tables tablesRec) {
        Word.Tables docTables = Globals.ThisAddIn.Application.ActiveDocument.Tables;
        foreach (Word.Table thisTable in docTables) {
            if (thisTable.Tables.Count > 0) {
                this.getInvisibleTable(hash, thisTable.Tables);
            } else if (thisTable.Descr == hash.ToString()) {
                return thisTable;
            }
        }
        return null;
    }
