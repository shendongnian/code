    private void OnBtnClick(string obj)
    {
        _page2Text = "Changing by button click";
    }
The problem is that you are changing the underlying _page2Text member, but in order for WPF to detect this change, you must use the Page2Text property, like this:
    private void OnBtnClick(string obj)
    {
        Page2Text = "Changing by button click";
    }
The specific part of your code that is indicating the property change to WPF is the OnPropertyChanged method in your BindableBase class.
