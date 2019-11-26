using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOMSample
{
    class Sample
    {
        private List<Record> Data { get; set; }
        private List<Part> Parts { get; set; }
        private List<Part> BOM { get; set; }
        public Sample()
        {
            CSV tmp = new CSV();
            Data = tmp.Data;

            this.Parts = new List<Part>();
            MakeSampleData();

            this.BOM = new List<Part>();
            this.foo();

            Console.WriteLine("{0}", MaxLevel());
        }

        private void foo()
        {
            Part last = new Part();
            for (int cnt = MaxLevel(); cnt > 0; cnt--)
            {
                Part current = new Part();
                List<Part> list = this.Parts;
                List<Part> delList = new List<Part>();
                List<Part> bar = new List<Part>();
                foreach (Part item in list)
                {
                    if (item.Level == cnt)
                    {
                        current.Parts.Add(item);
                        delList.Add(item);
                    }
                    else
                    {
                        current = item;
                        bar.Add(item);
                    }
                }

                this.Parts = bar;
            }
            this.BOM = this.Parts;
        }
        
        private void MakeSampleData()
        {
            foreach(var item in Data)
            {
                this.Parts.Add(new Part { Level = item.Level, Name = item.No });
            }
        }
        private int MaxLevel()
        {
            return this.Parts.Max(x => x.Level);
        }
    }
}
