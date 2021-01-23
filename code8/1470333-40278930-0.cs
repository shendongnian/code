    public sealed partial class MainPage : Page
    {
        public List<Item> items;
        public MainPage()
        {
            this.InitializeComponent();
        }
        private async void btnClick_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.ComputerFolder;
            picker.FileTypeFilter.Add(".txt");
            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                var stream = await file.OpenAsync(FileAccessMode.Read);
                using (StreamReader reader = new StreamReader(stream.AsStream()))
                {
                    items = new List<Item>();
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (line.StartsWith("---"))
                        {
                            //listbox.Items.Add(line);
                            //Instead of adding a line, add an item instance
                            items.Add(new Item
                            {
                                Name = line
                            });
                        }
                        else if(line!=string.Empty)//if it is not the empty line then add it to the last item's url
                        {
                            if (items.LastOrDefault() != null)
                            {
                                items.LastOrDefault().URL = line;
                            }
                        }
                    }
                    listbox.ItemsSource = items;
                }
            }
        }
    }
    public class Item
    {
        public String Name { get; set; }
        public String URL { get; set; }
    }
