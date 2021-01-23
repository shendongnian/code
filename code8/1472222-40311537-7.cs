    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using DataGridValidation.Annotations;
    using DataGridValidation.Entities;
    namespace DataGridValidation.ViewModels
    {
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel( )
        {
            var random = new Random( );
            for( int i = 0; i < 15; i++ )
            {
                Sales.Add(
                    new SalesFigures
                    {
                        Cake = random.Next( 0, 11 ),
                        Candy = random.Next( 0, 11 ),
                        Chocolate = random.Next( 0, 11 ),
                        Pie = random.Next( 0, 11 )
                    } );
            }
        }
        public ObservableCollection<SalesFigures> Sales { get; } =
            new ObservableCollection<SalesFigures>( );
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged( [CallerMemberName] string propertyName = null )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }
    }
}
