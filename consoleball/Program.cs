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

Console.WriteLine("What size? : ");
string stempn = Console.ReadLine();

int itempn = int.Parse(stempn);

cMathmodule myMath = new cMathmodule();
/*
int dtempa = int.Parse(tempa);

double dtempb = double.Parse(tempb);

double dtempc = double.Parse(tempc);
*/
//dtempb = myMath.convertToRadians(dtempb);
//myMath.printTrajectoryOverTime(dtempa, .1, dtempb, dtempc);
Console.WriteLine(myMath.fibonacci(itempn));

class cMathmodule
{




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

    public double convertToRadians(double angle)
    {
        return (Math.PI / 180) * angle;
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
    public UInt128 fibonacci(int n)
    {
     Stopwatch myStopWatch = new Stopwatch();
     myStopWatch.Start();
     cFibonacci myFib = new cFibonacci();
     myStopWatch.Stop();
     Console.WriteLine($"Elapsed Ticks: {myStopWatch.ElapsedTicks}");
        return myFib.Fibonacci(n);
    }

}
class cFibonacci{
    private Dictionary<int, UInt128> _fibomemo = new Dictionary<int, UInt128>();


    public UInt128 Fibonacci(int n)
    {
        
        if (n <= 1)
        {
            return (UInt128)n;
        }
        if (!this._fibomemo.ContainsKey(n))
        { 
            UInt128 answer = Fibonacci(n - 1) + Fibonacci(n - 2);
            _fibomemo.Add(n, answer);
            return (answer);
        }
        else
        {
            return this._fibomemo[n];
        }
    }
        
    public double addDoubles(double a, double b)
    {
        return (a + b);
    }
}