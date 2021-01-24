    [MetadataType(typeof(CalibrationHistory.MetaData))]
        public partial class CalibrationHistory
        {
            internal class MetaData {
                [Display(Name = "New Sensor Calibration value")]
                [DisplayFormat(DataFormatString ="{0:R}", ApplyFormatInEditMode = true)]
                public double Sensor_Calib;
                [Display(Name = "New Cylinder to Wall Distance value")]
                [DisplayFormat(DataFormatString = "{0:R}", ApplyFormatInEditMode = true)]
                public double Cylinder_to_Wall_Distance;
            }
     
            public override bool Equals(object obj)
            {
                CalibrationHistory castedObject = (CalibrationHistory)obj;
                if (this.ID == castedObject.ID && this.Cylinder_to_Wall_Distance == castedObject.Cylinder_to_Wall_Distance
                    && this.Sensor_Calib == castedObject.Sensor_Calib)
                {
                    return true;
                }
                else {
                    return false;
                }
            }
