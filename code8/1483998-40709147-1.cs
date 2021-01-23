       protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ConnectionMenu);
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            if(savedInstanceState == null)
            {
                AddTab("A", new FragmentA());
                AddTab("B", new FragmentB());
            }
            else 
            {
                Fragment a = (FragmentA)SupportFragmentManager.FindFragmentByTag("my_tag_a");
                Fragment b = (FragmentB)SupportFragmentManager.FindFragmentByTag("my_tag_b");
                AddTab("A", a);
                AddTab("B", b);
            }
        }
