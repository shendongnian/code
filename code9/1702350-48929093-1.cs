	public partial class Window1 : Window
	{
		double totalScale = 1;
		
		public Window1()
		{
			InitializeComponent();
			
			for (int i=0; i<60; i++)
			{
				for (int j=0; j<30; j++)
				{
					Button newButton = new Button();
					canvas1.Children.Add(newButton);
					newButton.Width = 25;
					newButton.Height = 25;
					Canvas.SetTop(newButton, j*30);
					Canvas.SetLeft(newButton, i*30);
					newButton.Click += new System.Windows.RoutedEventHandler(button1_Click);
					newButton.MouseMove += new System.Windows.Input.MouseEventHandler(button1_MouseMove);
				}	
			}
		}
		
		Button lastButton;
		
		void button1_Click(object sender, RoutedEventArgs e)
		{
			lastButton = sender as Button;
			lastButton.Background = Brushes.Blue;
		}
		
		void button1_MouseMove(object sender, MouseEventArgs e)
		{
			Button butt = sender as Button;
			if (lastButton != butt) butt.Background = Brushes.Yellow;
		}
		
		void window1_MouseWheel(object sender, MouseWheelEventArgs e)
		{
			double scaleFactor = Math.Pow(1.0005,e.Delta);
			totalScale *= scaleFactor;
			canvas1.LayoutTransform = new ScaleTransform(totalScale, totalScale);
		}
	}
