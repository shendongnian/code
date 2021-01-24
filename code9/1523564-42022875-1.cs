    <GridViewColumn Header="Image">
        <GridViewColumn.CellTemplate>
            <DataTemplate>
                <Image Source="{Binding GuestImage}" />
            </DataTemplate>
        </GridViewColumn.CellTemplate>
    </GridViewColumn>
----------
    public class YourDataClass
    {
        public Uri GuestImage
        {
            get { return new Uri(@"c:\picture.png", UriKind.RelativeOrAbsolute); }
        }
        //+ the other properties...
    }
