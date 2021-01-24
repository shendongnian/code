    public class MyAnimatorListenerAdapter : AnimatorListenerAdapter
    {
        public override void OnAnimationEnd(Animator animation)
        {
            base.OnAnimationEnd(animation);
            //Do stuff
        }
    
        public override void OnAnimationCancel(Animator animation)
        {
            base.OnAnimationCancel(animation);
            //Do stuff
        }
    }
