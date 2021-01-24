    public partial class Form1 : Form, IState
    ...
    private bool _working;
    public bool BgWorkerIsWorking
    {
        get { return _working; }
        set { _working = value; }
    }
