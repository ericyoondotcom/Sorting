using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    public static class MySorter
    {
        public static T[] BubbleSort<T>(T[] data, Comparison<T> c){
            bool allSorted = true;

            for (int i = 0; i < data.Length - 1; i++){
                if(c(data[i], data[i + 1]) > 0){
                    allSorted = false;
                    T swap = data[i];
                    data[i] = data[i + 1];
                    data[i + 1] = swap;
                }
            }

            if(allSorted){
                return data;
            }else{
                return BubbleSort<T>(data, c);
            }
        }

        public static T[] SelectionSort<T>(T[] data, Comparison<T> c, int sortedPos = 0){
            int least = sortedPos;
            for (int i = sortedPos; i < data.Length; i++){
                if(c(data[i], data[least]) < 0){
                    least = i;
                }
            }
            T swap = data[sortedPos];
            data[sortedPos] = data[least];
            data[least] = swap;

            if(++sortedPos >= data.Length - 1){
                return data;
            }else{
                return SelectionSort<T>(data, c, sortedPos);
            }

        }
        public static T[] InsertionSort<T>(T[] dataArr, Comparison<T> c, int sortedPos = 1, List<T> dataList = null){
            List<T> data;
            if (dataList != null)
            {
                data = dataList;
            }
            else
            {
                data = new List<T>(dataArr);
            }
            for (int i = 0; i < sortedPos; i++){
                if(c(data[sortedPos], data[i]) <= 0){
                    data.Insert(i, data[sortedPos]);
                    data.RemoveAt(sortedPos + 1);
                }
            }
            if(++sortedPos >= data.Count){
                return data.ToArray();
            }else{
                return InsertionSort<T>(null, c, sortedPos, data);
            }
        }


        public static T[] MergeSort<T>(T[] data, Comparison<T> c){
            if(data.Length == 1){
                return data;
            }
            if(data.Length == 2){
                if(c(data[0], data[1]) <= 0){
                    return data;
                }

                T swap = data[0];
                data[0] = data[1];
                data[1] = swap;
                return data;
            }


            T[] sorted1 = MergeSort<T>(data.Take(data.Length / 2).ToArray(), c);
            T[] sorted2 = MergeSort<T>(data.Skip(data.Length / 2).ToArray(), c);
            if (c(sorted1[0], sorted2[0]) <= 0)
            {
                T[] combined = new T[sorted1.Length + sorted2.Length];
                sorted1.CopyTo(combined, 0);
                sorted2.CopyTo(combined, sorted1.Length);
                return combined;
            }
            else
            {
                T[] combined = new T[sorted1.Length + sorted2.Length];
                sorted2.CopyTo(combined, 0);
                sorted1.CopyTo(combined, sorted2.Length);
                return combined;
            }
        }
    }
}
