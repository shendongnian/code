    public class MainView : MvxCachingFragmentCompatActivity<MainViewModel>
    {
    	public override void OnAttachFragment(Fragment fragment)
    	{
    		base.OnAttachFragment(fragment);
    		if (fragment is MainListView)
    		{
    			SetDrawerState(true);
    		}
    		else
    		{
    			SetDrawerState(false);
    		}
    	}
    
    	public void SetDrawerState(bool isEnabled)
    	{
    		if (isEnabled)
    		{
    			_drawer.SetDrawerLockMode(DrawerLayout.LockModeUnlocked);
    			_drawerToggle.OnDrawerStateChanged(DrawerLayout.LockModeUnlocked);
    			_drawerToggle.DrawerIndicatorEnabled = true;
    			_drawerToggle.SyncState();
    
    		}
    		else
    		{
    			_drawer.SetDrawerLockMode(DrawerLayout.LockModeLockedClosed);
    			_drawerToggle.OnDrawerStateChanged(DrawerLayout.LockModeLockedClosed);
    			_drawerToggle.DrawerIndicatorEnabled = false;
    			_drawerToggle.SyncState();
    		}
    	}
    }
