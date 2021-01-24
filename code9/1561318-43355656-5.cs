    using System;
    using System.Windows;
    using System.Windows.Input;
    using Fruits.ViewModels;
    namespace Fruits
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new MainViewModel();
                ViewModel.AddNewFruit("Jackfruit", "Yellow");
                ViewModel.AddNewFruit("Watermelon", "ForestGreen");
                ViewModel.AddNewFruit("Apple", "Red");
                ViewModel.AddNewFruit("Banana", "Yellow");
                ViewModel.AddNewFruit("Orange", "DeepSkyBlue");
            }
            public MainViewModel ViewModel { get { return DataContext as MainViewModel; } }
            private void AddFruitCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
            {
                ViewModel.AddNewFruit();
            }
            private void AddFruitCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                e.CanExecute =
                    ViewModel != null
                    && !String.IsNullOrWhiteSpace(ViewModel.NewFruitName)
                    && !String.IsNullOrWhiteSpace(ViewModel.NewFruitColor)
                    ;
            }
        }
    }
