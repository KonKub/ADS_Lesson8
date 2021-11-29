using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{

    class Program
    {

		static void BucketSort(ref int[] Arr, int n)
		{
			if (n <= 0 || Arr is null || Arr.Length < 2) return;

			int MaxValue = Arr[0];
			int BucketNum;

			for (int i = 1; i < Arr.Length; i++)
				if (Arr[i] > MaxValue) MaxValue = Arr[i];

			// 1) Create n empty buckets
			List<int>[] Bucket = new List<int>[n];

			for (int i = 0; i < n; i++)
			{
				Bucket[i] = new List<int>();
			}

			// 2) Put array elements in different buckets
			for (int i = 0; i < Arr.Length; i++)
			{
				BucketNum = (Arr[i] * n / (MaxValue + 1));
				Bucket[BucketNum].Add(Arr[i]);
			}

			// 3) Sort individual buckets
			for (int i = 0; i < n; i++)
			{
				Bucket[i].Sort();
			}

			// 4) Concatenate all buckets into arr[]
			int k = 0;
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < Bucket[i].Count; j++)
				{
					Arr[k++] = Bucket[i][j];
				}
			}
		}


        static void Test()
        {

            int[] A1 = { 5,4,3,2,1};

            BucketSort(ref A1,5);

			if (A1[0] == 1 && A1[1] == 2 && A1[2] == 3 && A1[3] == 4 && A1[4] == 5)
				Console.WriteLine("VALID TEST");
			else
				Console.WriteLine("INVALID TEST");

			int[] A2 = { 100, 0, 30, 12, 99 };

			BucketSort(ref A2, 5);

			if (A2[0] == 0 && A2[1] == 12 && A2[2] == 30 && A2[3] == 99 && A2[4] == 100)
				Console.WriteLine("VALID TEST");
			else
				Console.WriteLine("INVALID TEST");
		}


		static void Main(string[] args)
        {
			int[] a = new int[] { 96,1,20,3,40,0,50,80,53,5,10,100 };
			BucketSort(ref a, 3);

			for (int i=0; i<a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }


            Test();

            Console.ReadKey();
        }
    }
}
