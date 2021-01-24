    foreach (DataListItem datalistItem in QuestionList.Items)
            {
                if (datalistItem.ItemType == ListItemType.Item || datalistItem.ItemType == ListItemType.AlternatingItem)
                {
                    var radioButtonList = datalistItem.FindControl("AnswerList") as RadioButtonList;
                    if (radioButtonList != null)
                    {
                        var selectedRadioButtonValue = radioButtonList.SelectedValue;
                        var itemDataKeyValue = QuestionList.DataKeys[datalistItem.ItemIndex];
                        Response.Write(string.Format("QuestionID :{0}, selected option: {1} <br/>", itemDataKeyValue, selectedRadioButtonValue));
                    }
                }
            }
