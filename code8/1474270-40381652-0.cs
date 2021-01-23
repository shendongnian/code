          public class CustomerViewModel () {
                public int SelectedStatusId { get; set; }
    [DisplayName("Status")]
    public IEnumerable<SelectListItem> StatusItems
    {
        get
        {
            yield return new SelectListItem { Value = "", Text = "- Select a status -" };
            StatusTypeEnum[] values = (StatusTypeEnum[])Enum.GetValues(typeof(StatusTypeEnum));
            foreach (StatusTypeEnum item in values)
            {
                if (item != StatusTypeEnum.Unknown)
                {
                    yield return new SelectListItem { Value = ((int)item).ToString(), Text = item.GetDescription() };
                }
            }
        }
    }
           
    }
