        class Person
        {
            public string First_Name { get; set; }
            public string Last_Name { get; set; }
            public string Address { get; set; }
            public int Salary { get; set; }
            public Person(string first_name, string last_name, string address, int salary)
            {
                this.First_Name = first_name;
                this.Last_Name = last_name;
                this.Address = address;
                this.Salary = salary;
            }
            public Person() { }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            var defaultIndex = "persons";
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
                .InferMappingFor<Person>(i => i.IndexName(defaultIndex))
                .DefaultIndex(defaultIndex);
            client = new ElasticClient(settings);
            if (client.IndexExists(defaultIndex).Exists)
                client.DeleteIndex(defaultIndex);
            client.CreateIndex(defaultIndex, c => c
                .Settings(s => s
                    .NumberOfShards(1)
                )
                .Mappings(m => m
                    .Map<Person>(mm => mm
                        .AutoMap()
                    )
                )
            );
            Person al = new Person("Al", "Bundy", "House A", 1000);
            Person bud = new Person("Bud", "Bundy", "House A", 500);
            Person peggy = new Person("Peggy", "Bundy", "House A", 0);
            Person kelly = new Person("Kelly", "Bundy", "House A", 100);
            Person marcy = new Person("Marcy", "Darcy", "House B", 4000);
            Person jefferson = new Person("Jefferson", "Darcy", "House B", 0);
            client.IndexMany(new[] { al, peggy, kelly, bud, marcy, jefferson });
            client.Refresh(defaultIndex);
            // query the index
            var result = client.Search<Person>(s => s
                .Aggregations(a => a
                    .Terms("Families", ts => ts
                        .Field(o => o.Last_Name.Suffix("keyword")) // use the keyword sub-field for terms aggregation                        
                        .Size(100)
                        .Aggregations(abc => abc
                            .TopHits("ExtraFields", th => th
                            .Size(1)
                            )
                        )
                    )
                )
                .Size(0)
            );
            var names = result.Aggs.Terms("Families");
            string retval = string.Empty;
            foreach (var name in names.Buckets)
            {
                var extraFields = name.TopHits("ExtraFields");
                var hits = extraFields.Hits<Person>();
                foreach (var hit in hits)
                {
                    Person p = hit.Source;
                    var address = p.Address;
                    retval += "* family: '" + name.Key + "' living in: " + address + " Number of persons: " + extraFields.Total + Environment.NewLine;
                }
            }
            MessageBox.Show(retval);
        }
