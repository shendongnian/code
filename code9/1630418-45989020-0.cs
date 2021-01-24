    protected override void OnAppearing() {
        this.Appearing += Page_Appearing;                    
        base.OnAppearing();
    }
    private async void Page_Appearing(object sender, EventArgs e) {
        //...call async code here
        await DataBaseService.checkNoteAlarmTimeActive();
        var notes = await loadNotes();
        listNotes.ItemsSource = notes;
        //unsubscribing from the event (optional but advised)
        this.Appearing -= Page_Appearing;
    }
    /// <summary>
    /// Generate list of notes basic on current sorting option and active switcher
    /// </summary>     
    private Task<IEnumerable<Note>> loadNotes()
    {
        return _sorting.sortNotes(_sortOption, _activeSwitcherState);          
    }
