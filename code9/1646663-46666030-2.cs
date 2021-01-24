	using System;
	using System.Windows.Input;
	using System.Windows.Media;
	namespace WpfApp1
	{
		/// <summary>
		/// Interaction logic for MainWindow.xaml
		/// </summary>
		public partial class MainWindow
		{
			public MainWindow()
			{
				InitializeComponent();
				Test.MouseEnter += TestOnMouseEnter;
				Test.MouseLeave += TestOnMouseLeave;
				MouseDown += OnMouseDown;
			}
			private void TestOnMouseEnter(object sender, MouseEventArgs mouseEventArgs)
			{
				Console.WriteLine("(Test) MouseEnter");
				Test.Fill = Brushes.Coral;
			}
			private void TestOnMouseLeave(object sender, MouseEventArgs mouseEventArgs)
			{
				Console.WriteLine("(Test) MouseLeave");
				Test.Fill = Brushes.Blue;
			}
			private void OnMouseMove(object sender, MouseEventArgs mouseEventArgs)
			{
				Console.WriteLine("(Window) MouseMove");
				var pos = NativeMouseHook.GetMousePosition();
				Line.X2 = pos.X;
				Line.Y2 = pos.Y;
			}
			private void OnMouseDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
			{
				Console.WriteLine("(Window) MouseDown");
				NativeMouseHook.RegisterMouseHandler(NativeMouseHook.MouseMessages.WM_MOUSEMOVE, (MouseEventHandler)OnMouseMove);
				NativeMouseHook.RegisterMouseHandler(NativeMouseHook.MouseMessages.WM_LBUTTONUP, OnMouseUp);
				var pos = mouseButtonEventArgs.GetPosition(this);
				Line.X1 = pos.X;
				Line.Y1 = pos.Y;
			}
			
			private void OnMouseUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
			{
				Console.WriteLine("(Window) MouseUp");
				NativeMouseHook.UnregisterMouseHandler(NativeMouseHook.MouseMessages.WM_MOUSEMOVE, (MouseEventHandler)OnMouseMove);
				NativeMouseHook.UnregisterMouseHandler(NativeMouseHook.MouseMessages.WM_LBUTTONUP, OnMouseUp);
			}
		}
	}
