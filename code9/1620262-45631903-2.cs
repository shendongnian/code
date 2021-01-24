    using FileHelpers;
    using FileHelpers.Events;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace VOISTATread
    {
    //class Layout
    //{
    //}
    [DelimitedRecord("\t")]
    [IgnoreEmptyLines]
    public class PatientVOIstat : INotifyRead
    {
        // public int CustId;
        //public string Name;
        //public decimal Balance;
        // [FieldConverter(ConverterKind.Date, "dd-MM-yyyy")]
        // public DateTime AddedDate;
        public string Component;
        public string File;
        public string PatientName;
        public string PatientID;
        public string PatientInfo;
        public string StudyDescription;
        public string SeriesDescription;
        public string StudyDate;
        public string Color;
        public string VoiName;
        public double Time;
        public double Averaged;
        public double Sd;
        public double Volume;
        public double TotalSUM;
        public double TotalAVRVOL;
        public double MinimumVal;
        public double MaximumVal;
        public int NumberOfPixels;
        public int NumberOfEffectivePixels;
        public double HotAveraged;
        public double Stdv;
        public double Q1;
        public double Median;
        public double Q3;
        public double AreaUnderCurve;
        public double HypoxiaIndex;
        public double HypoxicVolume;
        public double NumberOfNaNs;
        public double VolumeWithoutNaNs;
        public double SurfaceArea;
        public double Sphericity;
        public double DiameterMax;
        public double FractalDimension;
        public double FD_LConfidenceInterval;
        public double FD_HConfidenceInterval;
        public void BeforeRead(BeforeReadEventArgs e)
        {
            if (e.RecordLine.StartsWith("#") ||
               e.RecordLine.StartsWith("/"))
                e.SkipThisRecord = true;
        }
        public void AfterRead(AfterReadEventArgs e)
        {
            // seems weird, but you have to handle this, even if nothing is done.
            //  we want to drop all records with no freight
            //if (Freight == 0)
            //    e.SkipThisRecord = true;
        }
    }
    }
