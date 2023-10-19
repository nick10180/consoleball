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

//Console.WriteLine("What size? : ");
//string stempn = Console.ReadLine();

//int itempn = int.Parse(stempn);

cMathmodule myMath = new cMathmodule();
/*
int dtempa = int.Parse(tempa);

double dtempb = double.Parse(tempb);

double dtempc = double.Parse(tempc);
*/
//dtempb = myMath.convertToRadians(dtempb);
//myMath.printTrajectoryOverTime(dtempa, .1, dtempb, dtempc);
//Console.WriteLine(myMath.fibonacci(itempn));

//Console.WriteLine(myMath.fibonacci(itempn, false));
int[] myints = new int[] {6, 7, 3, 6, 7};
//Console.WriteLine("Enter val to convert: ");
string temp = "0";
myints = myMath.mergeSort(myints);
Console.WriteLine(myints);

//temp = Console.ReadLine();
if(temp != null){
int tempi = int.Parse(temp);
Console.WriteLine(myMath.toBinary(tempi));
}
class cMathmodule
{
    public static string Reverse( string s )
{
    char[] charArray = s.ToCharArray();
    Array.Reverse(charArray);
    return new string(charArray);
}
    public int[] mergeSort(int[] unsortedarr){
        if(unsortedarr.Length > 1){
            int arraylength = unsortedarr.Length;
            int[] tempA = new int[arraylength/2];
            int[] tempB = new int[arraylength - tempA.Length];
            for(int i = 0; i <= (arraylength/2) - 1; i ++){
                tempA[i] = unsortedarr[i];
            }
            for(int i = tempA.Length, j = 0; i <= arraylength-1; i ++, j++){
                tempB[j] = unsortedarr[i];
            }
        
        
        tempA = mergeSort(tempA);
        tempB = mergeSort(tempB);

        unsortedarr = Merge(tempA, tempB, unsortedarr);
        }
        return unsortedarr;
    
    }

    private static int[] Merge(int[] B, int[] C, int[] A){
        for(int p = 0; p < A.Length; p++){
            for(int i = 0 ; i < B.Length; ){
                for(int j = 0 ; j < C.Length; ){
                    if(B[i] < C[j]){
                        A[p] = B[i];
                        i++;
                        if(i >= B.Length){
                            break;
                        }
                    }
                    else{
                        A[p] = C[j];
                        
                        
                        
                        j++;
                    }
                }
        
            }
        }
        return A;
    
    }

    public string toBinary(int n){
        string myString = "";
        int i = 0;
        while(n>1){
            int myans = n%2;

            n /= 2;
            myString = myString.Insert(i, myans.ToString());
            i++;
        }
        if(n==1){
            myString = myString.Insert(i, "1");
        }
        return Reverse(myString);
    }

    public double convertToRadians(double angle)
    {
        return (Math.PI / 180) * angle;
    }
    
    public UInt128 fibonacci(int n, bool flag = true)
    {
     Stopwatch myStopWatch = new Stopwatch();

     cFibonacci myFib = new cFibonacci();
          myStopWatch.Start();
    UInt128 myans = myFib.Fibonacci(n, flag);
     myStopWatch.Stop();
     Console.WriteLine($"Elapsed Ticks: {myStopWatch.ElapsedTicks}");
        return myans;
    }

}

class cTrajectoryNoDrag : cMathmodule{

    private double calculateVx(double angle, double velocity)
    {
        return velocity * Double.Cos(angle);
    }

    private double calculateVy(double yvel, double time)
    {
        return yvel - 9.8 * time;
    }

    private double calculateVy0(double angle, double velocity)
    {
        return velocity * Double.Sin(angle);
    }

    public void printTrajectoryOverTime(int duration, double timeinterval, double angle, double velocity)
    {
        double xvel, yvel, y = 0;
        xvel = calculateVx(angle, velocity);
        yvel = calculateVy0(angle, velocity);
        for (double time = 0; time < duration; time += timeinterval)
        {
            yvel = calculateVy(yvel, time);

            y = (calculateVy0(angle, velocity) * time) - ((9.8 * (time * time)) / 2);

            Console.WriteLine("x = {0} , y= {1} ,yvel= {2}", xvel * time, y, yvel);
            if (y < 0)
            {
                break;
            }

        }
    }

}
class cFibonacci : cMathmodule{
    private Dictionary<int, UInt128> _fibomemo = new Dictionary<int, UInt128>();


    public UInt128 Fibonacci(int n, bool useMemo)
    {
        
        if (n <= 1)
        {
            return (UInt128)n;
        }
        if (this._fibomemo.ContainsKey(n) && useMemo)
        { 
          return this._fibomemo[n];
        }
        else if (useMemo)
        {
             
            UInt128 answer = Fibonacci(n - 1, useMemo) + Fibonacci(n - 2, useMemo);
            _fibomemo.Add(n, answer);
            return (answer);

        }
        else
        {

            UInt128 answer = Fibonacci(n - 1, useMemo) + Fibonacci(n - 2, useMemo);
            return answer;
        }
    }
        
    public double addDoubles(double a, double b)
    {
        return (a + b);
    }
}