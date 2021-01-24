       <script>
            var listofdownloadpages =  @Html.Raw(Json.Encode(@ViewBag.DownloadPages));
            if (listofdownloadpages != null) {
    
                console.log(listofdownloadpages.length);
    
                for (var i = 0; i < listofdownloadpages.length; i++) {
                    console.log(listofdownloadpages[i].Item1 + ' ' + listofdownloadpages[i].Item2);
                }
            }
            else {
                alert("not found anything");
    
            }
    </script>
