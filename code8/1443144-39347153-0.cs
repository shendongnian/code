    <ListBox x:Name="ListBox1">
        <ListBoxItem Content="None"/>
        <ListBoxItem Content="Odd"/>
        <ListBoxItem Content="Even"/>
    </ListBox>
    string strNotepad = strNotepad + objReader.ReadLine();
    int dec = int.Parse(strNotepad, System.Globalization.NumberStyles.HexNumber);
    ListBox1.SelectedIndex = (dec % 2) == 1 ? 1 : 2;
