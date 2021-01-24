var availableFonts = CanvasFontSet.GetSystemFontSet().Fonts;
foreach (var font in availableFonts)
{
    var familyNames = new List<string>();
    foreach (var familyName in font.FamilyNames) 
    {
        familyNames.Add(familyName.Value);
    }
                
    Debug.WriteLine(string.Join(", ", familyNames.Distinct()));
}
