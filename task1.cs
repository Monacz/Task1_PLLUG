using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
         static bool isAbleForRectangle(double r1,double r2,double r3,double rsh1,double rsh2)
            {
                double lessersize1, lessersize2;
                lessersize1 = Math.Min(r1, r2);
                lessersize2 = Math.Min(lessersize1, r3);
                if (lessersize1 == lessersize2)
                {
                    lessersize2 = Math.Max(r1,r2);
                    double temp;
                    temp = lessersize1;
                    lessersize1 = lessersize2;
                    lessersize2 = temp;
                }
                //lessersize2 smaller than lessersize1
                if (lessersize1 <= rsh1 && lessersize2 <= rsh2 || lessersize2 <= rsh1 && lessersize1 <= rsh2) return true;
                else
                {

                    double Diagonal = Math.Pow(Math.Pow(rsh1, 2), 0.5);
                    double cosOfanagle = rsh1 / Diagonal;
                    double sin1OfAnagle = cosOfanagle;
                    double cos1ofAnagle = Math.Pow(1 - Math.Pow(sin1OfAnagle, 2), 0.5);

                    double m_rsh1 = cos1ofAnagle * lessersize2;
                    double m_rsh2 = sin1OfAnagle * lessersize2;
                    double smallDiagonal = Math.Pow(Math.Pow(m_rsh1, 2) + Math.Pow(m_rsh2, 2), 0.5);
                    double isAble = Diagonal - 2 * smallDiagonal;
                    if (isAble >=lessersize1)
                    {
                        return true;
                    }
                    return false; }
            }

           static bool isAbleForRectangle(double r1,double r2,double r3, double doorRadius)
            {
                double lessersize1, lessersize2;
                lessersize1 = Math.Min(r1, r2);
                lessersize2 = Math.Min(lessersize1, r3);
                if (lessersize1 == lessersize2)
                {
                    lessersize2 = Math.Max(r1,r2);
                    double temp;
                    temp = lessersize1;
                    lessersize1 = lessersize2;
                    lessersize2 = temp;
                }
                 //lessersize2 smaller than lessersize1

                 double radOfDescribedCircle = Math.Pow(Math.Pow(lessersize1, 2) + Math.Pow(lessersize2, 2), 0.5)/2;
                 if(doorRadius >= radOfDescribedCircle) return true;
                 else return false;
            }


           static bool isAbleForSphere(double radius,double rsh1,double rsh2)
            {
                if(2*radius <=rsh1 && 2*radius <=rsh2)
                {
                    return true;
                }
                else return false;
            }

           static bool isAbleForSphere(double radiusOfSphere,double doorRadius)
            {
                if(doorRadius >= radiusOfSphere)
                {
                    return true;
                }
                else return false;
            }

           static bool isAbleForBarrel(double radiusOfSphere,double r1, double r2, double rsh1,double rsh2)
            {
                double r3 = radiusOfSphere*2; //diametr

                if(isAbleForSphere(radiusOfSphere, rsh1, rsh2)) return true;
                else
                {
                    return isAbleForRectangle(r1,r2,r3,rsh1,rsh2);
                }
            }

           static bool isAbleForBarrel(double radiusOfSphere,double r1, double r2, double doorRadius)
            {
                double r3 = radiusOfSphere*2;
                if(isAbleForSphere(radiusOfSphere, doorRadius)) return true;
                else
                {
                    return isAbleForRectangle(r1,r2,r3,doorRadius);
                }
            }
        static void printer(bool canOrNot)
        {
            if(canOrNot) Console.WriteLine("Can");
            else Console.WriteLine("Can't");
        }
        public static void Main(string[] args)
        {
        Console.WriteLine("Write what's door you have, rec or sph"); //rectangle or Sphere

        string whatDoor;
        string whatWearDrop;
        whatDoor = Console.ReadLine();
        if(whatDoor == "rec")
        {
            double rsh1, rsh2;
            Console.WriteLine("enter size of door");
            rsh1 = Convert.ToDouble(Console.ReadLine());
            rsh2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Write what's WearDrop you have, rec,sph,bar"); //rectangle, sphere or barrel
            whatWearDrop = Console.ReadLine();
            if(whatWearDrop == "rec")
            {
                double r1,r2,r3;
                Console.WriteLine("enter size of wearDrop");
                r1=Convert.ToDouble(Console.ReadLine());
                r2 = Convert.ToDouble(Console.ReadLine());
                r3 = Convert.ToDouble(Console.ReadLine());
                printer(isAbleForRectangle(r1,r2,r3,rsh1,rsh2));
            }
            if(whatWearDrop == "shp")
            {
                Console.WriteLine("enter radius of sphere");
                double radius=Convert.ToDouble(Console.ReadLine());
                printer(isAbleForSphere(radius,rsh1,rsh2));
            }
            if(whatWearDrop == "bar")
            {
                double r1,r2;
                Console.WriteLine("enter radius of barrel, size 1,2");
                double radius=Convert.ToDouble(Console.ReadLine());
                r1 = Convert.ToDouble(Console.ReadLine());
                r2 = Convert.ToDouble(Console.ReadLine());
                printer(isAbleForBarrel(radius,r1,r2,rsh1,rsh2));
            }
            

        }
        if(whatDoor == "sph")
        {
            Console.WriteLine("Write radius of door");
            double radiusOfDoor=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Write what's WearDrop you have, rec,sph,bar"); //rectangle, sphere or barrel
            whatWearDrop = Console.ReadLine();
            if(whatWearDrop == "rec")
            {
                double r1,r2,r3;
                Console.WriteLine("enter size of wearDrop");
                r1=Convert.ToDouble(Console.ReadLine());
                r2 = Convert.ToDouble(Console.ReadLine());
                r3 = Convert.ToDouble(Console.ReadLine());
                printer(isAbleForRectangle(r1,r2,r3,radiusOfDoor));
            }
            if(whatWearDrop == "shp")
            {
                Console.WriteLine("enter radius of sphere");
                double radius=Convert.ToDouble(Console.ReadLine());
                printer(isAbleForSphere(radius,radiusOfDoor));
            }
            if(whatWearDrop == "bar")
            {
                double r1,r2;
                Console.WriteLine("enter radius of barrel, size 1,2");
                double radius=Convert.ToDouble(Console.ReadLine());
                r1 = Convert.ToDouble(Console.ReadLine());
                r2 = Convert.ToDouble(Console.ReadLine());
                printer(isAbleForBarrel(radius,r1,r2,radiusOfDoor));
            }
        }


        
    }
    }
}