                    <select name="@Html.NameFor(model => model.ClientId)"
                            id="@Html.NameFor(model => model.ClientId)"
                            class="form-control selectpicker">
                        <option value="">-- Select --</option>
                        @foreach (var client in Model.Clients)
                        {
                            @if (client.Id == Model.ClientId) //to select the item in edit mode
                            {
                                <option selected
                                        value="@client.Id"
                                        email="@client.Email">
                                    @client.Name
                                    </option>
                                }
                                else
                                {
                                    <option value="@client.Id"
                                            email="@client.Email">
                                        @client.Name
                                    </option>
                                }
                        }
                    </select>
