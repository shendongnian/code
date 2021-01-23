          var savePicker = new FileSavePicker
                {
                    SuggestedStartLocation = PickerLocationId.PicturesLibrary,
                    SuggestedFileName = string.Format("MyProject{0}", DateTime.Now.ToString("ddMMyyyyHHmm"))
                };
                savePicker.FileTypeChoices.Add("Project", new List<string> {".collage"});
                var file = await savePicker.PickSaveFileAsync();
                if (file != null)
                {
                    var ser = JsonConvert.SerializeObject(this.ImageList.ToList());
                    await FileIO.WriteTextAsync(file, ser);
                }
