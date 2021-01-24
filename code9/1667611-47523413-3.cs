    using System;
    using System.Windows;
    using AgentOctal.WpfLib;
    
    namespace ViewingAngle
    {
        class MainWindowVm : ViewModel
        {
            private const int Radius = 250;
            private const int CenterX = 250;
            private const int CenterY = 250;
    
    
            public MainWindowVm()
            {
                FieldOfView = 45;
                TargetAngle = 90;
            }
    
            private int _fieldOfView;
            public int FieldOfView
            {
                get { return _fieldOfView; }
                set
                {
                    SetValue(ref _fieldOfView, value);
                    RecalculateArc();
                }
            }
    
            private int _targetAngle;
            public int TargetAngle
            {
                get { return _targetAngle; }
                set
                {
                    SetValue(ref _targetAngle, value);
                    RecalculateArc();
                }
            }
    
            private double GetRadians(int angle)
            {
                return angle * Math.PI / 180;
            }
    
            private void RecalculateArc()
            {
                var targetAngle = GetRadians(_targetAngle);
                var fieldOfView = GetRadians(_fieldOfView);
                var halfFieldOfView = fieldOfView / 2;
    
                var startAngle = targetAngle - halfFieldOfView;
                var endAngle = targetAngle + halfFieldOfView;
                double angleDiff = endAngle - startAngle;
                IsLargeArc = angleDiff >= Math.PI;
    
                StartPoint = new Point(CenterX + Radius * Math.Cos(startAngle), CenterY + Radius * Math.Sin(startAngle));
                EndPoint = new Point(CenterX + Radius * Math.Cos(endAngle), CenterY + Radius * Math.Sin(endAngle));
            }
    
            private Point _startPoint;
            public Point StartPoint
            {
                get { return _startPoint; }
                set { SetValue(ref _startPoint, value); }
            }
    
            private Point _endPoint;
            public Point EndPoint
            {
                get { return _endPoint; }
                set { SetValue(ref _endPoint, value); }
            }
    
            private bool _isLargeArc;
            public bool IsLargeArc
            {
                get { return _isLargeArc; }
                set { SetValue(ref _isLargeArc, value); }
            }
        }
    }
