       <script>
            var listofdownloadpages =  @Html.Raw(Json.Encode(@ViewBag.DownloadPages));
            if (listofdownloadpages != null) {
    
                alert(listofdownloadpages.length);
    
                for (var i = 0; i < listofdownloadpages.length; i++) {
                    alert(listofdownloadpages[i].Item1 + ' ' + listofdownloadpages[i].Item2);
                }
            }
            else {
                alert("not found anything");
    
            }
    </script>
