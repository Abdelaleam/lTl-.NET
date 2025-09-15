namespace Day4_Task
{
    internal class Program
    {
       
        class department
        {
            public int id;
            public string deptname;
            public List<employee> employees;

        }
        class company
        {
            public int id;
            public string companyname;
            public List<department> departments;
        }
        class employee
        {
            public int id;
            public string name;
            public List<Course> Courses;
            public void Print()
            {
                Console.WriteLine($"Employee ID: {id}, Employee Name: {name}");
                Console.WriteLine("Courses:");
                foreach (var Course in Courses)
                {
                    Console.WriteLine($"Course Name: {Course.CourseName}");
                }
            }
        }
      
        class Engine
        {
            public string model;
            public int power;
            public int capacity;
            public void Start()
            {
                Console.WriteLine("Engine Started");
            }
        }
        class Car
        {
            public string brand;
            public Engine engine;
            public void Drive()
            {
                engine.Start();
                Console.WriteLine("Car is driving");
            }
        }

        class person
        {
            public string name { get; set; }
            public int age { get; set; }
            public virtual void Introduce()
            {
                Console.WriteLine($"Hello, my name is {name} and I am {age} years old.");
            }
            public person(string name, int age)
            {
                this.name = name;
                this.age = age;
            }
        }
        class Instructor: person
        {
            public int Id { get; set; }
            public Instructor(string name,int age) : base(name, age)
            {
               Id = IdGenerator.GenerateId();
            }
            override public void Introduce()
            {
                Console.WriteLine($"Hello, I am Instructor {name}, and I am {age} years old.");
            }
            public void TeachCourse(Course Course)
            {
                Course.instructor = this;
                Console.WriteLine($"{name} is teaching {Course.CourseName}");
            }

        }
        class Student: person
        {
            public int Id { get; set; }
            public List<Grade> grades { get; set; }
            public List<Course> Courses = new List<Course>();
            public Student(string name, int age) : base(name, age)
            {
                Id = IdGenerator.GenerateId();
            }
            override public void Introduce()
            {
                Console.WriteLine($"Hello, I am Student {name}, and I am {age} years old.");
            }
            public void RegisterCourse(Course Course)
            {
                Course.students.Add(this);
                Courses.Add(Course);
            }
            public void displayinfo() 
            {
                Console.WriteLine($"{name} is registered for the following Courses:");
                int i=0;
                foreach (var Course in Courses)
                {
                    Console.WriteLine($"{i+1}.{Course.CourseName}");
                    switch (Course.level)
                    {
                        case CourseLevel.Beginner:
                            Console.WriteLine("Good luck starting out !");
                            break;
                        case CourseLevel.Intermediate:
                            Console.WriteLine("This will be fun!");
                            break;
                        case CourseLevel.Advanced:
                            Console.WriteLine("This will be challenging!");
                            break;
                    }
                    i++;
                }
                //calc total grades
                Grade totalGrade = new Grade(0);
                foreach (var grade in grades)
                {
                    totalGrade += grade;
                }
                Console.WriteLine($"Total Grades: {totalGrade.Value}");
                Console.WriteLine("----------------------------------");
            }
        }
        class Course
        {
            public Course() 
            {
            }
            public Course(string CourseName, Instructor instructor, List<Student> students, CourseLevel level)
            {
                this.CourseName = CourseName;
                this.instructor = instructor;
                this.students = students;
                this.level = level;
            }

            public string CourseName { get; set; }
            public Instructor instructor  { get; set; }
            public List<Student> students { get; set; }= new List<Student>();
            public CourseLevel level { get; set; }

            
        }

       public abstract class Shape
        {
            public abstract double Area();
        }
       interface IDrawable
        {
            void Draw();
        }
         class Circle : Shape, IDrawable
          {
                public double radius { get; set; }
                public Circle(double radius)
                {
                 this.radius = radius;
                }
                public override double Area()
                {
                 return Math.PI * radius * radius;
                }
                public void Draw()=> Console.WriteLine("Drawing a Circle");      
        }
        class Rectangle : Shape, IDrawable
        {
            public double length { get; set; }
            public double width { get; set; }
            public Rectangle(double length,double width)
            {
                this.length = length;
                this.width = width;
            }
            public override double Area()
            {
                return length * width;
            }
            public void Draw() => Console.WriteLine("Drawing a Rectangle");
        }
        public static class IdGenerator
        {
            public static int currentId = 0;
            public static int GenerateId()
            {
                return ++currentId;
            }
        }
        public class Grade
        {
            public int Value { get; set; }
            public Grade(int value)
            {
                Value = value;
            }
            public static Grade operator +(Grade g1, Grade g2)
            {
                return new Grade ( g1.Value + g2.Value );
            }
            public static bool operator ==(Grade g1, Grade g2)
            {
                return  (g1.Value == g2.Value);
            }
            public static bool operator !=(Grade g1, Grade g2)
            {
                return  (g1.Value != g2.Value);
            }
        }
     public enum CourseLevel { Beginner, Intermediate, Advanced }
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>
            {
                new Circle(5),
                new Rectangle(4,6)
            };
            foreach (var shape in shapes)
            {
                Console.WriteLine($"Area: {shape.Area()}");
                var s=shape as IDrawable;
                    s.Draw();
            }
            Student student1 = new Student("Alice", 20);
            student1.grades = new List<Grade> { new Grade(85), new Grade(90) };
            Console.WriteLine($"Total Grades for {student1.name} = {(student1.grades[0] + student1.grades[1]).Value}");
            if (student1.grades[0] == student1.grades[1])
            {
                Console.WriteLine("Grades are equal");
            }
            else
            {
                Console.WriteLine("Grades are not equal");
            }
            Course carCourse = new Course { CourseName = "Car Maintenance" };
            Course Course2 = new Course { CourseName = "Advanced Driving" };
            employee employee1 = new employee { id = 1, name = "John Doe", Courses = new List<Course> { carCourse, Course2 } };
            employee employee2 = new employee { id = 2, name = "Jane Smith", Courses = new List<Course> { carCourse } };
            employee employee3 = new employee { id = 3, name = "Bob Johnson", Courses = new List<Course> { Course2 } };
            department dept1 = new department { id = 1, deptname = "Engineering", employees = new List<employee> { employee1, employee2 } };
            department dept2 = new department { id = 2, deptname = "HR", employees = new List<employee> { employee3 } };
            company company = new company { id = 1, companyname = "TechCorp", departments = new List<department> { dept1,dept2 } };
            employee1.Print();
            employee2.Print();
            List<Course> Courses= new List<Course> {
                new Course { CourseName = "C# Programming", level = CourseLevel.Beginner},
                new Course { CourseName = "Data Structures", level = CourseLevel.Intermediate},
                new Course { CourseName = "Algorithms", level = CourseLevel.Advanced }
                };
            Student studentA = new Student("ALi", 20);
            studentA.RegisterCourse(Courses[0]);
            studentA.RegisterCourse(Courses[1]);
            Student studentB = new Student("Abdelaleam", 22);
            studentB.RegisterCourse(Courses[1]);
            studentB.RegisterCourse(Courses[2]);
            Student studentC = new Student("Mohamed", 21);
            studentC.RegisterCourse(Courses[0]);
            studentC.RegisterCourse(Courses[2]);
            Instructor instructor1 = new Instructor("Dr. Smith", 45);
            instructor1.TeachCourse(Courses[0]);
            Instructor instructor2 = new Instructor("Prof. Johnson", 50);
            instructor2.TeachCourse(Courses[1]);
            Instructor instructor3 = new Instructor("Ms. Lee", 35);
            instructor3.TeachCourse(Courses[2]);
            studentA.grades = new List<Grade> { new Grade(90), new Grade(85) };
            studentB.grades = new List<Grade> { new Grade(88), new Grade(92) };
            studentC.grades = new List<Grade> { new Grade(95), new Grade(89) };
            Console.WriteLine("======================Report about Students and Instructors ===================");
            studentA.displayinfo();
            studentB.displayinfo();
            studentC.displayinfo();
            foreach(var Course in Courses)
            {
                Console.WriteLine($"Course: {Course.CourseName}, Instructor: {Course.instructor.name}");
                Console.WriteLine("Enrolled Students:");
                foreach (var student in Course.students)
                {
                    Console.WriteLine($"- {student.name}");
                }
                Console.WriteLine("----------------------------------");
            }
            Console.WriteLine("===========Company departments============");
            foreach (var dept in company.departments)
            {
                
                Console.WriteLine($"Department Name: {dept.deptname}");
                Console.WriteLine($"Number of Employees: {dept.employees.Count}");
                Console.WriteLine(".Employees:");
                int i = 0;
                foreach (var emp in dept.employees)
                {
                    Console.WriteLine($"{++i}.{emp.name}");
                    Console.WriteLine("\t.Courses:");
                    int f= 0;
                    foreach (var crs in emp.Courses)
                    {
                        Console.WriteLine($"\t\t {++f}-{crs.CourseName}");
                    }
                }
            }




        }
    }
}
