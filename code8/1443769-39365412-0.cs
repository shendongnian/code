    public class MydbiSchedule : Dbi.WinControl.Schedule.dbiSchedule
        {      
            
            protected override void OnKeyDown(KeyEventArgs e)
            {
                if (e.KeyCode != Keys.Escape)
                    base.OnKeyDown(e);
            }
    
        }
