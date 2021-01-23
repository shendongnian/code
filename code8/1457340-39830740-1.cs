        public void UpdateFragment()
        {
            var activeFragment = _Adaptor.GetRegisteredFragment(1); // where in the viewpager the fragment is
            ((YourFragment)activeFragment).MethodOnFragment();
        }
