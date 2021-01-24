            try
            {
                string scripts;
                List<string> outlist = new List<string>();
                generateScripts gs = new generateScripts();
                StringValidation sv = new StringValidation();
              
                if (sv.validate(joindateStringlist, out outlist) == "")
                {
                    scripts = gs.GenerateScripts(outlist, employeetype.GenerateScripts_NewJoin);
                    return await Task.Factory.StartNew(() => api.GetEmployeeDetails(scripts)) ;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
               
                WriteToLog(ex.Message);
                return null;
            }
        }
