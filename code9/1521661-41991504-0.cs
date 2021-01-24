    public static UiTestControl GetSiblingByClass (UiTestControl ctrl, string class) {
	    var parent = ctrl.Parent;
	    var controlToReturn = new UiTestControl(parent);
	    controlToReturn.SearchProperties[HtmlControl.PropertyNames.Class] = class;
	    return controlToReturn;
    }
     
