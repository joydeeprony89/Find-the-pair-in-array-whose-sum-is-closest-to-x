using System;
using System.Collections.Generic;

namespace Find_the_pair_in_array_whose_sum_is_closest_to_x
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 0, 1, 2, 4, 7, 10, 38, 40, 50 };
            int sum = 3;
            Console.WriteLine(string.Join(" ",FindPairWhoseSumIsClosest(input, sum)));
        }

        static List<int> FindPairWhoseSumIsClosest(int[] arr, int sum)
        {
            List<int> result = new List<int>();
            int result_l = -1, result_r = -1;
            int l = 0;
            int r = arr.Length - 1;
            int MAX = int.MaxValue;
            while(l < r)
            {
                if(Math.Abs(arr[l] + arr[r] - sum) < MAX)
                {
                    result_l = l;
                    result_r = r;
                    MAX = Math.Abs(arr[l] + arr[r] - sum);
                }

                if (arr[l] + arr[r] > sum) r--;
                else l++;
            }

            result.Add(result_l);
            result.Add(result_r);
            return result;
        }

        static void Sort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int position = Partition(arr, l, r);
                Sort(arr, l, position - 1);
                Sort(arr, position + 1, r);
            }
        }

        static int Partition(int[] arr, int l, int r)
        {
            int i = l;
            int pivot = arr[r];
            for (int j = i; j < r; j++)
            {
                if(arr[j] <= pivot)
                {
                    Swap(arr, i, j);
                    i++;
                }
            }

            Swap(arr, i, r);
            return i;
        }

        static void Swap(int[] arr, int i , int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
