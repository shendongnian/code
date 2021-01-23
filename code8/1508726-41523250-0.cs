    searchBtn.IsEnabled = false;
    if (tbOne.SelectedIndex == 0) {
        cbOne.IsEnabled = false;
        tbTwo.IsEnabled = false;
        cbTwo.IsEnabled = false;
        tbThree.IsEnabled = false;
        cbThree.IsEnabled = false;
    } else if (cbOne.SelectedIndex == 0) {
        tbTwo.IsEnabled = false;
        cbTwo.IsEnabled = false;
        tbThree.IsEnabled = false;
        cbThree.IsEnabled = false;
    } else if (tbTwo.SelectedIndex == 0) {
        cbTwo.IsEnabled = false;
        tbThree.IsEnabled = false;
        cbThree.IsEnabled = false;
    } else if (cbTwo.SelectedIndex == 0) {
        tbThree.IsEnabled = false;
        cbThree.IsEnabled = false;
    } else if (tbThree.SelectedIndex == 0) {
        cbThree.IsEnabled = false;
    }
