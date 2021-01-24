    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace MyProjectName
    {
        public class ExtendedDropDownList : DropDownList
        {
            public const string OptionGroupTag = "optgroup";
            private const string OptionTag = "option";
            protected override void RenderContents(HtmlTextWriter writer)
            {
                ListItemCollection items = this.Items;
                int count = items.Count;
                string tag;
                string optgroupLabel;
                if (count > 0)
                {
                    bool flag = false;
                    string prevOptGroup = null;
                    for (int i = 0; i < count; i++)
                    {
                        tag = OptionTag;
                        optgroupLabel = null;
                        ListItem item = items[i];
                        if (item.Enabled)
                        {
                            if (item.Attributes != null && item.Attributes.Count > 0 && item.Attributes[OptionGroupTag] != null)
                            {
                                optgroupLabel = item.Attributes[OptionGroupTag];
                                if (prevOptGroup != optgroupLabel)
                                {
                                    if (prevOptGroup != null)
                                    {
                                        writer.WriteEndTag(OptionGroupTag);
                                    }
                                    writer.WriteBeginTag(OptionGroupTag);
                                    if (!string.IsNullOrEmpty(optgroupLabel))
                                    {
                                        writer.WriteAttribute("label", optgroupLabel);
                                    }
                                    writer.Write('>');
                                }
                                item.Attributes.Remove(OptionGroupTag);
                                prevOptGroup = optgroupLabel;
                            }
                            else
                            {
                                if (prevOptGroup != null)
                                {
                                    writer.WriteEndTag(OptionGroupTag);
                                }
                                prevOptGroup = null;
                            }
                            writer.WriteBeginTag(tag);
                            if (item.Selected)
                            {
                                if (flag)
                                {
                                    this.VerifyMultiSelect();
                                }
                                flag = true;
                                writer.WriteAttribute("selected", "selected");
                            }
                            writer.WriteAttribute("value", item.Value, true);
                            if (item.Attributes != null && item.Attributes.Count > 0)
                            {
                                item.Attributes.Render(writer);
                            }
                            if (optgroupLabel != null)
                            {
                                item.Attributes.Add(OptionGroupTag, optgroupLabel);
                            }
                            if (this.Page != null)
                            {
                                this.Page.ClientScript.RegisterForEventValidation(this.UniqueID, item.Value);
                            }
                            writer.Write('>');
                            HttpUtility.HtmlEncode(item.Text, writer);
                            writer.WriteEndTag(tag);
                            writer.WriteLine();
                            if (i == count - 1)
                            {
                                if (prevOptGroup != null)
                                {
                                    writer.WriteEndTag(OptionGroupTag);
                                }
                            }
                        }
                    }
                }
            }
            protected override object SaveViewState()
            {
                object[] state = new object[this.Items.Count + 1];
                object baseState = base.SaveViewState();
                state[0] = baseState;
                bool itemHasAttributes = false;
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i].Attributes.Count > 0)
                    {
                        itemHasAttributes = true;
                        object[] attributes = new object[this.Items[i].Attributes.Count * 2];
                        int k = 0;
                        foreach (string key in this.Items[i].Attributes.Keys)
                        {
                            attributes[k] = key;
                            k++;
                            attributes[k] = this.Items[i].Attributes[key];
                            k++;
                        }
                        state[i + 1] = attributes;
                    }
                }
                if (itemHasAttributes)
                    return state;
                return baseState;
            }
            protected override void LoadViewState(object savedState)
            {
                if (savedState == null)
                    return;
                if (!(savedState.GetType().GetElementType() == null) &&
                    (savedState.GetType().GetElementType().Equals(typeof(object))))
                {
                    object[] state = (object[])savedState;
                    base.LoadViewState(state[0]);
                    for (int i = 1; i < state.Length; i++)
                    {
                        if (state[i] != null)
                        {
                            object[] attributes = (object[])state[i];
                            for (int k = 0; k < attributes.Length; k += 2)
                            {
                                this.Items[i - 1].Attributes.Add
                                    (attributes[k].ToString(), attributes[k + 1].ToString());
                            }
                        }
                    }
                }
                else
                {
                    base.LoadViewState(savedState);
                }
            }
        }
    }
