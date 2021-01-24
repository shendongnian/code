    <Grid>
        <Grid.RenderTransform>
            <ScaleTransform ScaleX="2" ScaleY="2" />
        </Grid.RenderTransform>
        <FlowDocumentScrollViewer>
            <FlowDocument>
                <FlowDocument.Blocks>
                    <Table x:Name="MyTable">
                        <Table.Columns>
                            <TableColumn />
                        </Table.Columns>
                        <Table.RowGroups>
                            <TableRowGroup>
                                <TableRow>
                                    <TableCell Background="Pink">
                                        <Paragraph Background="LightBlue">
                                            <Run Background="PaleGoldenrod">0123456789Aj</Run>
                                        </Paragraph>
                                    </TableCell>
                                </TableRow>
                                <TableRow>
                                    <TableCell Background="Pink">
                                        <Paragraph Background="LightBlue">
                                            <Run Background="PaleGoldenrod">0123456789Aj</Run>
                                        </Paragraph>
                                    </TableCell>
                                </TableRow>
                            </TableRowGroup>
                        </Table.RowGroups>
                    </Table>
                    <Paragraph Background="LightSkyBlue" Margin="0">
                        <Run>0123456789Aj</Run>
                    </Paragraph>
                    <Paragraph Background="LightSkyBlue" Margin="0">
                        <Run>0123456789Aj</Run>
                    </Paragraph>
                </FlowDocument.Blocks>
            </FlowDocument>
        </FlowDocumentScrollViewer>
        <Label Content="{Binding CellSpacing, ElementName=MyTable}" />
    </Grid>
