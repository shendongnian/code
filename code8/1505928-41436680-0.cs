    public override DesignerActionItemCollection GetSortedActionItems()
    {
       DesignerActionItemCollection actionItems = base.GetSortedActionItems();
       //inserts the new smart tag action items.
       actionItems.Insert(0, new DesignerActionHeaderItem("MySmartTag Support"));
       actionItems.Insert(1, new DesignerActionPropertyItem("BackColor", "Back Color"));
       actionItems.Insert(2, new DesignerActionPropertyItem("ForeColor", "Fore Color"));
       return actionItems;
    }
