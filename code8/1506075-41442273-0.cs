    object oBasic = Application.WordBasic;
    object fIsAutoSave =
            oBasic.GetType().InvokeMember(
                "IsAutosaveEvent",
                BindingFlags.GetProperty,
                null, oBasic, null);
    if (int.Parse(fIsAutoSave.ToString()) == 1)
        MessageBox.Show("Is AutoSave");
    else
        MessageBox.Show("Is regular save");
