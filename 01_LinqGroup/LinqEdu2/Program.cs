using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqEdu2
{
    class Program
    {
        static void Main(string[] args)
        {
            //サンプルデータ用意
            var data = new List<Person>(
                Enumerable.Range(1, 100).Select(i => new Person
                {
                    ID = i,
                    Name = "田中 太郎" + i,
                    Class = i % 3,
                }));

            //グルーピング
            var grouped = data.GroupBy(x => x.Class);
            List<Person> people = new List<Person>();
            List<Person> sumData = new List<Person>();

            //要素取り出し
            foreach(var group in grouped)
            {
                var maxData = group.Where(x => x.ID == group.Max(y => y.ID));
                var sum = group.Sum(x => x.ID);
                var firstData = group.First();
                sumData.Add(new Person { ID = sum, Name = firstData.Name, Class = firstData.Class });

                foreach(var item in maxData)
                {
                    people.Add(new Person { ID = item.ID, Name = item.Name, Class = item.Class });
                }
            }

            //結果確認
            foreach(var i in people)
            {
                Console.WriteLine("{0},{1},{2}", i.ID, i.Name, i.Class);
            }
        }
    }
}
