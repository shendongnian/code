    public class MainViewModel : ViewModelBase{
    public ObservableCollection<ProductModel> Products { get; set; }
    
    private void GetData()
    {
        //getting data here
    
        Products = new ObservableCollection<ProductModel>();
    
        foreach (var item in myData)
        {
            Products.Add(item);
        }
        RaisePropertyChanged(nameof(Products)); // you are missing this
    }}
