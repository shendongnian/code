    using System;
    using Xamarin.Forms;
    namespace Forms9Patch
    {
	    public class ManualLayout : Xamarin.Forms.Layout<View>
	    {
		    protected override void LayoutChildren(double x, double y, double width, double height)
		    {
                // layout calculations go here.  Don't forget to account for 
                // this layout's Padding and each child view's/layout's Margin.
                // for the sake of this example, let's say I've stored these 
                // calculation results in:
                Dictionary<View, Rectangle> bounds = new Dictionary<View, Rectangle>();
    
                // And with those calculation results, I can apply the layouts.
                foreach (var child in Children)
                    LayoutChild(child, bounds[child]);
			}
	    }
    }
