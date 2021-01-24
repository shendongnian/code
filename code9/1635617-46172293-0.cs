      private void buttonCaricaImmagine_Click(object sender, EventArgs e)
                {
                    OpenFileDialog of = new OpenFileDialog();
                    //For any other formats
        
                    of.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
                    if (of.ShowDialog() == DialogResult.OK)
                    {
        
                        pictureBoxRapportino.ImageLocation = of.FileName;
                        imm = pictureBoxRapportino.Image;
                        checkImage = 1;
                    }
                }
                //this will convert your picture and save in database
                void conv_photo()
                {
                    MemoryStream ms;
                    if (pictureBoxRapportino.Image != null)
                    {
                        ms = new MemoryStream();
                        pictureBoxRapportino.Image.Save(ms, ImageFormat.Jpeg);
                        byte[] photo_aray = new byte[ms.Length];
                        ms.Position = 0;
                        ms.Read(photo_aray, 0, photo_aray.Length);
                        command.Parameters.Add("@Immagine", SqlDbType.Binary).Value = photo_aray;
                    }
                }
        
         
        
                private void buttonInserimento_Click(object sender, EventArgs e)
                {
                    try
                    {
                        if (checkImage == 1 && textBoxNumeroDocumento.Text != "")
                        {
                            //controlla dati
                            int NumeroDocumento = int.Parse(textBoxNumeroDocumento.Text);
        
                            //inserisco i dati nel database
                            SqlConnection conn = db.apriconnessione();
        
                            String query = "Insert into Rapporto(IdCantiere,IdUtenteCreazione,NumeroDocumento,Data,Immagine) values(@IdCantiere,@IdUtenteCreazione,@NumeroDocumento,@Data,@Immagine) ";
        
                            using (SqlCommand command = new SqlCommand(query, conn))
                            {
                                command.Parameters.Add("@IdCantiere", SqlDbType.Int).Value = IdCantiere;
                                command.Parameters.Add("@IdUtenteCreazione", SqlDbType.Int).Value = u.IdUtente;
                                command.Parameters.Add("@NumeroDocumento", SqlDbType.Int).Value = int.Parse(textBoxNumeroDocumento.Text);
                                command.Parameters.Add("@Data", SqlDbType.DateTime).Value = dateTimePickerData.Value;
                                conv_photo();
                                command.ExecuteNonQuery();
        
                            }
        
                            db.chiudiconnessione();
                            conn.Close();
        
                        }
        
                        else
                        {
                            MessageBox.Show("Devi compilare tutti i campi");
                        }
        
                    }
        
                    catch (Exception ex)
                    {
                        MessageBox.Show("Errore: controlla i formati " + ex);
                    }
        
                }
