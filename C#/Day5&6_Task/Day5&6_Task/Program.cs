using System.Collections;

namespace Day5_6_Task
{
    internal class Program
    {
        #region Task1
        public static void optemizedBubbleSort<T>(T[] arr) where T:IComparable<T>
        {
            int n=arr.Length;
            bool nochange=false;
            for(int i=0; i<n; i++)
            {
                nochange = true;
                for(int j=0; j<n-i-1; j++)
                {
                    if(arr[j].CompareTo(arr[j+1])>0)
                    {
                        (arr[j], arr[j+1]) = (arr[j+1], arr[j]);
                        nochange = false;
                    }
                }
                if(nochange) break;
            }
           
        }
        #endregion
        #region Task2
        class Range<T> where T : IComparable<T>
        {
            T min { get; set; }
            T max { get; set; }
            public Range(T min, T max)
            {
                this.min = min;
                this.max = max;
            }
            public bool isInRange(T value) 
            {
                return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
            }
            public int Length()
            {
                dynamic min_val = min;
                dynamic max_val = max;
                return max_val - min_val;
            }
        }
        #endregion
        #region Task3
        public void ArrayList_Reverse (ArrayList arr)
        {
            int n = arr.Count;
            for(int i=0; i<n/2; i++)
            {
                (arr[i], arr[n-i-1]) = (arr[n-i-1], arr[i]);
            }
        }
        #endregion
        #region Task4
        public List<int> Even_nums(List<int> arr)
        {
            List<int> even_nums = new List<int>();
            foreach(int num in arr)
            {
                if(num%2==0)
                {
                    even_nums.Add(num);
                }
            }
            return even_nums;
        }
        #endregion
        #region Task5
        class FixedSizeList<T>
        {
            private readonly T[] items;
            public int capacity { get; private set; }
            public int count { get; private set; }
            public FixedSizeList(int capacity)
            {
                if (capacity <= 0)
                    throw new ArgumentException("Capacity must be greater than zero.");
                this.capacity = capacity;
                items = new T[capacity];
                count = 0;
            }
            public void Add(T item)
            {
                if(count >= capacity)
                    throw new InvalidOperationException("List is full.");
                items[count++] = item;
            }
            public T Get(int index)
            {
                if(index < 0 || index >= count)
                    throw new ArgumentOutOfRangeException("Index out of range.");
                return items[index];
            }
            public void Display()
            {
                for(int i=0; i<count; i++)
                {
                    Console.Write(items[i]+" ");
                }
                Console.WriteLine();
            }
        }
        #endregion
        #region Task6
        public int FirstNonRepeatedChar(string str)
        {
            Dictionary<char,int> freq = new Dictionary<char,int>();
            if(str is not null)
            {
                foreach(var c in str)
                {
                    if(freq.ContainsKey(c))
                        freq[c]++;
                    else 
                        freq[c] = 1;
                }
           
            for(int i=0;i<str.Length; i++)
            {
                if (freq[str[i]] == 1)
                    return i;
            }
            }

            return -1;
        }
        #endregion

        static void Main(string[] args)
        {
          
        }
    }
}
