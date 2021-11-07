using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort_it
{
    class Sort
    {
        static void Merge(int[] mainArray, int[] array1, int[] array2)
        {
            int array1Index = 0, array2Index = 0;

            int mainArrayIndex = 0;

            while (array1Index < array1.Length && array2Index < array2.Length)
            {
                if (array1[array1Index] <= array2[array2Index])
                {
                    mainArray[mainArrayIndex] = array1[array1Index];
                    ++array1Index;
                }
                else
                {
                    mainArray[mainArrayIndex] = array2[array2Index];
                    ++array2Index;
                }

                ++mainArrayIndex;
            }

            while (array1Index < array1.Length)
            {
                mainArray[mainArrayIndex] = array1[array1Index];
                ++array1Index;
                ++mainArrayIndex;
            }

            while (array2Index < array2.Length)
            {
                mainArray[mainArrayIndex] = array2[array2Index];
                ++array2Index;
                ++mainArrayIndex;
            }
        }

        public static int [] MergeSort(int [] array)
        {
            if (array.Length > 1)
            {

                int middleIndex = array.Length / 2;

                int[] left = new int[middleIndex];
                int[] right = new int[array.Length - middleIndex];

                for (int i = 0; i < middleIndex; ++i)
                {
                    left[i] = array[i];
                }

                for (int i = middleIndex; i < array.Length; ++i)
                {
                    right[i - middleIndex] = array[i];

                }

                MergeSort(left);
                MergeSort(right);
                Merge(array, left, right);
            }

            return array;
        }
    }
}
