﻿using System;
using System.Diagnostics;
namespace Практика9
{
    class Program
    {
        //162330 iter
        //205553 recursion
        static int FibonacciRecursion(ref int a, ref int b, ref int c)
        {        
            c = a + b;
            b = a;
            if (b < 1 && a == 0) b = 0;
            a = c;
            return c;
        }
        static void FibonacciIteration(ref int a, ref int b, ref int c)
        {
            c = a + b;
            b = a;
            a = c;
        }
        static void Main(string[] args)
        {
            int a = 0, b = 1, c = 0, m = int.Parse(Console.ReadLine()), s = 0;
            while (c <= m)
            {
                FibonacciIteration(ref a, ref b, ref c);
                s += c;
            }
            Console.WriteLine(s-c);
            
        }
    }
}
