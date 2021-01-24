    public void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        var things = new List<int>();
        var newStep = Math.Round(e.NewValue/step);
        Random r = new Random();
        for (var i = 0; i < newStep; i++) {
             things.Add(r.Next(i);     
        }
        var cat = string.Join(",", things); 
        label.Text = cat;
    }
