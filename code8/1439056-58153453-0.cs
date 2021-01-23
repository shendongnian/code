 csharp
public enum ChannelMark
{
   Undefinned,Left, Right,Front, Back
}
ViewModel
csharp
private ChannelMark _ChannelMark = ChannelMark.Undefinned;
public ChannelMark ChannelMark
{
    get => _ChannelMark;
    set => Set(ref _ChannelMark, value);
}
private List<int> _ChannelMarksInts = Enum.GetValues(typeof(ChannelMark)).Cast<ChannelMark>().Cast<int>().ToList();
public List<int> ChannelMarksInts
{
    get => _ChannelMarksInts;
    set => Set(ref _ChannelMarksInts, value);
}
XAML
xml
<ComboBox ItemsSource="{x:Bind ViewModel.ChannelMarksInts}"  SelectedItem="{x:Bind ViewModel.ChannelMark, Converter={StaticResource ChannelMarkToIntConverter}, Mode=TwoWay}">
    <ComboBox.ItemTemplate>
        <DataTemplate>
            <TextBlock Text="{Binding  Converter={StaticResource IntToChannelMarkConverter}}"/>
        </DataTemplate>
    </ComboBox.ItemTemplate>
</ComboBox>
Converters:
csharp
switch ((ChannelMark)value)
{
    case ChannelMark.Undefinned:
        return "Undefinned mark";
    case ChannelMark.Left:
        //translation
        return Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView().GetString("ChannelMarkEnumLeft");
    case ChannelMark.Right:
        return "Right Channel";
    case ChannelMark.Front:
        return "Front Channel";
    case ChannelMark.Back:
        return "Back Channel";
    default:
        throw new NotImplementedException();
}
public class IntToChannelMarkConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language) => ((ChannelMark)value).ToString();
    public object ConvertBack(object value, Type targetType, object parameter, string language) => throw new NotImplementedException();
}
