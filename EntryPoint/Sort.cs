using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class Sort
    {
        public Vector2[] listContent;
        public Sort(Vector2[] vector2Array)
        {
            listContent = vector2Array;
        }

        public void MergeSort(Vector2 house)
        {
            MergeSort(house, listContent, 0, listContent.Length - 1);
        }

        public void MergeSort(Vector2 house, Vector2[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSort(house, array, left, middle);
                MergeSort(house, array, middle + 1, right);
                Merge(house, array, left, middle, right);
            }
        }
        public void Merge(Vector2 house, Vector2[] array, int left, int middle, int right)
        {
            int leftLength = middle - left + 1;
            int rightLength = right - middle;

            Vector2[] leftArray = new Vector2[leftLength + 1];
            Vector2[] rightArray = new Vector2[rightLength + 1];

            for (int i = 0; i < leftLength; i++)
            {
                leftArray[i] = array[left + i];
            }
            for (int i = 0; i < rightLength; i++)
            {
                rightArray[i] = array[middle + i + 1];
            }

            leftArray[leftLength] = new Vector2(float.PositiveInfinity);
            rightArray[rightLength] = new Vector2(float.PositiveInfinity);

            int leftCounter = 0;
            int rightCounter = 0;
            for (int i = left; i <= right; i++)
            {
                if (Vector2.Distance(leftArray[leftCounter], house) < Vector2.Distance(rightArray[rightCounter], house))
                    array[i] = leftArray[leftCounter++];
                else
                    array[i] = rightArray[rightCounter++];
            }
        }
    }
}