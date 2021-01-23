    public class ShowDialogService : IShowDialogService
    {
        public void ShowPatientWindow()
        {
            var patientWindowViewModel = new PatientWindowViewModel();
            var patientWindow = new PatientWindow();
            
            patientWindow.DataContext = patientWindowViewModel;
            patientWindow.ShowDialog();
        }
        public void ShowOtherWindow()
        {
            // Other window ...
        }
    }
