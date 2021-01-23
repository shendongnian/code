    public class XXXXDetailsActivity : BaseActivity, LinearLayout.IOnTouchListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
          // Give the TabLayout the ViewPager
             var tabLayout = FindViewById<TabLayout>(Resource.Id.sliding_tabs);
            tabLayout.SetupWithViewPager(viewPager);
            //Get the Linear Layouts of the above Layout and Set On Touch Listener for each TABs
            LinearLayout tabStrip = ((LinearLayout)tabLayout.GetChildAt(0));
            if (tabStrip.ChildCount > 0)
            {
                for (int i = 0; i < tabStrip.ChildCount; i++)
                {
                    tabStrip.GetChildAt(i).SetOnTouchListener(this);
                    tabStrip.GetChildAt(i).Clickable = false;
                }
            }
        }
        /// <summary>
        /// On Tab Touch - Events will be fired on Touch of TAB
        /// </summary>
        /// <param name="v"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool OnTouch(View v, MotionEvent e)
        {
        //Do logic here.
        }
    }
