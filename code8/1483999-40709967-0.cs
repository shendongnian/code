    [Activity(Label = "My App")]
    public class MyActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ConnectionMenu);
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            AddTab("A", "a_fragment", () => new FragmentA());
            AddTab("B", "b_fragment", () => new FragmentB());
            if (savedInstanceState != null)
            {
                var selectedTab = savedInstanceState.GetInt(
                    "ActionBar.SelectedNavigationIndex", 0);
                ActionBar.SetSelectedNavigationItem(selectedTab);
            }
        }
        
        protected override void OnSaveInstanceState(Bundle savedInstanceState)
        {
            base.OnSaveInstanceState(savedInstanceState);
            savedInstanceState.PutInt(
                "ActionBar.SelectedNavigationIndex",
                ActionBar.SelectedNavigationIndex);
        }
        private void AddTab<TFragment>(
            string tabText, 
            string tag,
            Func<TFragment> ctor) where TFragment : Fragment
        {
            var tab = ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetTag(tag);
            var fragment = FragmentManager.FindFragmentByTag<TFragment>(tag);
            tab.TabSelected += (sender, e) =>
            {
                if (fragment == null)
                {
                    fragment = ctor.Invoke();
                    e.FragmentTransaction.Add(
                        Resource.Id.fragmentContainer, 
                        fragment, 
                        tag);
                }
                else
                {
                    e.FragmentTransaction.Attach(fragment);
                }
            };
            tab.TabUnselected += (sender, e) =>
            {
                if (fragment != null)
                {
                    e.FragmentTransaction.Detach(fragment);
                }
            };
            ActionBar.AddTab(tab);
        }
    }
