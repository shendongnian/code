    <!DOCTYPE html>
    <html>
    <body>
     
    <p id="demo"> </p>
    <button onclick="myFunction()">Try it</button>
    <script>
    function myFunction() {
        var str = "[{\"Intent\":\"what is manufacturer name?\",\"Entity\":\"Name\",\"Response\":\"Test\",\"Status\":\"0\",\"Created_Date\":\"2017-04-04T00:00:00\",\"Response_Count\":0,\"Response_Count_string\":0},{\"Intent\":\"hi\",\"Entity\":\"hi\",\"Response\":\"hiiii\",\"Status\":\"0\",\"Created_Date\":\"2017-03-28T10:22:00\",\"Response_Count\":0,\"Response_Count_string\":0},{\"Intent\":\"how are you?\",\"Entity\":\"are you fine\",\"Response\":\"good!cool\",\"Status\":\"1\",\"Created_Date\":\"2017-03-28T10:22:38\",\"Response_Count\":0,\"Response_Count_string\":0}]"; 
        var res = str.replace("\'", "");
        res=  JSON.parse(res)
        document.getElementById("demo").innerHTML = res[0].Intent;
    }
    </script>
    </body>
    </html>
