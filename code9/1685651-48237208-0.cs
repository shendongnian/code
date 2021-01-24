                <div class="row product cpu">
                    <div class="col-md-3">
                        <img class="center-block" src="Content/images/processor.jpg" />
                        <span class="price"><%= cpu.Price %></span>
                        <span class="addtocart" id="buttonContainer" runat="server">
                            <% Button b = new Button();
                                b.ID = "Button" + cpu.ID;
                                b.CommandArgument = cpu.ID.ToString();
                                b.Text = "Add to Cart";
                                b.OnClientClick = "Addtocart_Click";
                                buttonContainer.Controls.Add(b);
                            %>
                        </span>
                        <br />
                    </div>
                </div>
