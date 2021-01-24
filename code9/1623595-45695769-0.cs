    class FAB_Hide_on_Scroll : FloatingActionButton.Behavior
    {
        public FAB_Hide_on_Scroll(Context context, IAttributeSet attr) : base()
        {
          
        }
        public override void OnNestedScroll(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed)
        {
            base.OnNestedScroll(coordinatorLayout, child, target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed);
            var fab = child.JavaCast<FloatingActionButton>();
            if (fab.Visibility == ViewStates.Visible && dyConsumed > 0)
            {
                fab.Hide();
            }
            else if (fab.Visibility == ViewStates.Gone && dyConsumed < 0)
            {
                fab.Show();
            }
        }
        public override bool OnStartNestedScroll(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View directTargetChild, View target, int nestedScrollAxes)
        {
            return nestedScrollAxes == ViewCompat.ScrollAxisVertical;
        }
    }
