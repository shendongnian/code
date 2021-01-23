    using HelixToolkit.Wpf;
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Media3D;
    
    namespace _3D_Geometry_Test
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            const int NUM_SPLINES = 11;
            const int NUM_SPARS = 10;
            static Vector3D xAxis = new Vector3D(1, 0, 0);
    
            /// <summary>
            /// Creates the window.
            /// </summary>
            public MainWindow()
            {
                InitializeComponent();
                MakeBlades3();
            }
            
            /// <summary>
            /// Makes the blades.
            /// </summary>
            public void MakeBlades3()
            {
                var splines = GetSplines();
                var spars = GetSpars();
    
                MeshBuilder builder = new MeshBuilder(true, true);
    
                for (int i = 0; i < splines.Length; i++)
                {
                    var currSpline = splines[i];
                    if (i < splines.Length - 1)
                    {
                        var nextSpline = splines[i + 1];
                        for (int j = 0; j < currSpline.Count; j++)
                        {
                            Point3D currPoint = currSpline[j];
                            Point3D pt1, pt2;
                            Find2NN(currPoint, nextSpline, out pt1, out pt2);
                            builder.AddTriangle(currPoint, pt1, pt2);
    
                            if (j > 0)
                            {
                                Point3D prevPoint = currSpline[j - 1];
                                Point3D pt3 = FindNN(currPoint, prevPoint, nextSpline);
                                builder.AddTriangle(currPoint, prevPoint, pt3);
                            }
    
                            if (j < currSpline.Count - 1)
                            {
                                Point3D nextPoint = currSpline[j + 1];
                                Point3D pt3 = FindNN(currPoint, nextPoint, nextSpline);
                                builder.AddTriangle(currPoint, nextPoint, pt3);
                            }
                        }
                    }
                    if (i > 0)
                    {
                        var prevSpline = splines[i - 1];
                        for (int j = 0; j < currSpline.Count; j++)
                        {
                            Point3D currPoint = currSpline[j];
                            Point3D pt1, pt2;
                            Find2NN(currPoint, prevSpline, out pt1, out pt2);
                            builder.AddTriangle(currPoint, pt1, pt2);
    
                            if (j > 0)
                            {
                                Point3D prevPoint = currSpline[j - 1];
                                Point3D pt3 = FindNN(currPoint, prevPoint, prevSpline);
                                builder.AddTriangle(currPoint, prevPoint, pt3);
                            }
                            if (j < currSpline.Count - 1)
                            {
                                Point3D nextPoint = currSpline[j + 1];
                                Point3D pt3 = FindNN(currPoint, nextPoint, prevSpline);
                                builder.AddTriangle(currPoint, nextPoint, pt3);
                            }
                        }
                    }
                }
                bladePlot.MeshGeometry = builder.ToMesh();
            }
            /// <summary>
            /// Finds the point in the input list of points that is closest to the two input points (Euclidean distance).
            /// </summary>
            /// <param name="origPoint1">The first point.</param>
            /// <param name="origPoint2">The second point.</param>
            /// <param name="listOfPoints">The list of points to find the nearest one in <note type="note">For the sake of speed, this should be a DISTINCT list (no duplicates).</note>.</param>
            /// <returns>The point in <paramref name="listOfPoints"/> that is closest to <paramref name="origPoint1"/> and <paramref name="origPoint2"/> (Euclidean distance).</returns>
            private Point3D FindNN(Point3D origPoint1, Point3D origPoint2, List<Point3D> listOfPoints)
            {
                Point3D result = listOfPoints[0];
                var dist = EuclidDist(origPoint1, result) + EuclidDist(origPoint2, result);
                for (int i = 1; i < listOfPoints.Count;i++)
                {
                    var dist2 = EuclidDist(origPoint1, listOfPoints[i]) + EuclidDist(origPoint2, listOfPoints[i]);
                    if (dist2 < dist)
                    {
                        dist = dist2;
                        result = listOfPoints[i];
                    }
                }
                return result;
            }
    
            /// <summary>
            /// Find the 2 nearest neighbors of the specified point (based on Euclidean distance).
            /// </summary>
            /// <param name="origPoint">The original point.</param>
            /// <param name="listOfPoints">A list of points to find the two nearest-neighbors from. <note type="note">For the sake of speed, this should be a DISTINCT list (no duplicates).</note></param>
            /// <param name="pt1">First nearest neighboring point (output).</param>
            /// <param name="pt2">Second nearest neighboring point (output).</param>
            private void Find2NN(Point3D origPoint, List<Point3D> listOfPoints, out Point3D pt1, out Point3D pt2)
            {
                pt1 = new Point3D();
                pt2 = new Point3D();
    
                List<Point3D> temp = new List<Point3D>(listOfPoints);
    
                pt1 = temp[0];
                var dist = EuclidDist(origPoint, pt1);
                for (int i = 1; i < temp.Count; i++)
                {
                    var dist2 = EuclidDist(origPoint, temp[i]);
                    if (dist2 < dist)
                    {
                        dist = dist2;
                        pt1 = temp[i];
                    }
                }
                temp.Remove(pt1);
    
                pt2 = temp[0];
                dist = EuclidDist(origPoint, pt2);
                for (int i = 1; i < temp.Count; i++)
                {
                    var dist2 = EuclidDist(origPoint, temp[i]);
                    if (dist2 < dist)
                    {
                        dist = dist2;
                        pt2 = temp[i];
                    }
                }
            }
    
            /// <summary>
            /// Calculates the Euclidean distance between the two input points.
            /// </summary>
            /// <param name="pt1">The first point.</param>
            /// <param name="pt2">The second point.</param>
            /// <returns>The Euclidean distance between <paramref name="pt1"/> and <paramref name="pt2"/>.</returns>
            private double EuclidDist(Point3D pt1, Point3D pt2)
            {
                double deltaX = pt1.X - pt2.X;
                double deltaY = pt1.Y - pt2.Y;
                double deltaZ = pt1.Z - pt2.Z;
                return Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
            }
        }
    }
