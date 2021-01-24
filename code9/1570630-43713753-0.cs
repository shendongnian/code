    <Target Name="CoreCompileSolution">
     
      <PropertyGroup>
        <CodeAnalysisOption Condition=" '$(RunCodeAnalysis)'=='Always'">RunCodeAnalysis=true</CodeAnalysisOption>
        <CodeAnalysisOption Condition=" '$(RunCodeAnalysis)'=='Never'">RunCodeAnalysis=false</CodeAnalysisOption>
        <!-- ... -->
      </PropertyGroup>
      <!-- ... -->
    </Target>
