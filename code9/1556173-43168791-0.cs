    public override View GetView(int position, View convertView, ViewGroup parent)
    {
        //Prepare convertView here
        CheckBox itemCheckBox = convertViewFindViewById<CheckBox>(Resource.Id.itemCheckBox);
        itemCheckBox.Tag = new Java.Lang.String(this.items[position].name); //set the checkbox tag with information about your item. The tag object class must inherit from Java.Lang.Object
        itemCheckBox.CheckedChange -= itemCheckBox_CheckedChange; //this is to avoid registering the event more than once when scrolling the listview
        itemCheckBox.CheckedChange += itemCheckBox_CheckedChange;
        return convertView;
    }
    private void itemCheckBox_CheckedChange(object sender, EventArgs e)
    {
        // CheckBox myCheckBox = (CheckBox)sender;
        // Java.Lang.Object myTag = myCheckBox.Tag;
        // String itemName = ((Java.Lang.String)myTag).ToString();
        //save in a variable that your item was checked
        //for example:
        // foreach(Item i in this.items)
        // {
        //     if(i.name.Equals(itemName))
        //     {
        //         i.IsChecked = myCheckBox.Checked;
        //         break;
        //     }
        // }
    }
