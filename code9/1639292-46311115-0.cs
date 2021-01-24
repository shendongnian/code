    [Register("NotificationsView")] // this is missing...
    [MvxViewFor(typeof(NotificationsViewModel))] // this is missing...
    public partial class NotificationsView : BaseView<NotificationsViewModel>
    {
        public NotificationsView() : base("NotificationsView", null)
        {
        }
    }
