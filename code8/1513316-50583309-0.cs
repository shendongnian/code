        var errorList = _dte.ToolWindows.ErrorList as IErrorList;
        // placed in dictionary for easy access later
        var entries = (errorList?.TableControl.Entries ?? Enumerable.Empty<ITableEntryHandle>())
            .Select((e, i) => new { Entry = e, Index = i + 1 })
            .ToDictionary(it => it.Index, it => it.Entry);
        var errors = errorList.ErrorItems;
        for (int i = 1; i <= errors.Count; i++)
        {
            ErrorItem error = errors.Item(i);
            entries[i].TryGetValue("errorcode", out var errorCode);
            var item = new
            {
                error.Column,
                error.Description,
                error.ErrorLevel,
                error.FileName,
                error.Line,
                error.Project,
                Code = errorCode
            };
        }
