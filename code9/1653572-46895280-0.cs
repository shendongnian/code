    public class Addin : Addin_Interface
    {
        public bool Process(QSRules.SessionClass mySession)
        {
            if (MessageBox.Show("Do you want to Tender €10", "Tender Amount", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SendKeys.Send("{F12}{DOWN}10.00{{ENTER}");
                return true;
                
            }
            return false;
        }
    }
}
