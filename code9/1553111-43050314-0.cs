    private void button2_Click(object sender, EventArgs e)
    {
        using (StreamWriter stwr = new StreamWriter(path))
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                stwr.WriteLine("googleMap.addMarker(new MarkerOptions().position(new LatLng(" + listBox1.Items[i] + ", " + "ii" + i + ")).title(" + "bbb" + "));");
            }
            stwr.Close();
            string text = File.ReadAllText("latlong.txt");
            for (int ii = 0; ii < listBox2.Items.Count; ii++)
            {
                text = text.Replace("ii"+ii, Convert.ToString(listBox2.Items[ii]));
            }
            File.WriteAllText("latlong.txt", text);
        }
    }
