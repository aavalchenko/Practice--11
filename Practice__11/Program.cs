using System;
using System.Threading;
using InputOutputLib;

namespace Practice__11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Закодированная строка: " + Encode(RemakeString(GetString())));
            Console.WriteLine("Декодировка закодированной строки: " + RemakeArray(Decode(GetString())));
            Console.ReadKey();
        }

        private static string GetString()
        {
            string input = Get.String("Введите строку из 121 символа: ");
            if (input.Length != 121)
                throw new ArgumentException("Длина строки не 121 символ.");
            return input;
        }
        private static char[,] RemakeString(string input)
        {
            char[,] array = new char[11,11];
            Int16 count = 0;
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    array[i, j] = input[count];
                    count++;
                }   
            }

            return array;
        }
        private static string RemakeArray(char[,] array)
        {
            string output = "";
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    output += array[i, j];
                }
            }

            return output;
        }
        private static string Encode(char[,] array)
        {
            string output = "";

            Int16 i = 5, j = 5, k = 1, count = 0;
            ReadToCircle(array, ref k, ref output, ref i, ref j);
            while (count < 5)
            {
                ReadCircle(array, ref k, ref output, ref i, ref j);
                count++;
            }

            return output;
        }
        private static char[,] Decode(string input)
        {
            char[,] array =  new char[11,11];
            Int16 i = 5, j = 5, k = 1, count = 0;
            WriteToCircle(ref array, ref k, input, ref i, ref j, ref count);
            while (count < 121)
            {
                WriteCircle(ref array, ref k, input, ref i, ref j, ref count);
            }

            return array;
        }
        private static void ReadCircle(char[,] array, ref Int16 k, ref string output, ref Int16 i, ref Int16 j)
        {
            ReadToRight(array, k, ref output, ref i, ref j);
            k++;
            ReadToDown(array, k, ref output, ref i, ref j);
            ReadToLeft(array, k, ref output, ref i, ref j);
            if (k < 10)
                k++;
            ReadToUp(array, k, ref output, ref i, ref j);
        }
        private static void ReadToUp(char[,] array, Int16 k, ref string output, ref Int16 i, ref Int16 j)
        {
            while (k > 0)
            {
                i = (short) (i - 1);
                output += array[i, j];
                k--;
            }
        }
        private static void ReadToDown(char[,] array, Int16 k, ref string output, ref Int16 i, ref Int16 j)
        {
            while (k > 0)
            {
                i = (short) (i + 1);
                output += array[i, j];
                k--;
            }
        }
        private static void ReadToRight(char[,] array, Int16 k, ref string output, ref Int16 i, ref Int16 j)
        {
            while (k > 0)
            {
                j = (short) (j + 1);
                output += array[i, j];
                k--;
            }
        }
        private static void ReadToLeft(char[,] array, Int16 k, ref string output, ref Int16 i, ref Int16 j)
        {
            while (k > 0)
            {
                j = (short) (j - 1);
                output += array[i, j];
                k--;
            }
        }
        private static void ReadToCircle(char[,] array, ref Int16 k, ref string output, ref Int16 i, ref Int16 j)
        {
            output += array[i, j];
            ReadToUp(array, k, ref output, ref i, ref j);
        }
        private static void WriteCircle(ref char[,] array, ref Int16 k, string output, ref Int16 i, ref Int16 j, ref Int16 count)
        {
            WriteToRight(ref array, k, output, ref i, ref j, ref count);
            k++;
            WriteToDown(ref array, k, output, ref i, ref j, ref count);
            WriteToLeft(ref array, k, output, ref i, ref j, ref count);
            if (k < 10)
                k++;
            WriteToUp(ref array, k, output, ref i, ref j, ref count);
        }
        private static void WriteToUp(ref char[,] array, Int16 k, string output, ref Int16 i, ref Int16 j, ref Int16 count)
        {
            while (k > 0)
            {
                i = (short)(i - 1);
                array[i, j] = output[count];
                k--;
                count++;
            }
        }
        private static void WriteToDown(ref char[,] array, Int16 k, string output, ref Int16 i, ref Int16 j, ref Int16 count)
        {
            while (k > 0)
            {
                i = (short)(i + 1);
                array[i, j] = output[count];
                k--;
                count++;
            }
        }
        private static void WriteToRight(ref char[,] array, Int16 k, string output, ref Int16 i, ref Int16 j, ref Int16 count)
        {
            while (k > 0)
            {
                j = (short)(j + 1);
                array[i, j] = output[count];
                k--;
                count++;
            }
        }
        private static void WriteToLeft(ref char[,] array, Int16 k, string output, ref Int16 i, ref Int16 j, ref Int16 count)
        {
            while (k > 0)
            {
                j = (short)(j - 1);
                array[i, j] = output[count];
                k--;
                count++;
            }
        }
        private static void WriteToCircle(ref char[,] array, ref Int16 k, string output, ref Int16 i, ref Int16 j, ref Int16 count)
        {
            array[i, j] = output[count];
            count++;
            WriteToUp(ref array, k, output, ref i, ref j, ref count);
        }
    }
}
