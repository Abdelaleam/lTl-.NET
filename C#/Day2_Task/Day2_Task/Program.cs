namespace Day2_Task
{
    internal class Program
    {
        struct time
        {
            public int hours;
            public int minutes;
            public int seconds;
            override public string ToString()
            {
                return $"{hours}H:{minutes}M:{seconds}S";
            }

        }
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("========= Menu =========");
                Console.WriteLine("1- Task 1");
                Console.WriteLine("2- Task 2");
                Console.WriteLine("3- Task 3");
                Console.WriteLine("0- Exit");
                Console.Write("Please enter your choice:");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    case 3:
                        Task3();
                        break;
                    case 0:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 0);
            #region Task 1
            void Task1()
            {
                Console.Write("Please enter number of student:");
                int n = int.Parse(Console.ReadLine());
                string[] students = new string[n];
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Name of student {i + 1}:");
                    students[i] = Console.ReadLine();
                }
                int temp = 1;
                Console.WriteLine("==================== Student Names List ====================");
                foreach (var student in students)
                {
                    Console.WriteLine($"Student {temp}:{student}");
                    temp++;
                }
            }
                #endregion
                #region Task 2
            void Task2()
            {
                Console.Write("Please enter number of tracks:");
                int n = int.Parse(Console.ReadLine());
                Console.Write("Please enter the number of students per track:");
                int s = int.Parse(Console.ReadLine());
                // we will use here Jagged Array(self studying) 
                int[][] stdAges = new int[n][];
                for (int i = 0; i < n; i++)
                {
                    stdAges[i] = new int[s];
                    Console.WriteLine($"Please enter the ages of students in track {i + 1}:");
                    for (int j = 0; j < s; j++)
                    {
                        Console.Write($"Age of student {j + 1}:");
                        stdAges[i][j] = int.Parse(Console.ReadLine());
                    }
                }
                Console.WriteLine("==================== Students Ages List ====================");
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"Track {i + 1}:");
                    double sum = 0;
                    for (int j = 0; j < s; j++)
                    {
                        Console.WriteLine($"Age of student {j + 1} = {stdAges[i][j]}");
                        sum += stdAges[i][j];
                    }
                    double avg = sum / s;
                    Console.WriteLine($"Average age of track {i + 1} = {avg}");
                }
            }
            #endregion
            #region Task 3
            void Task3()
            {
                time t1 = new time { hours = 22, minutes = 33, seconds = 11 };
                Console.WriteLine(t1);
            }
            #endregion






        }
    }
}
