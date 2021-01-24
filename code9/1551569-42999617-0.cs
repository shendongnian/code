    public partial class Form1 : Form {
        Timer BooyaaTimer = new Timer(); // Or this is created in Designer
    
        void SomeFunctionThatCreatesTheOtherForm() {
            TimerControlsForm form2 = new TimerControlsForm();
            // Pass the timer to form2
            form2.BooyaTimer = BooyaTimer;
            form2.ShowDialog();
        }
    }
