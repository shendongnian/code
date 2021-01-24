    public static void Main(string[] args)
    {
        IDataModel dataModel = new DataModel();
        IDataGridView1 dataView1 = new DataGridView1();
        IDataGridView2 dataView2 = new DataGridView2();
        IDataGridView3 dataView3 = new DataGridView3();
        IMainView mainView = new MainView(dataView1, dataView2, dataView3);
        DataGridPresenter1 dataPresenter1 = new DataGridPresenter1(dataView1, dataModel);
        DataGridPresenter2 dataPresenter2 = new DataGridPresenter2(dataView2, dataModel);
        DataGridPresenter3 dataPresenter3 = new DataGridPresenter3(dataView3, dataModel);
        MainPresenter mainPresenter = new MainPresenter(mainView, dataModel);
    }
