        <ContentControl x:Name="cc">
            <ContentControl.ContentTemplate>
                <DataTemplate>
                    <StackPanel>
                        <Image Source="{Binding Image}" />
                        <TextBlock Text="{Binding Caption}" />
                    </StackPanel>
                </DataTemplate>
            </ContentControl.ContentTemplate>
        </ContentControl>
