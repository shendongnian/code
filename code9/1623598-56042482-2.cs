[Register("HideFab.ScrollAwareFABBehavior")]
public class FabBehavior : CoordinatorLayout.Behavior
{
    public FabBehavior()
    {
        
    }
    
    public FabBehavior(Context context, IAttributeSet attrs) : base(context, attrs)
    {
    }
    public override void OnNestedScroll(CoordinatorLayout coordinatorLayout, Object child, View target, int dxConsumed, int dyConsumed, int dxUnconsumed,
        int dyUnconsumed, int type)
    {
        base.OnNestedScroll(coordinatorLayout, child, target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, type);
        var fab = child.JavaCast<FloatingActionButton>();
        if (fab.Visibility == ViewStates.Visible && dyConsumed > 0)
        {
            fab.Hide(new VisibilityListener());
        }
        else if (fab.Visibility == ViewStates.Invisible && dyConsumed < 0)
        {
            fab.Show();
        }
    }
    public override bool OnStartNestedScroll(CoordinatorLayout coordinatorLayout, Object child, View directTargetChild, View target, int axes, int type)
    {
        return axes == ViewCompat.ScrollAxisVertical;
    }
}
public class VisibilityListener : FloatingActionButton.OnVisibilityChangedListener
{
    public override void OnHidden(FloatingActionButton fab)
    {
        base.OnHidden(fab);
        fab.Visibility = ViewStates.Invisible;
    }
}
Update:
I don't know why, but this class works:
