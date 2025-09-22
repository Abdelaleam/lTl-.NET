namespace Day7_Task
{
    #region Task1
    class Product
      {
        public string name { get; set; }
        public double price { get; set; }
     }
    #endregion
    #region Task2,3,4,5
    static class ExtensionMethods
    {
        public static int countwords(this string str)
        {
            var words = str.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            return words.Count();
        }
        public static bool IsEven(this int num)
        {
               return num % 2 == 0;
        }
        public static int age(this DateTime date)
        {
            var now = DateTime.Now;
            int age = now.Year - date.Year;
            if (now < date.AddYears(age)) age--;
            return (age>=0)?age:-1;
        }
        public static string ReverseString(this string str)
        {
            var charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
    #endregion
    internal class Program
    {
        public static object createProduct()
        {
            return new { name = "Sample Product", price = 9.99 };
        }
        static void Main(string[] args)
        {
           var product = createProduct();
            Console.WriteLine(product);
        }
    }
}
