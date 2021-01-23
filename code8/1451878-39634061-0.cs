    while (oReader.Read());
                {
                    int i = 0;
                    System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
                    new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    createDiv.ID = "createDiv";
                    this.Controls.Add(createDiv);
                    List<TextBox> tb_names = new List<TextBox>();
                    TextBox tb_name = new TextBox();
  
                     var lstText=new List<string>
                        {
                        "Scheepspnaam",
                        "RederijNr",
                        "Lengte",
                        "Laadvermogen"
                    };
                    for (int j = 0; j < 4; j++)
                    {
                        tb_name.ID = "CreateT_" + i + "_" + (j+1);
                        //tb_name.Text = oReader["SchipNaam"].ToString();
                        createDiv.Controls.Add(new LiteralControl
                            ("<div class='form-group'><div class='clearfix' ></div><div class='row'><div class='col-md-3'></div><div class='col-md-3'> " + lstText[j] +
                             ": <input type='text' id='" + tb_name.ID + "' runat='server'/></div></div></div>"));
                        tb_names.Add(tb_name);
                    } 
                   
                    i++;
                }
