    var controlsToHide = new List<Control>();
    controlsToHide.Add(myButton);
    controlsToHide.Add(otherButton);
    HideAll(controlsToHide);
    
    public void HideAll(List<Control> controls) {
        foreach(var ctrl in controls) {
            ctrl.Visisble = false;
        }
    }
