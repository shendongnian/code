    this.SelectionsList = this.SelectionsList
        .Where(a => a.Name == selection.Name)
        .Select(a => 
        {
            a.IsActive = a.Name == selection.Name ? true:false;
            return a;
        }).ToList();
