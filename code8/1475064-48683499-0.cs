        RootView page;
        protected override void OnElementChanged( VisualElement oldElement, VisualElement newElement ) {
            base.OnElementChanged( oldElement, newElement );
            page = newElement as RootView;
        }
        public override bool OnTouchEvent( MotionEvent e ) {
            if( IsDrawerOpen( Android.Support.V4.View.GravityCompat.Start ) )
                return base.OnTouchEvent( e );
            else {
                if( (e.Action == MotionEventActions.Up || e.Action == MotionEventActions.Down || e.Action == MotionEventActions.Move)
                    && (page?.SwipeEnabled ?? false)
                )
                    return base.OnTouchEvent( e );
                else {
                    CloseDrawers();
                    return true;
                }
            }
        }
