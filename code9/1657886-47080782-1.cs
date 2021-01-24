    public class RowItemViewModel : ViewModelBase
    {
        public RowItemViewModel(RoleCoordinator coordinator)
        {
            _roleCoordinator = coordinator;
            _roleCoordinator.RoleChanged += _roleCoordinator_RoleChanged;
        }
        #region Role Coordination
        private void _roleCoordinator_RoleChanged(object sender, RoleChangedEventArgs e)
        {
            if (sender != this && e.Role == Role.Primary && this.Role == Role.Primary)
            {
                Role = Role.Secondary;
            }
        }
        private RoleCoordinator _roleCoordinator;
        #endregion Role Coordination
        #region Role Property
        private Role _role = default(Role);
        public Role Role
        {
            get { return _role; }
            set
            {
                if (value != _role)
                {
                    _role = value;
                    _roleCoordinator.RaiseRoleChanged(this, this.Role);
                    OnPropertyChanged();
                }
            }
        }
        #endregion Role Property
