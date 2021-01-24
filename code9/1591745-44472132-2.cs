    <ItemGroup>
      <Content Include="a.foo;b.foo;a.vb;b.vb"/> <!-- sample items -->
    </ItemGroup>
    
    <Target Name="FilterExamples">
      <ItemGroup>
       <AllFilesUsingCondition Include="%(Content.Identity)" Condition="'%(Extension)' != '.vb'"/>
    
       <VbFiles Include="%(Content.Identity)" Condition="'%(Extension)' == '.vb'"/>
       <AllFilesUsingExclude Include="%(Content.Identity)" Exclude="@(VbFiles)"/>
    
       <AllFilesUsingRemove Include="%(Content.Identity)"/>
       <AllFilesUsingRemove Remove="@(VbFiles)"/>
    
       <AllFilesUsingRemoveCondition Include="%(Content.Identity)"/>
       <AllFilesUsingRemoveCondition Remove="@(AllFilesUsingRemoveCondition)" Condition="'%(Extension)' == '.vb'"/>
      </ItemGroup>
    
      <Message Text="AllFilesUsingCondition=@(AllFilesUsingCondition)" />
      <Message Text="AllFilesUsingExclude=@(AllFilesUsingExclude)" />
      <Message Text="AllFilesUsingRemove=@(AllFilesUsingRemove)" />
      <Message Text="AllFilesUsingRemoveCondition=@(AllFilesUsingRemoveCondition)" />
    </Target>
