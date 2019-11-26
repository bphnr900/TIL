using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BOMSample
{
    class CSV
    {
        public List<Record> Data { get; set; }
        public CSV()
        {
            Data = new List<Record>();
            GetData();
        }

        private void GetData()
        {
            try
            {
                using(var sr = new StreamReader("Sample.csv"))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var values = line.Split(',');
                        Data.Add(new Record { Level = int.Parse(values[1].ToString()), No = values[0].ToString() });
                    }
                }
            }
            catch(System.Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}
