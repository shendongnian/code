     public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Establish_handlers();
        }
        void Establish_handlers()
        {
            Mybutton.Click += Mybutton_Click;
        }
        private void Mybutton_Click(object sender, RoutedEventArgs e)
        {
            Button clicked_button = (Button)sender;
            TextBlock desired_text = (TextBlock)clicked_button.Content;
            Textbox_Show_Button_Content.Text = desired_text.Text;
        }
    }
    <StackPanel>
        <Button x:Name="Mybutton">
            <TextBlock>Hello</TextBlock>
        </Button>
        <TextBox x:Name="Textbox_Show_Button_Content"></TextBox>
    </StackPanel>
