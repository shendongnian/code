     protected override void Process(DPFP.Sample Sample)
        {
            base.Process(Sample);
            var app = new Aplicacao_Biometria();
            int id = 1;
            var result = app.Listar_Planos_id(id);
            // Process the sample and create a feature set for the enrollment purpose.
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);
            // Check quality of the sample and add to enroller if it's good
            if (features != null) try
                {
                    MakeReport("The fingerprint feature set was created.");
                    Enroller.AddFeatures(features);     // Add feature set to template.
                }
                finally
                {
                    UpdateStatus();
                    // Check if template has been created.
                    switch (Enroller.TemplateStatus)
                    {
                        case DPFP.Processing.Enrollment.Status.Ready:   // report success and stop capturing
                            OnTemplate(Enroller.Template);
                            //byte[] byted;
                            //byted = Enroller.Template.Bytes;
                            MemoryStream fingerprintData = new MemoryStream();
                            Enroller.Template.Serialize(fingerprintData);
                            fingerprintData.Position = 0;
                            BinaryReader br = new BinaryReader(fingerprintData);
                            Byte[] bytes = br.ReadBytes((Int32)Enroller.Template.Bytes.Length);
                            //Insert the file into database
                            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
                          AttachDbFilename=c:\Users\Gabriel\Documents\Visual Studio 2015\Projects\Projeto_Fisioativa_Desktop\Projeto_Fisioativa_Desktop2\Bd_Fisio_Desktop.mdf;
                          Integrated Security=True;
                          Connect Timeout=30;");
                            SqlCommand cmd;
                            if (result.Count != 0)
                            {
                                cmd = new SqlCommand("UPDATE Biometrias set biometria = @biometria, id_usuario = @id_usuario ", cn);
                                cmd.Parameters.Add("biometria", SqlDbType.Binary).Value = bytes;
                                cmd.Parameters.Add("id_usuario", SqlDbType.Int).Value = id;
                            }
                            else
                            {
                                cmd = new SqlCommand("INSERT INTO Biometrias VALUES(@biometria, @id_usuario)", cn);
                                cmd.Parameters.Add("biometria", SqlDbType.Binary).Value = bytes;
                                cmd.Parameters.Add("id_usuario", SqlDbType.Int).Value = 1;
                            }
                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            SetPrompt("Click Close, and then click Fingerprint Verification.");
                            Stop();
                            break;
                        case DPFP.Processing.Enrollment.Status.Failed:  // report failure and restart capturing
                            Enroller.Clear();
                            Stop();
                            UpdateStatus();
                            OnTemplate(null);
                            Start();
                            break;
                    }
                }
        }
 
