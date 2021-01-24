        private void Bt2_Click(object sender, System.EventArgs e)
        {
            if (bt1.Visibility == ViewStates.Visible)
            {
                AlphaAnimation disappearAnimation = new AlphaAnimation(1, 0);
                disappearAnimation.Duration = 2000;
                bt1.StartAnimation(disappearAnimation);
                disappearAnimation.AnimationStart += DisappearAnimation_AnimationStart;
                disappearAnimation.AnimationEnd += DisappearAnimation_AnimationEnd;
            }
            else
            {
                AlphaAnimation disappearAnimation = new AlphaAnimation(0, 1);
                disappearAnimation.Duration = 2000;
                bt1.StartAnimation(disappearAnimation);
                disappearAnimation.AnimationStart += DisappearAnimation_AnimationStart;
                disappearAnimation.AnimationEnd += DisappearAnimation_AnimationEnd;
            }
        }
        private void DisappearAnimation_AnimationStart(object sender, Animation.AnimationStartEventArgs e)
        {
            if (bt1.Visibility == ViewStates.Visible)
            {
                bt1.Animate().TranslationX(bt1.Width).SetDuration(2000);
            }
            else
            {
                bt1.Animate().TranslationX(0).SetDuration(2000);
            }
        }
        private void DisappearAnimation_AnimationEnd(object sender, Animation.AnimationEndEventArgs e)
        {
            if (bt1.Visibility == ViewStates.Visible)
            {
                bt1.Visibility = ViewStates.Invisible;
            }
            else
            {
                bt1.Visibility = ViewStates.Visible;
            }
        }
