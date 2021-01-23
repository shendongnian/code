    public IEnumerable<SelectListItem> AccessLevelsWithSelectedItem(string selectedAccessLevelID)
        {
            return DB.AccessLevels
              .Select(x => new SelectListItem
              {
                  Value = x.AccessLevelID.ToString(),
                  Text = x.Name,
                  Selected = x.AccessLevelID.ToString() == selectedAccessLevelID
              });
        }
