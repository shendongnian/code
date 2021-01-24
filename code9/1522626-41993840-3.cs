     public partial class MainWindow : Window
     {
    
            Model Vars; // = new Model(this); <- the constructor was not yet called, there is no this
            Positions PositionsWindow; // = new Positions();
            Calibration CalibrationWindow; // = new Calibration();
            
            MainWindow(){
                Vars = new Model(this);
                Positions = new Positions(this);
                CalibrationWindow = new Calibration(this);
            }
    
            private void OpenButton_Click(object sender, RoutedEventArgs e)
            {
                    PositionsWindow.Show();
            }
    
            private void TextBoxUpdate_Click(object sender, RoutedEventArgs e)
            {
                    Vars.TestVar = TestBox.Text;
            }
    }
