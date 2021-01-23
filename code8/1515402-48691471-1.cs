    protected override void Process(DPFP.Sample Sample)
        {
            SqlConnection conn = new SqlConnection("Your connection string");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Biometrias", conn);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                byte[] _img = (byte[])dr["biometria"];
                MemoryStream ms = new MemoryStream(_img);
                DPFP.Template Template = new DPFP.Template();
                Template.DeSerialize(ms);
                DPFP.Verification.Verification Verificator = new DPFP.Verification.Verification();
                base.Process(Sample);
                DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);
                if (features != null)
                {
                    DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                    Verificator.Verify(features, Template, ref result);
                    UpdateStatus(result.FARAchieved);
                    if (result.Verified)
                        MakeReport("The fingerprint was VERIFIED.");
                    else
                        MakeReport("The fingerprint was NOT VERIFIED.");
                }
            }
        }
