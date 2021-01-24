        public static void SaveCar(Car car, int i)
        {
            var serializer = new XmlSerializer(typeof(Car));
            using (var stream = new MemoryStream())
            {
                serializer.Serialize(stream, car);
                byte[] binaryCar = stream.ToArray();
                File.WriteAllBytes("car"+ i + ".xml", binaryCar);
            }
        }
