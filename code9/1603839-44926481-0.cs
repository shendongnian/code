    void OnSalesReport(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			YourItemModel item = (YourItemModel)((ListView)sender).SelectedItem;
			((ListView)sender).SelectedItem = null;
			Navigation.PushAsync(new NextPage(item));
		}
