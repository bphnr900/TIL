class Person
{
  public int ID { get; set; }
  public string Name { get; set; }
  public string Group { get; set; }
  public DateTime Birth { get; set; }
}

class Class1
{
    private List<Person> people { get; set; }

    public Class1()
    {
        MakeData();
        people = people.OrderBy(x => x.Name).ToList();
        foreach(Person i in people)
        {
            Console.WriteLine(i.Name);
        }
        people = people.OrderBy(x => x.ID).ToList();
        foreach(Person i in people)
        {
            Console.WriteLine("{0},{1}", i.ID, i.Name);
        }
        people = people.OrderBy(x => x.Birth).ToList();
        foreach(Person i in people)
        {
            Console.WriteLine("{0},{1},{2}", i.ID, i.Name, i.Birth);
        }
        people = people.OrderBy(x => x.Group).ThenBy(x => x.Birth).ToList();
        foreach(Person i in people)
        {
            Console.WriteLine("{0},{1},{2}", i.Name, i.Group, i.Birth);
        }
    }

    private void MakeData()
    {
        System.Random r = new Random(1000);
        people = new List<Person>
        {
            new Person
            {
                ID = r.Next(10),
                Name = "星宮 いちご",
                Group = "ソレイユ",
                Birth = DateTime.Parse("2000/03/15"),
            },
            new Person
            {
                ID = r.Next(10),
                Name = "霧矢 あおい",
                Group = "ソレイユ",
                Birth = DateTime.Parse("2000/01/31"),
            },
            new Person
            {
                ID = r.Next(10),
                Name = "紫吹 蘭",
                Group = "ソレイユ",
                Birth = DateTime.Parse("1999/08/03"),
            },
            new Person
            {
                ID = r.Next(10),
                Name = "神崎 美月",
                Group = "トライスター",
                Birth = DateTime.Parse("1998/09/18"),
            },
            new Person
            {
                ID = r.Next(10),
                Name = "藤堂 ユリカ",
                Group = "トライスター",
                Birth = DateTime.Parse("1999/12/26"),
            },
            new Person
            {
                ID = r.Next(10),
                Name = "一ノ瀬 かえで",
                Group = "トライスター",
                Birth = DateTime.Parse("1998/11/23"),
            }

        };
    }
}
