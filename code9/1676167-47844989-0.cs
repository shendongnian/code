    private async void ImageCell_Tapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MedicationDetailPage((Medication)Medications.SelectedItem));
        // Manually deselect item
        Medications.SelectedItem = null;
    }
