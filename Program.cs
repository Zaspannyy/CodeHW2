using System;
using System.Collections.Generic;

namespace HW2
{
    class Program
    {
        static void Main(string[] args)
        {  
            int[] array = new int[] { -3, 0, 2, 4, 5 };
            int k = 6;
            int[] result1 = Calc1(array, k);
            int[] result2 = Calc2(array, k);
            int[] result3 = Calc3(array, k);
            int[] result4 = Calc4(array, k);

            Console.Write("Результат перебора всех пар  -  " ); Console.WriteLine ($"[{result1[0]},{result1[1]}]");
            Console.Write("Результат хэш сета  -  "); Console.WriteLine($"[{result2[0]},{result2[1]}]");
            Console.Write("Результат бинарного поиска  -  "); Console.WriteLine($"[{result3[0]},{result3[1]}]");
            Console.Write("Результат поиска двумя показателями  -  "); Console.WriteLine($"[{result4[0]},{result4[1]}]");

        }

        static int[] Calc1(int[] array, int k) 
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] + array[j] == k)
                    {
                        return new int[] { array[i], array[j] };
                    }

                }
            }            
            return null;  
        }

        static int[] Calc2(int[] array, int k) 
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < array.Length; i++)
            {
                int numberToFind = k - array[i];
                if (set.Contains(numberToFind))
                {
                    return new int[] { numberToFind, array[i] };
                }
                set.Add(array[i]);
            }
            return null;
        }
        static int[] Calc3(int[] array, int k) 
        {
            for (int i = 0; i < array.Length; i++)
            {
                int numberToFind = k - array[i];
                int l = i + 1;
                int r = array.Length - 1;
                while (l <= r)
                {
                    int mid = l + (r - l) / 2;
                    if (array[mid] == numberToFind)
                    {
                        return new int[] { numberToFind, array[i] };
                    }
                    if (numberToFind < array[mid])
                    {
                        r = mid - 1;
                    }
                    else
                    {
                        l = mid + 1;
                    }
                }

            }
            return null;
        }

        static int[] Calc4(int[] array, int k) 
        {
            int l = 0;
            int r = array.Length - 1;
            while (l < r)
            {
                int sum = array[l] + array[r];
                if (sum == k)
                {
                    return new int[] { array[l], array[r] };
                }
                if (sum < k)
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }
            return null;
        }

    }

}