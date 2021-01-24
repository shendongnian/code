    [MvxDialogFragmentPresentation]
    [Register(nameof(HoursDateDialogView))]
    public class HoursDateDialogView : MvxDialogFragment<HoursDateDialogViewModel>
    {
        public HoursDateDialogView()
        {
        }
        protected HoursDateDialogView(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.HoursDateDialogView, null);
            return view;
        }
    }
