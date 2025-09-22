namespace Day1_Task
{
    class Subject
    {
        public int Code { get; set; }
        public string Name { get; set; }
    }
    class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Subject[] subjects { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };
            var q1 = numbers.Distinct().OrderBy(n => n);
            foreach (var item in q1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------");
            var q2 = q1.Select(n => new { Number = n, Multiplay = n * n });
            foreach (var item in q2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------");
            string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" };
            var q3 = names.Where(n => n.Length == 3);
            foreach (var item in q3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------");
            var q4 = names.Where(n => n.Contains('a') || n.Contains('A')).OrderBy(n => n.Length);
            foreach (var item in q4)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------");
            var q5 = names.Take(2);
            foreach (var item in q5)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------");
            List<Student> students = new List<Student>()
            {
                 new Student(){ ID=1, FirstName="Ali", LastName="Mohammed",
                subjects=new Subject[]{ new Subject(){ Code=22,Name="EF"}, new Subject(){
                Code=33,Name="UML"}}},
                 new Student(){ ID=2, FirstName="Mona", LastName="Gala",
                subjects=new Subject []{ new Subject(){ Code=22,Name="EF"}, new Subject (){
                Code=34,Name="XML"},new Subject (){ Code=25, Name="JS"}}}, new
                Student(){ ID=3, FirstName="Yara", LastName="Yousf", subjects=new Subject
                []{ new Subject (){ Code=22,Name="EF"}, new Subject (){
                Code=25,Name="JS"}}},
                 new Student(){ ID=1, FirstName="Ali", LastName="Ali",
                subjects=new Subject []{ new Subject (){ Code=33,Name="UML"}}},
            };
            var q6 = students.Select(s => new
            {
                FullName = s.FirstName + " " + s.LastName,
                NoOfSubjects = s.subjects.Length
            });
            foreach (var item in q6)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------");
            var q7 = students.OrderByDescending(s => s.FirstName).ThenBy(s => s.LastName).Select(s => s.FirstName + " " + s.LastName);
            foreach (var item in q7)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------");
            var q8 = students.SelectMany(s => s.subjects, (s, sub) => new
            {
                StudentName = s.FirstName + " " + s.LastName,
                SubjectName = sub.Name
            });
            foreach (var item in q8)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------");
            var q9 = q8.GroupBy(s => s.StudentName);
            foreach (var group in q9)
            {
                Console.WriteLine(group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine("\t" + item.SubjectName);
                }
            }
        }
    }
}
