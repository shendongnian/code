                // Request headers
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key","please use your key");
                // Request parameters
                queryString["returnFaceId"] = "true";
                queryString["returnFaceLandmarks"] = "false";
                queryString["returnFaceAttributes"] = "age";
                var uri = "https://westus.api.cognitive.microsoft.com/face/v1.0/detect?" + queryString;
                HttpResponseMessage response;
                // Request body
                byte[] byteData = Encoding.UTF8.GetBytes("{ \"url\":\"https://lh5.googleusercontent.com/-AI__M0nZDU4/AAAAAAAAAAI/AAAAAAAAAGs/P5tdI3rFaFs/s0-c-k-no-ns/photo.jpg \"}");
                using (var content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PostAsync(uri, content);
                    Console.Write(response.StatusCode);
                }
