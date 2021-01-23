    public class PanelA : PanelBase
    {
        int i = 0;
        public void SetPanelA(int iNew)
        {
            i = iNew;
        }
    }
    public class PanelB : PanelBase
    {
        public EventHandler<int> OnChangePanelA = new EventHandler<int>((sender, e) => { }); //stub
        
        string str = "";
        public void SetPanelB(string strNew)
        {
            str = strNew;
        }
        //PROBLEM HERE HOW TO ACCESS MAIN setPanelACentral
        public void ChangePanelA()
        {
            OnChangePanelA(this, 1000);
        }
    }
