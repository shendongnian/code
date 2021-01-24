    protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ValidateActionSelected();enter code here
            ValidateCleared(actionsChecked);
            if (!ValidateCleared(actionsChecked))
            {
                if (String.Equals(ddlActionsAndDocuments.SelectedItem.Text.ToString(), "XXX YYY") || String.Equals(ddlActionsAndDocuments.SelectedItem.Text.ToString(), "XXX ZZZ"))
                {
                    reqEffectiveDate.ErrorMessage = "";
                }
                if (ddlActionsAndDocuments.SelectedValue == ActionTypes.XXXYYY ||
                    ddlActionsAndDocuments.SelectedValue == ActionTypes.XXXYYYDenial ||
                    ddlActionsAndDocuments.SelectedValue == ActionTypes.XXXzzz)
                {
                    ValidateXXXYYY(actionsChecked, ddlActionsAndDocuments.Text);
                }
                if (ddlActionsAndDocuments.SelectedValue == InsuranceActionTypes.WWW ||
                    ddlActionsAndDocuments.SelectedValue == InsuranceActionTypes.YYYZZZ ||
                    ddlActionsAndDocuments.SelectedValue == InsuranceActionTypes.YYYWWW ||
                    ddlActionsAndDocuments.SelectedValue == InsuranceActionTypes.YYYWaived)
                {
                    ValidateCertificate(actionsChecked, ddlActionsAndDocuments.Text);
                }
            }
        }
        private bool ValidateCleared(List<xxCaseEntity> actionsChecked)
        {
            List<xxCaseEntity> removeItems = new List<xxCaseEntity>();
            foreach (xxCaseEntity ACTIONyy in actionsChecked)
            {
                if (ACTIONyy.XXStatusCode == 40 || ACTIONyy.XXStatusCode == 45)
                {
                    DisplayErrorMessage("FR Action Cannot Apply to " + ACTIONyy.CaseIdentifier);
                    //actionsChecked.Remove(ACTIONyy);
                    removeItems.Add(ACTIONyy);
                }
            }
            foreach(xxCaseEntity ACTIONyy in removeItems)
            {
                actionsChecked.Remove(ACTIONyy);
            }
            return;
        }
