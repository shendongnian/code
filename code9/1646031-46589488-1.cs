    public class MainTabPageRenderer : TabbedPageRenderer, TabLayout.IOnTabSelectedListener
    {
        void TabLayout.IOnTabSelectedListener.OnTabReselected(TabLayout.Tab tab)
        {
            if (Element is MainPage)
            {
                // the same tab was selected a second time, so do something
            }
        }
    }
