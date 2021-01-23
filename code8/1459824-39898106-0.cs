    public class MainWindowViewModel
    {
        public string Text { get; set; }
    }
    [TestFixture, Apartment(ApartmentState.STA)]
    public class WPFTest
    {
        [Test]
        public void SetTextBox()
        {
            //Arrange
            var expected = "I want to set this";
            var view = new MainWindow();
            var viewmodel = new MainWindowViewModel();
            view.DataContext = viewmodel;
            //Act
            view.MyTextBox.Text = expected;
            //Assert
            Assert.AreEqual(expected, viewmodel.Text);
        }
    }
