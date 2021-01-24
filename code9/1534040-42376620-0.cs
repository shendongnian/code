    Slider dbSlider = new Slider();
    dbSlider.Name = slider.Name;
    dbSlider.Whatever = slider.Whatever;
    ....  
    db.Sliders.Attach(dbSlider);
    db.Entry(dbSlider).State = EntityState.Modified;
    db.SaveChanges();
