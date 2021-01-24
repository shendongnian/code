                textBox1.Text = "";
                var client = ImageAnnotatorClient.Create();
                try
                {
                    for (int i = 1; i < 6; i++)
                    {
                        int number = i;
                        textBox1.Text += "Image number : " + number + "\r\n";
                        var image = Google.Cloud.Vision.V1.Image.FromFile("C:\\temp\\sequence\\" + number + ".jpg");
                        var response = client.DetectLabels(image);
                        foreach (var annotation in response)
                        {
                            textBox1.Text += annotation.Description + "\r\n";
                        }
                        textBox1.Text += "Next image processing.... \r\n";
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
