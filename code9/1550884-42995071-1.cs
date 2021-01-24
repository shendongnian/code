    //Getting Columns to populate table in PartialView
        public IEnumerable<BudgetNoteLineEntryColumnsVM> GetBudgetNoteEntryLineColumns(int accId)
        {
            IEnumerable<BudgetNoteLineEntryColumnsVM> AccountsLineEntriesColumnIList = new List<BudgetNoteLineEntryColumnsVM>();
            //var query2 =(from )
            var query = (from NC in _context.Notes_Columns
                         join NLE in _context.Notes_Line_Entries on NC.pkiNotesColumnsId equals NLE.fkiNotesColumnId
                         where NLE.fkiAccountId == accId
                         select new BudgetNoteLineEntryColumnsVM
                         {
                             Sequence = NC.Sequence,
                             ColumnName = NC.NotesColumnName
                         }).Distinct().OrderBy(n=>n.Sequence);
            AccountsLineEntriesColumnIList = query;
            return AccountsLineEntriesColumnIList;
        }
    //Getting data to populate table
        public string[,] GetBudgetNoteLineEntry(int accId)
        {
            int row = 0;
            int column = 0;
            //Getting total number of rows based on the EntryLineId
            var outer = (from NC in _context.Notes_Columns
                         join NLE in _context.Notes_Line_Entries on NC.pkiNotesColumnsId equals NLE.fkiNotesColumnId
                         where NLE.fkiAccountId == accId
                         select NLE.EntryLineId).Distinct().Count();
            //Getting total number of columns based on the Account ID
            var inner = (from NC in _context.Notes_Columns
                         join NLE in _context.Notes_Line_Entries on NC.pkiNotesColumnsId equals NLE.fkiNotesColumnId
                         where NLE.fkiAccountId == accId
                         select NC.NotesColumnName).Distinct().Count();
            //Declaring 2D Array with Inner and Outer values above
            string[,] entrylines = new string[outer, inner];
            //Getting all data in order of the Columns
            var query = (from NC in _context.Notes_Columns
                         join NLE in _context.Notes_Line_Entries on NC.pkiNotesColumnsId equals NLE.fkiNotesColumnId
                         where NLE.fkiAccountId == accId
                         select new BudgetNoteLineEntryVM
                         {
                             pkiNotesLineEntriesId = NLE.pkiNotesLineEntriesId,
                             fkiAccountId = NLE.fkiAccountId,
                             NotesColumnName = NC.NotesColumnName,
                             Value = NLE.Value,
                             isNewLineItem = NLE.isNewEntry,
                             Sequence = NC.Sequence,
                             EntryLineId = NLE.EntryLineId
                         }).Distinct().OrderBy(n => n.Sequence).ThenBy(n=>n.EntryLineId);
            //Looping through every item and adding to 2D array based on the ordering of the columns
            foreach(var item in query)
            {
                if(row >= outer)
                {
                    row = 0;
                    column++;
                }
                entrylines[row, column] = item.Value;
                if (row <= outer)
                {
                    row++;
                }
            }
            return entrylines;
        }
