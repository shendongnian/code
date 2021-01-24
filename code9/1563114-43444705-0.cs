     private void GetProjectProperties(object sender, EventArgs e)
            {
                DTE2 dte = (DTE2)Package.GetGlobalService(typeof(SDTE));
                VCProject prj = dte.Solution.Projects.Item(1).Object as VCProject;
                foreach (VCConfiguration vccon in prj.Configurations)
                {
                    IVCRulePropertyStorage generalRule = vccon.Rules.Item("ConfigurationGeneral");
    
                    string outputPath = vccon.OutputDirectory;
    
                    vccon.OutputDirectory = "$(test)";
                    //string test1 = generalRule.GetEvaluatedPropertyValue(2);
                    string tar = generalRule.GetEvaluatedPropertyValue("TargetExt");
                    string name = generalRule.GetEvaluatedPropertyValue("TargetName");
                }
    }
