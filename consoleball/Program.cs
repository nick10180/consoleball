// See https://aka.ms/new-console-template for more information
/*
Console.WriteLine("Enter timems: ");
string tempa = Console.ReadLine();

Console.WriteLine("Enter angle: ");
string tempb = Console.ReadLine();


Console.WriteLine("Enter vel: ");
string tempc = Console.ReadLine();

*/

using System.Diagnostics;
using System;

namespace consoleball
{
    class Startup
    {
        static void Main(string[] args)
        {


            var myMath = new cMathmodule();
            const int MAXSIZE = 10;

            int[] myints = new int[MAXSIZE];
            int[] mybruteforce = myints;
            myints = myMath.FillArray(myints);


            myints = myMath.MergeSort(myints);
            mybruteforce = myMath.SelectionSort(mybruteforce);

            for (int i = 0; i < myints.Length; i++)
            {
                //Console.WriteLine(myints[i]);
               
            }

            
            for (int i = 0; i < mybruteforce.Length; i++)
            {
                //Console.WriteLine(mybruteforce[i]);
            }
        }
    }



    internal class cMathmodule
    {
        public static string Reverse(string s)
        {
            var charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public int[] MergeSort(int[] unsortedarr)
        {
            if (unsortedarr.Length > 1)
            {
                var arraylength = unsortedarr.Length;
                var tempA = new int[arraylength / 2];
                var tempB = new int[arraylength - tempA.Length];
                for (var i = 0; i <= arraylength / 2 - 1; i++) tempA[i] = unsortedarr[i];
                for (int i = tempA.Length, j = 0; i <= arraylength - 1; i++, j++) tempB[j] = unsortedarr[i];


                tempA = MergeSort(tempA);
                tempB = MergeSort(tempB);

                unsortedarr = Merge(tempA, tempB, unsortedarr);
            }

            return unsortedarr;
        }


        private static int[] Merge(int[] B, int[] C, int[] A)
        {
            int i = 0, j = 0, p = 0;
            while (i < B.Length && j < C.Length)
            {
                if (B[i] <= C[j])
                {
                    A[p] = B[i];
                    i++;
                }
                else
                {
                    A[p] = C[j];
                    j++;
                }

                p++;
            }

            while (j < C.Length)
            {
                A[p] = C[j];
                j++;
                p++;
            }

            return A;
        }


        public int[] SelectionSort(int[] arr)
        {

            for (int i = 0; i < arr.Length; i++)
            {
                var min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] >= arr[min])
                        continue; //Jetbrains says invert if statement to avoid nesting... that's kinda cool ig.
                    min = j;
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }

            }

            return arr;
        }

        public int[] FillArray(int[] arr)
        {
            var rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next();
            }

            return arr;
        }

        public string toBinary(int n)
        {
            var myString = "";
            var i = 0;
            while (n > 1)
            {
                var myans = n % 2;

                n /= 2;
                myString = myString.Insert(i, myans.ToString());
                i++;
            }

            if (n == 1) myString = myString.Insert(i, "1");
            return Reverse(myString);
        }

        public double convertToRadians(double angle)
        {
            return Math.PI / 180 * angle;
        }

        public UInt128 fibonacci(int n, bool flag = true)
        {
            var myStopWatch = new Stopwatch();

            var myFib = new cFibonacci();
            myStopWatch.Start();
            var myans = myFib.Fibonacci(n, flag);
            myStopWatch.Stop();
            Console.WriteLine($"Elapsed Ticks: {myStopWatch.ElapsedTicks}");
            return myans;
        }
    }

    internal class cTrajectoryNoDrag : cMathmodule
    {
        private double calculateVx(double angle, double velocity)
        {
            return velocity * double.Cos(angle);
        }

        private double calculateVy(double yvel, double time)
        {
            return yvel - 9.8 * time;
        }

        private double calculateVy0(double angle, double velocity)
        {
            return velocity * double.Sin(angle);
        }

        public void printTrajectoryOverTime(int duration, double timeinterval, double angle, double velocity)
        {
            double xvel, yvel, y = 0;
            xvel = calculateVx(angle, velocity);
            yvel = calculateVy0(angle, velocity);
            for (double time = 0; time < duration; time += timeinterval)
            {
                yvel = calculateVy(yvel, time);

                y = calculateVy0(angle, velocity) * time - 9.8 * (time * time) / 2;

                Console.WriteLine("x = {0} , y= {1} ,yvel= {2}", xvel * time, y, yvel);
                if (y < 0) break;
            }
        }
    }

    internal class cFibonacci : cMathmodule
    {
        private readonly Dictionary<int, UInt128> _fibomemo = new();


        public UInt128 Fibonacci(int n, bool useMemo)
        {
            if (n <= 1) return (UInt128)n;
            if (_fibomemo.ContainsKey(n) && useMemo) return _fibomemo[n];

            if (useMemo)
            {
                var answer = Fibonacci(n - 1, useMemo) + Fibonacci(n - 2, useMemo);
                _fibomemo.Add(n, answer);
                return answer;
            }
            else
            {
                var answer = Fibonacci(n - 1, useMemo) + Fibonacci(n - 2, useMemo);
                return answer;
            }
        }

        public double addDoubles(double a, double b)
        {
            return a + b;
        }
    }
}