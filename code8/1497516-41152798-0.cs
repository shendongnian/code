    using Prism.Commands;
    using System;
    using System.Collections.Generic;
    using Prism.Mvvm;
    using System.Collections.ObjectModel;
    using Models;
    using System.Threading.Tasks;
    public class ItemsViewModel : BindableBase
    {
        private MyFacade facade;
        public ItemsViewModel()
        {
            facade = new MyFacade();
            Items = new ObservableCollection<Item>();
        }
        public ObservableCollection<Item> Items { get; private set; }
        public DelegateCommand GetDataCommand => new DelegateCommand(GetData);
        private async void GetData()
        {
            // it's the best practice to wrap an async void and use an async Task
            await GetItems();
        }
        private async Task GetItems()
        {
            // not really async
            var result =  await facade.GetItems();
            Items.Clear();
            Items.AddRange(result);
        }
        class MyFacade
        {
            public async Task<List<Item>> GetItems()
            {
                // not really async
                var items = new List<Item>();
                items.Add(new Item { Name = "Joe", Date = DateTime.Now });
                items.Add(new Item { Name = "Bob", Date = DateTime.Now });
                items.Add(new Item { Name = "Sam", Date = DateTime.Now });
                return items;
            }
        }
    }
