    List < State > states = JsonConvert.DeserializeObject < List < State >> (json);
    
    if(!states.Any())
        return;
    State state;
    foreach(State i in states) {
    if (i.StateID == Convert.ToInt32(extendedProperties["WFState"])) {
        state = i;
        } 
    else {}
    }
    
    try {
        btnApprove.Visible = state.Actions.Approved.NextStateID != null ? true : false;
        btnApprove.Text = state.Actions.Approved.Title.ToString();
    }
    catch (Exception ex) {
        btnApprove.Visible = false;
    }
