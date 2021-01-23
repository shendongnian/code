                var clients = (from a in dc.Clients
                                    select new
                                    {
                                        a
                                    }).ToList();
                if (clients != null && clients.Any())
                {
                    myGridview.DataSource = clients;
                    myGridview.DataBind();
                    myGridview.Rows[0].Visible = false;
                }
                else
                {
                    myGridview.DataSource = clients;
                    myGridview.DataBind();
                }
