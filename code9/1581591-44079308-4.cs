    using System;
    using System.Windows;
    					
    public class Program
    {
    	public static void Main()
    	{
            var foo = new Foo();
    
    		Console.WriteLine( "Set foo.Bar to 1" );
            foo.Bar = 1;
            Console.WriteLine( "Set foo.Bar to 1 (assigning the same value)" );
            foo.Bar = 1;
            Console.WriteLine( "Set foo.Bar to 2" );
            foo.Bar = 2;
    	}
    }
    
    public class Foo : DependencyObject
    {
        public int Bar
        {
            get { return (int) GetValue( BarProperty ); }
            set { SetValue( BarProperty, value ); }
        }
    
        public static readonly DependencyProperty BarProperty =
            DependencyProperty.Register(
                "Bar",
                typeof( int ),
                typeof( Foo ),
                new PropertyMetadata(
                    defaultValue: 0,
                    propertyChangedCallback: new PropertyChangedCallback( OnBarChanged ) ) );
    
        private static void OnBarChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
        {
            Console.WriteLine( "OnBarChanged: Property has changed from '{0}' to '{1}'", e.OldValue, e.NewValue );
        }
    }
