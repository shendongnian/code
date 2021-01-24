    public static class ListExtensions
    {
        /// <summary>
        /// Adds an empty Dropdown Option at the start of the list
        /// If the list is null then null will be returned and nothing happens
        /// </summary>
        /// <param name="list">
        /// List of dropdown options
        /// </param>
        /// <returns >The list of dropdown options with the prepended empty option</returns>
        public static IList<SelectListItem> AddEmpty(this IList<SelectListItem> list)
        {
            list?.Insert(0, new SelectListItem {Value = string.Empty, Text = Resources.Labels.ChooseListItem});
            return list;
        }
    }
