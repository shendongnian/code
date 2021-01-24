    public ActionResult BudgetNoteLineEntry(int accId)
        {
            BudgetEntryNotesVM NVM = new BudgetEntryNotesVM();
            NVM.AccountNumber = _budgetEntryRepository.GetAccountName(accId);
            NVM.AccountDescription = _budgetEntryRepository.GetAccountDescription(accId);
            NVM.BudgetNoteLineEntryColumnsList = _budgetEntryRepository.GetBudgetNoteEntryLineColumns(accId);
            //NVM.BudgetNoteLineEntryList = _budgetEntryRepository.GetBudgetNoteLineEntry(accId);
            NVM.BudgetLineEntryArray = _budgetEntryRepository.GetBudgetNoteLineEntry(accId);
            return PartialView("_ShowAccountBudgetLineEntries", NVM);
        }
