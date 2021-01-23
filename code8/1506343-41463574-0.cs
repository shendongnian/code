    internal void SetItemInternal(int index, object value) {
        if (value == null) {
            throw new ArgumentNullException("value");
        }
 
        if (index < 0 || index >= InnerArray.GetCount(0)) {
            throw new ArgumentOutOfRangeException("index", SR.GetString(SR.InvalidArgument, "index", (index).ToString(CultureInfo.CurrentCulture)));
        }
 
        owner.UpdateMaxItemWidth(InnerArray.GetItem(index, 0), true);
        InnerArray.SetItem(index, value);
 
        // If the native control has been created, and the display text of the new list item object
        // is different to the current text in the native list item, recreate the native list item...
        if (owner.IsHandleCreated) {
            bool selected = (owner.SelectedIndex == index);
            if (String.Compare(this.owner.GetItemText(value), this.owner.NativeGetItemText(index), true, CultureInfo.CurrentCulture) != 0) {
                owner.NativeRemoveAt(index);
                owner.SelectedItems.SetSelected(index, false);
                owner.NativeInsert(index, value);
                owner.UpdateMaxItemWidth(value, false);
                if (selected) {
                    owner.SelectedIndex = index;
                }
            }
            else {
                // NEW - FOR COMPATIBILITY REASONS
                // Minimum compatibility fix for VSWhidbey 377287
                if (selected) {
                    owner.OnSelectedIndexChanged(EventArgs.Empty); //will fire selectedvaluechanged
                }
            }
        }
        owner.UpdateHorizontalExtent();
    }
