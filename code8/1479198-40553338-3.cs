    [Bindable]
    public static class TeamProperties
    {
        private static void TeamPropertiesChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            Team team = GetTeam(sender);
            Team currentTeam = GetCurrentTeam(sender);
    
            if (team != null && currentTeam != null)
            {
                SetIsCurrentTeam(sender, team.Equals(currentTeam));
            }
        }
    
        public static readonly DependencyProperty CurrentTeamProperty = DependencyProperty.RegisterAttached("CurrentTeam", typeof(Team), typeof(TeamProperties), new PropertyMetadata(null, TeamPropertiesChanged));
    
        public static Team GetCurrentTeam(DependencyObject obj)
        {
            return (Team)obj.GetValue(CurrentTeamProperty);
        }
    
        public static void SetCurrentTeam(DependencyObject obj, Team value)
        {
            obj.SetValue(CurrentTeamProperty, value);
        }
    
        public static readonly DependencyProperty TeamProperty = DependencyProperty.RegisterAttached("Team", typeof(Team), typeof(TeamProperties), new PropertyMetadata(null, TeamPropertiesChanged));
            
        public static Team GetTeam(DependencyObject obj)
        {
            return (Team)obj.GetValue(TeamProperty);
        }
    
        public static void SetTeam(DependencyObject obj, Team value)
        {
            obj.SetValue(TeamProperty, value);
        }
    
        public static readonly DependencyProperty IsCurrentTeamProperty = DependencyProperty.RegisterAttached("IsCurrentTeam", typeof(bool), typeof(TeamProperties), new PropertyMetadata(false));
    
        public static bool GetIsCurrentTeam(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsCurrentTeamProperty);
        }
    
        public static void SetIsCurrentTeam(DependencyObject obj, bool value)
        {
            obj.SetValue(IsCurrentTeamProperty, value);
        }
    }
