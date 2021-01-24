     public partial class MainWindow : Window
     {
    
            Model Vars; // = new Model();
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
