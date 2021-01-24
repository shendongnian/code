    public class TextControl
    {
      public string TextValue { get; set; }
    }
.
    <DataTemplate DataType="{x:Type yourNameSpace:TextControl}">
      <TextBox Text="{Binding TextValue}" />
    </DataTemplate>
