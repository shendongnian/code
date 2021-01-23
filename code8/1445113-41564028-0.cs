    using Android.App;
    using Android.Widget;
    using Android.OS;
    using Android.Support.V7.App;
    using Toolbar = Android.Support.V7.Widget.Toolbar;
    using Android.Support.Design.Widget;
    using System;
    using Android.Support.V4.Widget;
    using System.Collections.Generic;
    using Android.Views;
    
    namespace NavigationDrawer_ExpandableListView
    {
        [Activity(Label = "NavigationDrawer_ExpandableListView", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MyTheme")]
        public class MainActivity : AppCompatActivity
        {
            private DrawerLayout drawerLayout;
            ExpandableListAdapter menuAdapter;
            ExpandableListView expandableList;
            List<ExpandedMenuModel> listDataHeader;
            Dictionary<ExpandedMenuModel, List<String>> listDataChild;
    
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
    
                
                SetContentView (Resource.Layout.Main);
                var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
    
                //Toolbar will now take on default actionbar characteristics
                SetSupportActionBar(toolbar);
    
                SupportActionBar.Title = "Hello from Appcompat Toolbar";
    
                ExpandableListView expandableList = FindViewById<ExpandableListView>(Resource.Id.navigationmenu);
                NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
    
                if (navigationView != null)
                {
                    navigationView.NavigationItemSelected += OnNavigationItemSelected;
                }
    
    
                PrepareListData();
                menuAdapter = new ExpandableListAdapter(this, listDataHeader, listDataChild, expandableList);
    
                // setting list adapter
                expandableList.SetAdapter(menuAdapter);
    
            }
    
            private void PrepareListData()
            {
                listDataHeader = new List<ExpandedMenuModel>();
                listDataChild = new Dictionary<ExpandedMenuModel, List<String>>();
    
                ExpandedMenuModel item1 = new ExpandedMenuModel();
                item1.Name = "heading1";
                item1.Image = Resource.Drawable.abc_ic_menu_copy_mtrl_am_alpha;
                // Adding data header
                listDataHeader.Add(item1);
    
                ExpandedMenuModel item2 = new ExpandedMenuModel();
                item2.Name = "heading2";
                item2.Image = Resource.Drawable.abc_ic_voice_search_api_material;
                listDataHeader.Add(item2);
    
                ExpandedMenuModel item3 = new ExpandedMenuModel();
                item3.Name = "heading3";
                item3.Image = Resource.Drawable.abc_ic_menu_share_mtrl_alpha;
                listDataHeader.Add(item3);
    
                ExpandedMenuModel item4 = new ExpandedMenuModel();
                item4.Name = "heading4";
                item4.Image = Resource.Drawable.abc_ic_menu_paste_mtrl_am_alpha;
                listDataHeader.Add(item4);
    
                // Adding child data
                List<String> heading1 = new List<String>();
                heading1.Add("Submenu of item 1");
    
                List<String> heading2 = new List<String>();
                heading2.Add("Submenu of item 2");
                heading2.Add("Submenu of item 2");
                heading2.Add("Submenu of item 2");
    
                List<String> heading3 = new List<String>();
                heading3.Add("Submenu of item 3");
                heading3.Add("Submenu of item 3");
    
                List<String> heading4 = new List<String>();
                heading4.Add("Submenu of item 4");
                heading4.Add("Submenu of item 4");
    
                listDataChild.Add(listDataHeader[0], heading1);// Header, Child data
                listDataChild.Add(listDataHeader[1], heading2);
                listDataChild.Add(listDataHeader[2], heading3);
                listDataChild.Add(listDataHeader[3], heading4);
            }
    
            public override bool OnOptionsItemSelected(IMenuItem item)
            {
                switch (item.ItemId)
                {
                    case Android.Resource.Id.Home:
                        drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                        return true;
                }
                return base.OnOptionsItemSelected(item);
            }
    
            private void OnNavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
            {
    
                var menuItem = e.MenuItem;
                menuItem.SetChecked(!menuItem.IsChecked);
                drawerLayout.CloseDrawers();
            }
    
        }
    }
