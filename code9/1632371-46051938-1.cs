    using System;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;
    namespace ListViewTriggerToHideLabel {
      public partial class MainPage : ContentPage {
        private readonly ObservableCollection<string> _items = new ObservableCollection<string>();
        public MainPage() {
          InitializeComponent();
          TheListView.ItemsSource = _items;
        }
        private void Button_OnClicked(object sender, EventArgs e) {
          _items.Add("Ouch");
        }
      }
    }
