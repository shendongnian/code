        using System;
        using System.Collections.Generic;
        using UIKit;
    
        namespace TestActionSheet
        {
    	public class SimpleSheet
    	{
    		public delegate void SelectedHandler(string selectedValue);
    		public event SelectedHandler Selected;
    		private UIActionSheet actionSheet;
    
    		public SimpleSheet(List<string> optionList)
    		{
    			actionSheet = new UIActionSheet("SheetTitle");
    			foreach (string str in optionList)
    			{
    				actionSheet.Add(str);
    			}
    			actionSheet.AddButton("Cancel");
    
    			actionSheet.Clicked += (sender, e) =>
    			{
    				if (e.ButtonIndex < actionSheet.ButtonCount - 1)
    				{
    					if (null != Selected)
    						Selected(optionList[(int)e.ButtonIndex]);
    				}
    			};
    		}
    
    		public void Show(UIView view)
    		{
    			actionSheet.ShowInView(view);
    		}
    	}
    }
