using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    static int Dop(int j, int N)
    {
        if (j == (N - 1))
            return 0;
        return (((N - 1) - j) + Dop(j + 1, N));
    }

    public int solution(int[] A)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        if (A.Length < 1)
            return 0;
        
        int N = A.Length;
        int[] Right = new int[N];
        int[] Left = new int[N];
        for (int i = 0; i < N; ++i)
        {
            Left[i] = i - A[i];
            if ((uint)(i + A[i]) > 2147483647)
                Right[i] = 2147483647;
            else
                Right[i] = i + A[i];
        }
        Array.Sort(Left);
        Array.Sort(Right);
        int j = 0;
        int sum = 0;
        for (int i = 0; i < N; ++i)
            if (Left[i] > Right[j])
            {
                sum += i - j - 1;
                j++;
                i--;
            }
        sum += Dop(j, N);

        if (sum > 10000000)
            sum = -1;


        return sum;

    }
}