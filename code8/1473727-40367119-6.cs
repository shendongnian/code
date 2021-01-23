    <#@ template language="C#" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ parameter name="Model" type="System.Collections.Generic.List<ReportColumn>"#>
    <?xml version="1.0" encoding="utf-8"?>
    <Report xmlns:rd="http://schemas.microsoft.com/SQLServer/reporting/reportdesigner" xmlns="http://schemas.microsoft.com/sqlserver/reporting/2008/01/reportdefinition">
      <DataSources>
        <DataSource Name="DataSource1">
          <ConnectionProperties>
            <DataProvider>System.Data.DataSet</DataProvider>
            <ConnectString>/* Local Connection */</ConnectString>
          </ConnectionProperties>
          <rd:DataSourceID>e9784bb0-a630-49cc-b7f9-8495aca23a6c</rd:DataSourceID>
        </DataSource>
      </DataSources>
      <DataSets>
        <DataSet Name="DataSet1">
          <Fields>
    <#    foreach(ReportColumn column in Model){#>
            <Field Name="<#=column.Name#>">
              <DataField><#=column.Name#></DataField>
              <rd:TypeName><#=column.Type.Name#></rd:TypeName>
            </Field>
    <#    }#>
          </Fields>
          <Query>
            <DataSourceName>DataSource1</DataSourceName>
            <CommandText>/* Local Query */</CommandText>
          </Query>
          <rd:DataSetInfo>
            <rd:DataSetName />
            <rd:TableName />
            <rd:ObjectDataSourceType />
          </rd:DataSetInfo>
        </DataSet>
      </DataSets>
      <Body>
        <ReportItems>
          <Tablix Name="Tablix1">
            <TablixBody>
              <TablixColumns>
    <#    foreach(ReportColumn column in Model){#>
                <TablixColumn>
                  <Width><#=column.WidthInInch#>in</Width>
                </TablixColumn>
    <#    }#>
              </TablixColumns>
              <TablixRows>
                <TablixRow>
                  <Height>0.25in</Height>
                  <TablixCells>
    <#    foreach(ReportColumn column in Model){#>
                    <TablixCell>
                      <CellContents>
                        <Textbox Name="<#=column.Name#>TextBox">
                          <CanGrow>true</CanGrow>
                          <KeepTogether>true</KeepTogether>
                          <Paragraphs>
                            <Paragraph>
                              <TextRuns>
                                <TextRun>
                                  <Value><#=column.Title#></Value>
                                  <Style />
                                </TextRun>
                              </TextRuns>
                              <Style />
                            </Paragraph>
                          </Paragraphs>
                          <rd:DefaultName><#=column.Name#>TextBox</rd:DefaultName>
                          <Style>
                            <Border>
                              <Color>LightGrey</Color>
                              <Style>Solid</Style>
                            </Border>
                            <BackgroundColor><#=column.HeaderBackColorInHtml#></BackgroundColor>
                            <PaddingLeft>2pt</PaddingLeft>
                            <PaddingRight>2pt</PaddingRight>
                            <PaddingTop>2pt</PaddingTop>
                            <PaddingBottom>2pt</PaddingBottom>
                          </Style>
                        </Textbox>
                      </CellContents>
                    </TablixCell>
    <#    }#>
                  </TablixCells>
                </TablixRow>
                <TablixRow>
                  <Height>0.25in</Height>
                  <TablixCells>
    <#    foreach(ReportColumn column in Model){#>
                    <TablixCell>
                      <CellContents>
                        <Textbox Name="<#=column.Name#>">
                          <CanGrow>true</CanGrow>
                          <KeepTogether>true</KeepTogether>
                          <Paragraphs>
                            <Paragraph>
                              <TextRuns>
                                <TextRun>
                                  <Value><#=column.Expression#></Value>
                                  <Style />
                                </TextRun>
                              </TextRuns>
                              <Style />
                            </Paragraph>
                          </Paragraphs>
                          <rd:DefaultName><#=column.Name#></rd:DefaultName>
                          <Style>
                            <Border>
                              <Color>LightGrey</Color>
                              <Style>Solid</Style>
                            </Border>
                            <PaddingLeft>2pt</PaddingLeft>
                            <PaddingRight>2pt</PaddingRight>
                            <PaddingTop>2pt</PaddingTop>
                            <PaddingBottom>2pt</PaddingBottom>
                          </Style>
                        </Textbox>
                      </CellContents>
                    </TablixCell>
    <#    }#>
                  </TablixCells>
                </TablixRow>
              </TablixRows>
            </TablixBody>
            <TablixColumnHierarchy>
              <TablixMembers>
    <#    foreach(ReportColumn column in Model){#>
                <TablixMember />
    <#    }#>
              </TablixMembers>
            </TablixColumnHierarchy>
            <TablixRowHierarchy>
              <TablixMembers>
                <TablixMember>
                  <KeepWithGroup>After</KeepWithGroup>
                </TablixMember>
                <TablixMember>
                  <Group Name="Details" />
                </TablixMember>
              </TablixMembers>
            </TablixRowHierarchy>
            <DataSetName>DataSet1</DataSetName>
            <Top>0.15625in</Top>
            <Left>0.125in</Left>
            <Height>0.5in</Height>
            <Width>2in</Width>
            <Style>
              <Border>
                <Style>None</Style>
              </Border>
            </Style>
          </Tablix>
        </ReportItems>
        <Height>0.82292in</Height>
        <Style />
      </Body>
      <Width>6.5in</Width>
      <Page>
        <LeftMargin>1in</LeftMargin>
        <RightMargin>1in</RightMargin>
        <TopMargin>1in</TopMargin>
        <BottomMargin>1in</BottomMargin>
        <Style />
      </Page>
      <rd:ReportID>60987c40-62b1-463b-b670-f3fa81914e33</rd:ReportID>
      <rd:ReportUnitType>Inch</rd:ReportUnitType>
    </Report>
