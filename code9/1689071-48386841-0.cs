    var internalAudits = _internalAuditRepo.InternalAudits;
            // First hit or new search: need to initialize PageNum to 1;
            if (internalAuditListVM.PagingInfo == null || newSearch == true)
            {
                ModelState.Remove("PagingInfo.PageNum");
                internalAuditListVM.PagingInfo = new PagingInfo();
            }
            if (newSearch == true)
            {
                ModelState.Remove("QuickSearchType");
                internalAuditListVM.QuickSearchType = null;
            }
