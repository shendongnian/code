    using ExampleApp.Uwp.Interactions;
    using ExampleApp.Uwp.ViewModels;
    using MvvmCross.Base;
    using MvvmCross.Binding.BindingContext;
    using MvvmCross.Platforms.Uap.Presenters.Attributes;
    using MvvmCross.ViewModels;
    
    namespace ExampleApp.Uwp.Views
    {
        public sealed partial class LibrariesView : IMvxBindingContextOwner
        {
            private IMvxInteraction<AppNotificationInteraction> _appNotificationInteraction;
            private IMvxBindingContext _bindingContext;
            public LibrariesView()
            {
                InitializeComponent();
            }
            public IMvxInteraction<AppNotificationInteraction> AppNotificationInteraction
            {
                get => _appNotificationInteraction;
                set
                {
                    if (_appNotificationInteraction != null)
                    {
                        _appNotificationInteraction.Requested -= AppNotificationInteractionOnRequested;
                    }
    
                    _appNotificationInteraction = value;
                    _appNotificationInteraction.Requested += AppNotificationInteractionOnRequested;
                }
            }
    
            public IMvxBindingContext BindingContext
            {
                get => _bindingContext ?? (_bindingContext = new MvxBindingContext());
                set => _bindingContext = value;
            }
    
            public new LibrariesViewModel ViewModel => base.ViewModel as LibrariesViewModel;
    
            protected override void OnViewModelSet()
            {
                base.OnViewModelSet();
    
                BindingContext.DataContext = ViewModel;
    
                var set = this.CreateBindingSet<LibrariesView, LibrariesViewModel>();
                set.Bind(this).For(view => view.AppNotificationInteraction).To(viewModel => viewModel.AppNotificationInteraction).OneWay();
                set.Apply();
            }
    
            private void AppNotificationInteractionOnRequested(object sender, MvxValueEventArgs<AppNotificationInteraction> e)
            {
                AppNotification.Show(e.Value.Content);
            }
        }
    }
