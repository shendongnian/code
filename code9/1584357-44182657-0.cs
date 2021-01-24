    public void Button1_Click(object sender, EventArgs e)  	{
        int check = 0;
		foreach (Row row in this.TabelaPrincipal.Rows) {
			foreach (Cell cell in row.Cells) {
				foreach (Control item in cell.Controls) {
			            if((item is CheckBox) && ((CheckBox) item).Checked)
			            {
			                TabelaPrincipal.Visible = false;
		        	        Button1.Visible = false;
		                	DropArtista.Visible = false;
			                DropEscola.Visible = false;
			                DropConcelho.Visible = false;
			
                			check += 1;
		                	//Response.Write(check);
			            }
			            else
			            {
			
		        	    }
			        }
		   	}
		}
        Response.Write(check);
	}
	
