    <ManagementPack ContentReadable="true" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
      <Manifest>
        <Identity>
          <ID>CloudMonix.ResourceMonitoring</ID>
          <Version>1.0.0.6</Version>
        </Identity>
        <Name>CloudMonix.ResourceMonitoring</Name>
        <References>
          <Reference Alias="SC">
            <ID>Microsoft.SystemCenter.Library</ID>
            <Version>6.1.7221.0</Version>
            <PublicKeyToken>31bf3856ad364e35</PublicKeyToken>
          </Reference>
          <Reference Alias="Windows">
            <ID>Microsoft.Windows.Library</ID>
            <Version>6.1.7221.0</Version>
            <PublicKeyToken>31bf3856ad364e35</PublicKeyToken>
          </Reference>
          <Reference Alias="Health">
            <ID>System.Health.Library</ID>
            <Version>6.1.7221.0</Version>
            <PublicKeyToken>31bf3856ad364e35</PublicKeyToken>
          </Reference>
          <Reference Alias="System">
            <ID>System.Library</ID>
            <Version>6.1.7221.0</Version>
            <PublicKeyToken>31bf3856ad364e35</PublicKeyToken>
          </Reference>
        </References>
      </Manifest>
      <TypeDefinitions>
        <EntityTypes>
          <ClassTypes>
            <ClassType ID="CloudMonix.ResourceMonitoring.Resource" Accessibility="Public" Abstract="false" Base="System!System.Entity" Hosted="false" Singleton="false">
              <Property ID="ResourceId" Type="string" Key="true" CaseSensitive="false" MinLength="1" Length="256" />
              <Property ID="ResourceType" Type="string" Key="false" CaseSensitive="false" MinLength="1" Length="256" />
              <Property ID="ResourceStatus" Type="string" Key="false" CaseSensitive="false" MinLength="1" Length="256" />
              <Property ID="ResourceGroups" Type="string" Key="false" CaseSensitive="false" MinLength="1" Length="1024" />
            </ClassType>
          </ClassTypes>
        </EntityTypes>
        <ModuleTypes>
          <DataSourceModuleType ID="CloudMonix.ResourceMonitoring.ResourceStatus.DataSource" Accessibility="Internal" Batching="false">
            <Configuration>
              <xsd:element minOccurs="1" name="IntervalSeconds" type="xsd:integer" xmlns:xsd="http://www.w3.org/2001/XMLSchema" />
              <xsd:element minOccurs="0" name="SyncTime" type="xsd:string" xmlns:xsd="http://www.w3.org/2001/XMLSchema" />
              <xsd:element minOccurs="1" name="ResourceStatus" type="xsd:string" xmlns:xsd="http://www.w3.org/2001/XMLSchema" />
            </Configuration>
            <OverrideableParameters>
              <OverrideableParameter ID="IntervalSeconds" Selector="$Config/IntervalSeconds$" ParameterType="int" />
              <OverrideableParameter ID="SyncTime" Selector="$Config/SyncTime$" ParameterType="string" />
            </OverrideableParameters>
            <ModuleImplementation>
              <Composite>
                <MemberModules>
                  <DataSource ID="DS_Scheduler" TypeID="System!System.Scheduler">
                    <Scheduler>
                      <SimpleReccuringSchedule>
                        <Interval Unit="Seconds">$Config/IntervalSeconds$</Interval>
                        <SyncTime>$Config/SyncTime$</SyncTime>
                      </SimpleReccuringSchedule>
                      <ExcludeDates />
                    </Scheduler>
                  </DataSource>
                  <ProbeAction ID="PA_PackageData" TypeID="Windows!Microsoft.Windows.PowerShellPropertyBagProbe">
                    <ScriptName>Set-PropertyBagWithValue.ps1</ScriptName>
                    <ScriptBody>
                      
    param($data)
    $api = New-Object -comObject 'MOM.ScriptAPI'
    $bag = $api.CreatePropertyBag()
    $bag.AddValue("ResourceStatus", $data)
    $bag
                      
                    </ScriptBody>
                    <Parameters>
                      <Parameter>
                        <Name>data</Name>
                        <Value>$Config/ResourceStatus$</Value>
                      </Parameter>
                    </Parameters>
                    <TimeoutSeconds>300</TimeoutSeconds>
                  </ProbeAction>
                </MemberModules>
                <Composition>
                  <Node ID="PA_PackageData">
                    <Node ID="DS_Scheduler" />
                  </Node>
                </Composition>
              </Composite>
            </ModuleImplementation>
            <OutputType>System!System.PropertyBagData</OutputType>
          </DataSourceModuleType>
        </ModuleTypes>
        <MonitorTypes>
          <UnitMonitorType ID="CloudMonix.ResourceMonitoring.ResourceStatus.MonitorType" Accessibility="Internal">
            <MonitorTypeStates>
              <MonitorTypeState ID="Ready" NoDetection="false" />
              <MonitorTypeState ID="Down" NoDetection="false" />
            </MonitorTypeStates>
            <Configuration>
              <xsd:element minOccurs="1" name="IntervalSeconds" type="xsd:integer" xmlns:xsd="http://www.w3.org/2001/XMLSchema" />
              <xsd:element minOccurs="0" name="SyncTime" type="xsd:string" xmlns:xsd="http://www.w3.org/2001/XMLSchema" />
              <xsd:element minOccurs="1" name="ResourceStatus" type="xsd:string" xmlns:xsd="http://www.w3.org/2001/XMLSchema" />
            </Configuration>
            <OverrideableParameters>
              <OverrideableParameter ID="IntervalSeconds" Selector="$Config/IntervalSeconds$" ParameterType="int" />
              <OverrideableParameter ID="SyncTime" Selector="$Config/SyncTime$" ParameterType="string" />
            </OverrideableParameters>
            <MonitorImplementation>
              <MemberModules>
                <DataSource ID="DS_ResourceStatus" TypeID="CloudMonix.ResourceMonitoring.ResourceStatus.DataSource">
                  <IntervalSeconds>$Config/IntervalSeconds$</IntervalSeconds>
                  <SyncTime>$Config/SyncTime$</SyncTime>
                  <ResourceStatus>$Config/ResourceStatus$</ResourceStatus>
                </DataSource>
                <ConditionDetection ID="CD_Ready" TypeID="System!System.ExpressionFilter">
                  <Expression>
                    <SimpleExpression>
                      <ValueExpression>
                        <XPathQuery Type="String">Property[@Name='ResourceStatus']</XPathQuery>
                      </ValueExpression>
                      <Operator>Equal</Operator>
                      <ValueExpression>
                        <Value Type="String">Ready</Value>
                      </ValueExpression>
                    </SimpleExpression>
                  </Expression>
                </ConditionDetection>
                <ConditionDetection ID="CD_Down" TypeID="System!System.ExpressionFilter">
                  <Expression>
                    <SimpleExpression>
                      <ValueExpression>
                        <XPathQuery Type="String">Property[@Name='ResourceStatus']</XPathQuery>
                      </ValueExpression>
                      <Operator>Equal</Operator>
                      <ValueExpression>
                        <Value Type="String">Down</Value>
                      </ValueExpression>
                    </SimpleExpression>
                  </Expression>
                </ConditionDetection>
              </MemberModules>
              <RegularDetections>
                <RegularDetection MonitorTypeStateID="Ready">
                  <Node ID="CD_Ready">
                    <Node ID="DS_ResourceStatus" />
                  </Node>
                </RegularDetection>
                <RegularDetection MonitorTypeStateID="Down">
                  <Node ID="CD_Down">
                    <Node ID="DS_ResourceStatus" />
                  </Node>
                </RegularDetection>
              </RegularDetections>
            </MonitorImplementation>
          </UnitMonitorType>
        </MonitorTypes>
      </TypeDefinitions>
      <Monitoring>
        <Monitors>
          <UnitMonitor ID="CloudMonix.ResourceMonitoring.ResourceStatus.UnitMonitor" Accessibility="Public" Enabled="true" Target="CloudMonix.ResourceMonitoring.Resource" ParentMonitorID="Health!System.Health.AvailabilityState" Remotable="true" Priority="Normal" TypeID="CloudMonix.ResourceMonitoring.ResourceStatus.MonitorType" ConfirmDelivery="false">
            <Category>AvailabilityHealth</Category>
            <AlertSettings AlertMessage="CloudMonix.ResourceMonitoring.ResourceStatus.UnitMonitor.AlertMessage">
              <AlertOnState>Error</AlertOnState>
              <AutoResolve>true</AutoResolve>
              <AlertPriority>Normal</AlertPriority>
              <AlertSeverity>MatchMonitorHealth</AlertSeverity>
            </AlertSettings>
            <OperationalStates>
              <OperationalState ID="Ready" MonitorTypeStateID="Ready" HealthState="Success" />
              <OperationalState ID="Down" MonitorTypeStateID="Down" HealthState="Error" />
            </OperationalStates>
            <Configuration>
              <IntervalSeconds>300</IntervalSeconds>
              <SyncTime />
              <ResourceStatus>$Target/Property[Type="CloudMonix.ResourceMonitoring.Resource"]/ResourceStatus$</ResourceStatus>
            </Configuration>
          </UnitMonitor>
        </Monitors>
      </Monitoring>
      <Presentation>
        <Views>
          <View ID="CloudMonix.ResourceMonitoring.MainView" Accessibility="Public" Enabled="true" Target="CloudMonix.ResourceMonitoring.Resource" TypeID="SC!Microsoft.SystemCenter.StateViewType" Visible="true">
            <Category>Operations</Category>
            <Criteria>
              <InMaintenanceMode>false</InMaintenanceMode>
            </Criteria>
            <Presentation>
              <ColumnInfo Index="0" SortIndex="0" Width="100" Grouped="false" Sorted="true" IsSortable="true" Visible="true" SortOrder="Descending">
                <Name>State</Name>
                <Id>CloudMonix.ResourceMonitoring.Resource</Id>
              </ColumnInfo>
              <ColumnInfo Index="1" SortIndex="-1" Width="100" Grouped="false" Sorted="false" IsSortable="true" Visible="true" SortOrder="Ascending">
                <Name>Resource Type</Name>
                <Id>ResourceType</Id>
              </ColumnInfo>
              <ColumnInfo Index="2" SortIndex="-1" Width="100" Grouped="false" Sorted="false" IsSortable="true" Visible="true" SortOrder="Ascending">
                <Name>Resource Name</Name>
                <Id>DisplayName</Id>
              </ColumnInfo>
              <ColumnInfo Index="3" SortIndex="-1" Width="100" Grouped="false" Sorted="false" IsSortable="true" Visible="true" SortOrder="Ascending">
                <Name>Resource Status</Name>
                <Id>ResourceStatus</Id>
              </ColumnInfo>
              <ColumnInfo Index="4" SortIndex="-1" Width="100" Grouped="false" Sorted="false" IsSortable="true" Visible="true" SortOrder="Ascending">
                <Name>Resource Groups</Name>
                <Id>ResourceGroups</Id>
              </ColumnInfo>
            </Presentation>
            <Target />
          </View>
        </Views>
        <Folders>
          <Folder ID="CloudMonix.ResourceMonitoring.MainFolder" Accessibility="Public" ParentFolder="SC!Microsoft.SystemCenter.Monitoring.ViewFolder.Root" />
        </Folders>
        <FolderItems>
          <FolderItem ElementID="CloudMonix.ResourceMonitoring.MainView" Folder="CloudMonix.ResourceMonitoring.MainFolder" />
        </FolderItems>
        <StringResources>
          <StringResource ID="CloudMonix.ResourceMonitoring.ResourceStatus.UnitMonitor.AlertMessage" />
        </StringResources>
      </Presentation>
      <LanguagePacks>
        <LanguagePack ID="ENU" IsDefault="true">
          <DisplayStrings>
            <DisplayString ElementID="CloudMonix.ResourceMonitoring">
              <Name>CloudMonix Resource Monitoring</Name>
              <Description></Description>
            </DisplayString>
            <DisplayString ElementID="CloudMonix.ResourceMonitoring.MainFolder">
              <Name>CloudMonix Folder</Name>
              <Description></Description>
            </DisplayString>
            <DisplayString ElementID="CloudMonix.ResourceMonitoring.MainView">
              <Name>CloudMonix Resource View</Name>
              <Description></Description>
            </DisplayString>
            <DisplayString ElementID="CloudMonix.ResourceMonitoring.Resource">
              <Name>CloudMonix Resource</Name>
              <Description></Description>
            </DisplayString>
            <DisplayString ElementID="CloudMonix.ResourceMonitoring.Resource" SubElementID="ResourceId">
              <Name>Resource Id</Name>
              <Description></Description>
            </DisplayString>
            <DisplayString ElementID="CloudMonix.ResourceMonitoring.Resource" SubElementID="ResourceType">
              <Name>Resource Type</Name>
              <Description></Description>
            </DisplayString>
            <DisplayString ElementID="CloudMonix.ResourceMonitoring.Resource" SubElementID="ResourceStatus">
              <Name>Resource Status</Name>
              <Description></Description>
            </DisplayString>
            <DisplayString ElementID="CloudMonix.ResourceMonitoring.Resource" SubElementID="ResourceGroups">
              <Name>Resource Groups</Name>
              <Description></Description>
            </DisplayString>
            <DisplayString ElementID="CloudMonix.ResourceMonitoring.ResourceStatus.UnitMonitor">
              <Name>Resource Status Unit Monitor</Name>
              <Description>Resource Status Unit Monitor</Description>
            </DisplayString>
            <DisplayString ElementID="CloudMonix.ResourceMonitoring.ResourceStatus.UnitMonitor.AlertMessage">
              <Name>Alert</Name>
              <Description>Alert</Description>
            </DisplayString>
            <DisplayString ElementID="CloudMonix.ResourceMonitoring.ResourceStatus.UnitMonitor" SubElementID="Ready">
              <Name>Ready</Name>
              <Description>Ready</Description>
            </DisplayString>
            <DisplayString ElementID="CloudMonix.ResourceMonitoring.ResourceStatus.UnitMonitor" SubElementID="Down">
              <Name>Down</Name>
              <Description>Down</Description>
            </DisplayString>
          </DisplayStrings>
          <KnowledgeArticles></KnowledgeArticles>
        </LanguagePack>
      </LanguagePacks>
    </ManagementPack>
