     @foreach (var item in Model.userAddress.GeoDataList)
                {
                    <dd>
                        @Html.DisplayName(item.PlaceName + ", " + item.PostalCode + ", " + item.Latitude + ", " + item.Longitude)
                    </dd>
                }
