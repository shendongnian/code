        case "EditRow":
            lblID.Text = id;
            txtName.Text = name;
            
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#myModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MyModal", 
            sb.ToString(), false);
            break;
