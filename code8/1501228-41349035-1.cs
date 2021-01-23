    public class MyViewModel
    {
        public ObservableCollection<MyDataModel> Data { get; set; }
        public MyViewModel()
        {
            Data = new ObservableCollection<MyDataModel>
            {
                new MyDataModel {MyLabel = "Label 1", MyImage = "image.png", Selected = false },
                new MyDataModel {MyLabel = "Label 2", MyImage = "image.png", Selected = false },
                new MyDataModel {MyLabel = "Label 3", MyImage = "image.png", Selected = false },
                new MyDataModel {MyLabel = "Label 4", MyImage = "image.png", Selected = false },
                new MyDataModel {MyLabel = "Label 5", MyImage = "image.png", Selected = false }
            };
        }
    }
