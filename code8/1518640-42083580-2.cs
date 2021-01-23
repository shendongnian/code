    Mat original_image = new Mat();
    Mat gray = new Mat();
    Mat threshold_image = new Mat();
    VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
    Mat new_image = new Mat();
    Mat con = new Mat();
    
    //TrackBar Scroll
        private void trackBarLow_Scroll(object sender, EventArgs e)
        {
            try
            {
                low = trackBarLow.Value;
                threshold_value = trackBarThreshold.Value;
                CvInvoke.CvtColor(original_image, gray, ColorConversion.Bgr2Gray, 0);
                CvInvoke.Threshold(gray, threshold_image, low, threshold_value, ThresholdType.Binary);
                Image<Bgr, Byte> threshold_I = threshold_image.ToImage<Bgr, Byte>();
                pictureBox2.Image = threshold_I.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
         }
         private void buttonExactContours_Click(object sender, EventArgs e)
         {
            try
            {
                new_image = new Mat(new System.Drawing.Size(640, 480), DepthType.Cv16S, 3);
                new_image.SetTo(new Emgu.CV.Structure.MCvScalar(150, 0, 150));
                con = threshold_image;
                Image<Bgr, Byte> new_image1_I = new_image.ToImage<Bgr, Byte>();
                pictureBox3.Image = new_image1_I.ToBitmap();
                CvInvoke.FindContours(con, contours, null, RetrType.Ccomp, ChainApproxMethod.ChainApproxSimple, new Point(0, 0));
                            
                IInputArrayOfArrays arr;
                
                for (int j = 0; j < contours.Size; j++)
                {
                    arr = contours[j];
                    
                    //textBox1.AppendText(Environment.NewLine + CvInvoke.ArcLength(arr, true).ToString() + Environment.NewLine);
                    textBox1.AppendText(Environment.NewLine + contours[j].Size.ToString() + Environment.NewLine);
                    if (contours[j].Size < 500) //Value "500" may vary according to the size you may want to filter
                        continue;
                }
                Image<Bgr, Byte> new_image_I = new_image.ToImage<Bgr, Byte>();
                pictureBox2.Image = new_image_I.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
