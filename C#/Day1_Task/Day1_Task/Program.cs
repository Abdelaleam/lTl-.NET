namespace Day1_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("========= Menu =========");
                Console.WriteLine("1- Task 1");
                Console.WriteLine("2- Task 2");
                Console.WriteLine("3- Task 3");
                Console.WriteLine("4- Task 4");
                Console.WriteLine("5- Task 5");
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
                    case 4:
                        Task4();
                        break;
                    case 5:
                        Task5();
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
                Console.WriteLine("Enter any character");
            char c = Console.ReadLine()[0];
            Console.WriteLine((int)c);
            Console.WriteLine("Enter any ASCII code");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine((char)a);
            }
            #endregion
            #region Task 2
            void Task2()
            {
                Console.WriteLine("Enter any number");
            int n = int.Parse(Console.ReadLine());
            string r = (n % 2 == 0) ? "Even" : "Odd";
            Console.WriteLine($"The number {n} is {r}");
            }
            #endregion
            #region Task 3
            void Task3()
            {
                Console.WriteLine("Enter first number");
                int n1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter second number");
                int n2 = int.Parse(Console.ReadLine());
                Console.WriteLine($"{n1} + {n2} = {n1 + n2}");
                Console.WriteLine($"{n1} - {n2} = {n1 - n2}");
                Console.WriteLine($"{n1} * {n2} = {n1 * n2}");
            }
            #endregion
            #region Task 4
            void Task4()
            {
                Console.WriteLine("Please enter your degree from 0 to 100");
                int d = int.Parse(Console.ReadLine());
                if (d < 0 || d > 100)
                {
                    Console.WriteLine("Invalid degree");
                    return;
                }
                string r = (d >= 90 && d <= 100) ? "A" :
                          (d >= 80 && d < 90) ? "B" :
                          (d >= 70 && d < 80) ? "C" :
                          (d >= 60 && d < 70) ? "D" : "F";
                Console.WriteLine($"Your grade is {r}");
            }
            #endregion
            #region Task 5
            void Task5()
            {
            Console.WriteLine("Enter any number to print its multiplication table");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"multiplication table for {n}:");
            for (int i = 1; i <= 12; i++)
            {
                Console.WriteLine($"{n} * {i} = {n * i}");
            }
            }
            #endregion
        }
    }
    }
