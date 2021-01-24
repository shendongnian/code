    <Antlr4>
      <Generator>MSBuild:Compile</Generator>
      <CustomToolNamespace Condition="'$(Antlr4IsSdkProject)' != 'True'">$(RootNamespace)</CustomToolNamespace>
      <CopyToOutputDirectory>Never</CopyToOutputDirectory>
      <Encoding>UTF-8</Encoding>
      <TargetLanguage>CSharp</TargetLanguage>
      <Listener>true</Listener>
      <Visitor>true</Visitor>
      <Abstract>false</Abstract>
      <ForceAtn>false</ForceAtn>
    </Antlr4>
