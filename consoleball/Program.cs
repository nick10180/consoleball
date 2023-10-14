// See https://aka.ms/new-console-template for more information

Console.WriteLine("Enter timems: ");
string tempa = Console.ReadLine();

Console.WriteLine("Enter angle: ");
string tempb = Console.ReadLine();


Console.WriteLine("Enter vel: ");
string tempc = Console.ReadLine();


Mathmodule myMath = new Mathmodule();
int dtempa = int.Parse(tempa);

double dtempb = double.Parse(tempb);

double dtempc = double.Parse(tempc);

dtempb = myMath.convertToRadians(dtempb);
myMath.printTrajectoryOverTime(dtempa, .1, dtempb, dtempc);

class Mathmodule
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
            
            y = (calculateVy0(angle,velocity) * time) - (( 9.8 * (time * time)) / 2);
            
            Console.WriteLine("x = {0} , y= {1} ,yvel= {2}" , xvel*time, y, yvel);
            if (y < 0)
            {
                break;
            }
           
   
        }
    }
        
        
    public double addDoubles(double a, double b)
    {
        return (a + b);
    }
}