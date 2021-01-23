    public List<SelectListItem> StatusOptions => Enum.GetNames(typeof(StatusOptions)).Select(o => new SelectListItem {
       Text = o,
       Value = o,
       Selected = o == this.Status
    };
