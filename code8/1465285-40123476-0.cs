     public static MvcHtmlString CheckBoxList2(this HtmlHelper htmlHelper, string name, MultiSelectList listInfos)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("This parameter cannot be null or empty!", "name");
            }
            if (listInfos == null)
            {
                throw new ArgumentException("This parameter cannot be null!", "listInfos");
            }
            //if (listInfos.Count<SelectListItem>() < 1)
            //{
            //    throw new ArgumentException("The count must be greater than 0!", "listInfos");
            //}
            List<string> selectedValues = (List<string>)listInfos.SelectedValues;
            StringBuilder sb = new StringBuilder();
            foreach (SelectListItem info in listInfos)
            {
                sb.Append("<li class='Navlist'>");
                TagBuilder builder = new TagBuilder("input");
                if (info.Selected) builder.MergeAttribute("checked", "checked");
               //builder.MergeAttributes<string, object>(htmlAttributes);
                builder.MergeAttribute("type", "checkbox");
                builder.MergeAttribute("value", info.Value);
                builder.MergeAttribute("name", name);
                builder.MergeAttribute("id", info.Value);
                builder.MergeAttribute("class", "filter-classif");
                builder.InnerHtml = "<label>" + info.Value + "(" + info.Text + ")</label>";
                
                sb.Append(builder.ToString(TagRenderMode.Normal));
                sb.Append("</li>");
            }
