    List<ModelYouWantToProjectTo> queryResult = CurrentContext.Set<AM_Response_T>()
        .Include(t => t.AM_Master_T)
        .Include(t => t.AM_Supporting_Evidences_T)
        // Skipped a few
        .Include(t => t.AM_Response_Activity_T)
        .Select(t => new ModelYouWantToProjectTo
            {
                ModelProperty = t.Property,
                // Etc...
            })
         .ToList();
