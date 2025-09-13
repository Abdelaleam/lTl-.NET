using System.Drawing;

namespace Day3_Task
{
    internal class Program
    {
      static void Main(string[] args)
        {
            var m = new mcq
            {
                header = "Math Question",
                body = "2*2+6=......",
                mark = 5,
                choices = new string[] { "8", "6", "4", "10" },
                answer = "10"
            };
            m.show();
            var ans=int.Parse(Console.ReadLine());
            m.checkAnswer(ans);
            question q = new mcq
            {
                header = "Math Question",
                body = "2*2*6=.....",
                mark = 5,
                choices = new string[] { "8", "6", "4", "24" },
                answer = "24"
            };
            ((mcq)q).show();
            var ans2 = int.Parse(Console.ReadLine());
            ((mcq)q).checkAnswer(ans2);
            Console.WriteLine("Enter number of questions to make quiz:");
            var numOfQuestions =int.Parse(Console.ReadLine());
            mcq[] questions = new mcq[numOfQuestions];
            int totalMarks = 0;
            for (int  i = 0;  i < numOfQuestions;  i++)
            {
                Console.WriteLine($"Enter question number{i+1}");
                Console.Write("Enter header:");
                string header = Console.ReadLine();
                Console.Write("Enter body:");
                string body = Console.ReadLine();
                Console.Write("Enter mark:");
                int mark = int.Parse(Console.ReadLine());
                Console.WriteLine("Number of choices");
                int numOfChoices = int.Parse(Console.ReadLine());
                string[] choices = new string[numOfChoices];
                for (int j = 0; j < numOfChoices; j++)
                {
                    Console.Write($"Enter choice {j + 1}: ");
                    choices[j] = Console.ReadLine();
                }
                Console.Write("Enter answer:");
                string answer = Console.ReadLine();
                questions[i] = new mcq(header, body, mark, choices, answer);
            }
            Console.WriteLine("Quiz Started:");
            foreach (var mm in questions)
            {
                mm.show();
                var answer = int.Parse(Console.ReadLine());
                mm.checkAnswer(answer);
                if (mm.isCorrect)
                    totalMarks += mm.mark;
            }
            Console.WriteLine("Quiz Ended");
            Console.WriteLine($"Total Marks: {totalMarks}");

        }
        #region Task1 (class calc)
        public class calc
        {
            public static int sum(int a, int b)
            {
                return a + b;
            }
            public static double sum(double a, double b)
            {
                return a + b;
            }
            public static int sub(int a, int b)
            {
                return a - b;
            }
            public static double sub(double a, double b)
            {
                return a - b;
            }
            public static int mul(int a, int b)
            {
                return a * b;
            }
            public static double mul(double a, double b)
            {
                return a * b;
            }
            public static double div(int a, int b)
            {
                if (b == 0)
                {
                    throw new DivideByZeroException("Denominator cannot be zero.");
                }
                return (double)a / b;
            }
            public static double div(double a, double b)
            {
                if (b == 0.0)
                {
                    throw new DivideByZeroException("Denominator cannot be zero.");
                }
                return a / b;
            }
        }
        #endregion
        #region Task2 (class question) (header , body , mark  , show())
        class question
        {
            public string header { get; set; }
            public string body { get; set; }
            public int mark { get; set; }
            public question()
            {
                header = "Default Header";
                body = "Default Body";
                mark = 0;
            }
            
           public question(string header, string body, int mark)
            {
                this.header = header;
                this.body = body;
                this.mark = mark;
            }
            public virtual void show()
            {
                Console.WriteLine($"{header}:[{mark}]marks");
                Console.WriteLine($"{body}?");
            }
           
        }
        class mcq : question
        {
            public string[] choices { get; set; }
            public string answer { get; set; }
            public bool isCorrect { get; set; }
            public mcq()
            {
            
            }
            public mcq(string header, string body, int mark, string[] choices, string answer) : base(header, body, mark)
            {
                this.choices = choices;
                this.answer = answer;
            }
            public override void show()
            {
                base.show();
                for (int i = 0; i < choices.Length; i++)
                {
                    Console.WriteLine($"({i + 1}) {choices[i]}");
                }
            }
           public void checkAnswer(int ans)
            {
                if (choices[ans- 1] == answer)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct Answer");
                    isCorrect = true;
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong Answer");
                    isCorrect = false;
                    Console.ResetColor();
                }
            }
        }
        #endregion

    }
}
