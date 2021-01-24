    <Configuration>
       <System.web>
          <Compilation>
             <BuildProviders>
               <Remove extension = ".lic" />
               <Add extension = ".lic"
                   Type = "System.Web.Compilation.ForceCopyBuildProvider" />
             </ BuildProviders>
          </ Compilation>
       </system.web>
    </ Configuration>
