using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    class Program
    {
        static int LinearExhaustive(int[] a, int x) // Vét cạn => Mang bat ky
        { // Vet can 2 phep so sanh
            int i = 0;
            int n = a.Length;
            for (; i < n; i++) // Phep so sanh 1
            {
                if (a[i] == x) // Phep so sanh 2
                    break;
            }
            return i;
        }

        static int LinearSentinel(int[] a, int x) // Linh canh => Mang bat ky
        {
            // Buoc 1: Khoi tao i
            int i = 0;
            // Buoc 2: them phan tu can tim vao mang a
            int[] b = new int[a.Length + 1];
            for (int j = 0; j < a.Length; j++)
                b[j] = a[j];
            b[a.Length] = x;
            // Tim x
            for (; b[i] != x; i++) ; // Linh Canh 1 phep So sanh
            return i;
        }

        static int BinarySearch(int[] a, int x) // Tim kiem nhi phan 
        { // Nhi phan => Mang da sap xep tang dan
            int left = 0;
            int right = a.Length - 1;
            int mid = -1;
            while (left <= right)
            {
                mid = (left + right) / 2;
                if (x == a[mid])
                    break; // da tim thay x tai mid
                if (x < a[mid])
                    right = mid - 1;
                else // x > a[mid]
                    left = mid + 1;
            }
            if (left <= right)
                return mid;
            else // left > right
                return -1;
        }

        static int BinarySearchRecursively(int[] a, int left, int right, int x)
        { // Tim kiem nhi phan kieu De quy
            if (left > right)
                return -1;
            int mid = (left + right) / 2;
            if (x == a[mid])
                return mid;
            if (x < a[mid])
                return BinarySearchRecursively(a, left, mid - 1, x);
            // x > a[mid]
            return BinarySearchRecursively(a, mid + 1, right, x); // Ham De quy se chay 2 lan
        }

        static void Main(string[] args)
        {
            // int[] a = { 5, 9, 33, 17, 45, 6 };
            int[] a = { 5, 9, 13, 17, 45, 66 };
            int x = 45;
            //int pos = LinearExhaustive(a, x);
            int pos = LinearSentinel(a, x);
            //int pos = BinarySearch(a, x);
            //int pos = BinarySearchRecursively(a, 0, a.Length - 1, x);
            if (pos < a.Length)
                Console.WriteLine("Vi tri cua x trong mang a la: " + pos.ToString());
            else
                Console.WriteLine("Khong tim thay x");

            Console.ReadLine();
        }
    }
}
