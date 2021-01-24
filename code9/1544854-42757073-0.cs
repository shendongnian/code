            var btn = new System.Web.UI.WebControls.Button();
            btn.Text = "sample";
            btn.ID = "btnSubmitDelete";
            btn.OnClientClick += btnSubmitDelete_Click;
            _plchContent.Controls.Add(btn);
