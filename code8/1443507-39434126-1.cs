    public static class SystemExt
    {
        public static MvcHtmlString DropDownListT<T>(this HtmlHelper htmlHelper,
            string name,
            EnumHelper<T> enumHelper,
            string value = null,
            string nonSelected = null,
            IDictionary<string, object> htmlAttributes = null)
            where T : struct
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (nonSelected != null)
            {
                items.Add(new SelectListItem()
                {
                    Text = nonSelected,
                    Selected = string.IsNullOrEmpty(value),
                });
            }
            foreach (T item in enumHelper.GetValues())
            {
                if (enumHelper.EnumToIndex(item) >= 0)
                    items.Add(new SelectListItem()
                    {
                        Text = enumHelper.EnumToString(item),
                        Value = item.ToString(),                 //enumHelper.Unbox(item).ToString()
                        Selected = value == item.ToString(),
                    });
            }
            return htmlHelper.DropDownList(name, items, htmlAttributes);
        }
    }
