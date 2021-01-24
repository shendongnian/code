    //find by tag or rename upon instantiation as by doing so will result in a "(Clone)" added to its name.
    var d = GameObject.FindGameObjectWithTag("DataBank");
    if (d == null)
    {
        //instantiating it
        DATA = GameObject.Instantiate<DataBank>(DATA_blueprint);
        //intializing the databank itself. The parameters are needed for me,
        // but serve as a good example - all of those are dragged from the inspector to the _INITIALIZER_ but will remain in the whole game as long as databank exists.
        DATA.LoadDataFromINIT(_baseColor, _baseColor2, _outlineColor,
               new MMtoolBundle(DATA));
        //to make it persistent.
        DontDestroyOnLoad(DATA);
    }else
    {
        //in this case the main menu is loaded from another scene.
        //so we only find that loaded object and get its reference, no initialization as it was already setup.
        this.DATA = d.GetComponent<DataBank>();
    }
