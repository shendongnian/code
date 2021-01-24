    void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
        var item = ((FrameworkElement) e.OriginalSource).DataContext
        var myItem = item as *CastToWhateverTypeYouNeed*
        if (item != null){
            //Here you have your item
        }
    }
