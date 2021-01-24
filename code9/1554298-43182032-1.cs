    for (int i = 0; i < listBox1.Items.Count; i++)
    {
        for (int j = 0; j < listBox2.Items.Count; j++)
        {
            stwr.WriteLine($"googleMap.addMarker(new MarkerOptions().position(new LatLng({ listBox1.Items[i] }, { listBox2.Items[j] })).title(\"A place\"));");
        }
    }
