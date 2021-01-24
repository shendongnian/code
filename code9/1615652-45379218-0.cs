    if (!IsPostBack)
            {
                GetQuestions();
                GetAnswers();
                questionIDBreadCrumb.Text = grabID();
                //loads the current userID
                getUserData();
                //validates questionOwner
            }
