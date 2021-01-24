        private void HlRmv_OnClick(object sender, RoutedEventArgs e)
        {
            var link = sender as Hyperlink;
            var Ip = link.Tag as string;
            // your logic of removing the code here. Reload collection
            var result = psList.Where(item => item.Ip.Equals(Ip));
            psList.Remove(result);
        }
