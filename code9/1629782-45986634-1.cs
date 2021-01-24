    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Input;
    using TobyList_XamarinForms.Models;
    using Xamarin.Forms;
    using System.Linq;
    
    namespace TobyList_XamarinForms.ViewModels
    {
    	public class MasterPageViewModel : INotifyPropertyChanged
    	{
            public ObservableCollection<ItemList> lists = new ObservableCollection<ItemList>();
            public ObservableCollection<ItemList> Lists
            {
                get { return lists; }
                set
                {
                    lists = value;
                    OnPropertyChanged("Lists");
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public MasterPageViewModel()
            {
                this.AddListCommand = new Command(() =>
                {
                    OnAddList();
                });
                //this.DeleteListCommand = new Command<ItemList>((sender) =>
                //{
                //	OnDeleteList(sender);
                //});
    
                this.DeleteListCommand = new Command<ViewCell>((sender) =>
                {
                    OnDeleteList(sender);
                });
    
            }
    
            public ICommand AddListCommand { get; protected set; }
    		private void OnAddList()
    		{
    			ItemList itemList = new ItemList() { Id = Guid.NewGuid().ToString().ToUpper(), Name = "Lorem Ipsum", Color = "#000000" };
    			Lists.Add(itemList);
    		}
    
    		public ICommand DeleteListCommand { get; set; }
            //public void OnDeleteList(ItemList itemList)
            //      {
            //          Lists.Remove(itemList);
            //      }
            public void OnDeleteList(ViewCell viewCell)
            {
                viewCell.ContextActions.Clear();
                Lists.Remove((ItemList)viewCell.BindingContext);
            }
    
            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
