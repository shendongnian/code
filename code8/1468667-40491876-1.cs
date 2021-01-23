        <TabControl x:Name="tabControl">
            <TabItem Header="1'st Tab">
                <ContentControl Content="{Binding .}">
                    <ContentControl.ContentTemplate>
                        <DataTemplate>
                            <Button Content="Do no thing"></Button>
                        </DataTemplate>
                    </ContentControl.ContentTemplate>
                </ContentControl>
            </TabItem>
            <TabItem Header="2'nd Tab">
                <ContentControl Content="{Binding .}">
                    <ContentControl.ContentTemplate>
                        <DataTemplate>
                            <local:UserControl1/>
                        </DataTemplate>
                    </ContentControl.ContentTemplate>
                </ContentControl>
            </TabItem>
        </TabControl>
