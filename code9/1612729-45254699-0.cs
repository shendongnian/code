    public void setSeletedValue(int id)
    {
        var allTruckTypes = truckypessqlite.GetAllTruckTypes();
        int index = allTruckTypes.FindIndex(t => t.id == id);
        if (index != -1)
        {
            truck_trypes_combo.SelectedIndex = index;
        }
    }
