    //Event hits Window and tunnels through the visual tree
	PreviewMouseDown on WpfApplication10.MainWindow
	PreviewMouseDown on System.Windows.Controls.Border
	PreviewMouseDown on System.Windows.Documents.AdornerDecorator
	PreviewMouseDown on System.Windows.Controls.ContentPresenter
	PreviewMouseDown on System.Windows.Controls.Grid
	PreviewMouseDown on System.Windows.Controls.Button
	PreviewMouseDown on Microsoft.Windows.Themes.ButtonChrome
	PreviewMouseDown on System.Windows.Controls.ContentPresenter
	PreviewMouseDown on System.Windows.Controls.TextBlock
    //Nobody handled the event, so it bubbles back up
	MouseDown on System.Windows.Controls.TextBlock
	MouseDown on System.Windows.Controls.ContentPresenter
	MouseDown on Microsoft.Windows.Themes.ButtonChrome
    //ButtonChrome handled the event as a 'Click'
