    public class DropDownListAdapter : 
       System.Web.UI.WebControls.Adapters.WebControlAdapter {
    protected override void RenderContents(HtmlTextWriter writer) {
        DropDownList list = this.Control as DropDownList;
        string currentOptionGroup;
        List<string> renderedOptionGroups = new List<string>();
        foreach(ListItem item in list.Items) {
            if(item.Attributes["OptionGroup"] == null) {
                RenderListItem(item, writer);
            } else {
                currentOptionGroup = item.Attributes["OptionGroup"];
                if(renderedOptionGroups.Contains(currentOptionGroup)) {
                    RenderListItem(item, writer);
                } else {
                    if(renderedOptionGroups.Count > 0) {
                        RenderOptionGroupEndTag(writer);
                    }
                    RenderOptionGroupBeginTag(currentOptionGroup, 
                                              writer);
                    renderedOptionGroups.Add(currentOptionGroup);
                    RenderListItem(item, writer);
                }
            }
        }
        if(renderedOptionGroups.Count > 0) {
            RenderOptionGroupEndTag(writer);
        }
    }
    private void RenderOptionGroupBeginTag(string name, 
                 HtmlTextWriter writer) {
        writer.WriteBeginTag("optgroup");
        writer.WriteAttribute("label", name);
        writer.Write(HtmlTextWriter.TagRightChar);
        writer.WriteLine();
    }
    private void RenderOptionGroupEndTag(HtmlTextWriter writer) {
        writer.WriteEndTag("optgroup");
        writer.WriteLine();
    }
    private void RenderListItem(ListItem item, 
                 HtmlTextWriter writer) {
        writer.WriteBeginTag("option");
        writer.WriteAttribute("value", item.Value, true);
        if(item.Selected) {
            writer.WriteAttribute("selected", "selected", false);
        }
        foreach(string key in item.Attributes.Keys) {
            writer.WriteAttribute(key, item.Attributes[key]);
        }
        writer.Write(HtmlTextWriter.TagRightChar);
        HttpUtility.HtmlEncode(item.Text, writer);
        writer.WriteEndTag("option");
        writer.WriteLine();
    }
