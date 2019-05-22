using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupByEdu
{
    class Sample
    {
        private List<Student> Students { get; set; }
        private int[] Grades { get; set; }
        private int[] Classes { get; set; }
        private string[] Sex { get; set; }
        public Sample()
        {
            var data = Enumerable.Range(0, 100).Select(x => new Student
            {
                Name = "田中 太郎" + x,
                Sex = x % 2 == 0 ? "M" : "F",
                Grade = x % 3,
                Class = x % 4
            }).ToList();

            foreach(var x in data)
            {
                Console.WriteLine("Name : {0},Sex : {1},Grade : {2},Class : {3}", x.Name, x.Sex, x.Grade, x.Class);
            }

            this.Students = new List<Student>();
            this.Students = data;

            this.Grades = new int[] { 0, 1, 2 };
            this.Classes = new int[] { 0, 1, 2, 3 };
            this.Sex = new string[] { "M", "F" };

            Run();
        }

        private void Run()
        {
            List<Grade> huga = new List<Grade>();
            foreach(var grade in Grades)
            {
                List<GroupByEdu.Class> hoge = new List<Class>();
                foreach(var i in Classes)
                {
                    List<GroupByEdu.Sex> tmp = new List<Sex>();
                    foreach (var j in Sex)
                    {
                        List<Person> sex = new List<Person>();
                        foreach (var student in Students)
                        {
                            if (student.Grade == grade && student.Class == i && student.Sex == j)
                            {
                                sex.Add(new Person { Name = student.Name });
                            }
                        }
                        tmp.Add(new Sex { SexType = j, people = sex });
                    }
                    hoge.Add(new Class { Sexes = tmp, ClassNum = i });
                }
                huga.Add(new Grade { GradeNum = grade, Classes = hoge });
            }
        }
    }
}
