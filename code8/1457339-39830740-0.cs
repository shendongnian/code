        public override void DestroyItem(View container, int position, Object @object)
        {
            registeredFragments.Remove(position);
            base.DestroyItem(container, position, @object);
        }
        public override Object InstantiateItem(ViewGroup container, int position)
        {
            Android.Support.V4.App.Fragment fragment = (Android.Support.V4.App.Fragment)base.InstantiateItem(container, position);
            registeredFragments.Put(position, fragment);
            return fragment;
        }
        public Android.Support.V4.App.Fragment GetRegisteredFragment(int position)
        {
            return registeredFragments.Get(position);
        }
