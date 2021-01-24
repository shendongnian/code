    var p = this.Application.ActivePresentation; //your presentation
    var titles = new List<Shape>();
    for (int i = 0; i < p.Slides.Count; i++)
    {
       titles.Add(p.Slides[i].Shapes.Title);
    }
