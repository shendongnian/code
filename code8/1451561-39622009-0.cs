    await Task.Run(() =>
            {
                byte[] byteResponse = client.UploadFile(destination, FileName);
                string response = System.Text.Encoding.UTF8.GetString(byteResponse);
                //Parse the response as a JSON object
                result = JsonConvert.DeserializeObject<GbrAppVideo>(response);
                Console.WriteLine(string.Format("Upload completed: {0}", result));
                //Delete the local file since we don't need it anymore
                if (result.VideoId > 0)
                {
                    File.Delete(FileName);
                }
                //Let the system know the video is done
                GlobalResources.activeVideo = result;
            }
