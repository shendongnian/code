        private async void btnVerificar_Clicked(object sender, EventArgs e)
        {
            var imageContent = new ByteArrayContent(ultimaImagen);
            imageContent.Headers.Add("X-Auth-Token", "eb27c17f-8bd6-4b94-bc4f-742e361b4e6a");
            imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
            try
            {
                HttpResponseMessage response = await _client.PostAsync("https://10.54.66.160:9000/3/matching/search?list_id=3c9f2623-28be-435f-a49f-4dc29c186809&limit=1", imageContent);
                string responseContent = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await DisplayAlert("MobileAccessControl", responseContent, "OK");
                }
                else
                {
                    await DisplayAlert("MobileAccessControl", "Read not OK.", "OK");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
