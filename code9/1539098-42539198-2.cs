    @foreach (var item in Model.userAddress.GeoDataList)
            {
                <dd>
                    @Html.Raw(item.PlaceName + ", " + item.PostalCode + ", " + item.Latitude + ", " + item.Longitude)
                </dd>
            }
