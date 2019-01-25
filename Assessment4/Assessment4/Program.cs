using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment4
{
    class Program
    {
        static void Main(string[] args)
        {
            //A bunch of prompts to the user to enter in the coordinates and radius of Circle 1
            double x1 = double.Parse(Prompt("Please enter the x coordinate for Circle 1"));
            double y1 = double.Parse(Prompt("Please enter the y coordinate for Circle 1"));
            //Added Math.Abs to this in order to account for negative radius (negative radius is still same radius)
            double radius1 = Math.Abs(double.Parse(Prompt("Please enter the radius for Circle 1")));


            //A bunch of prompts to the user to enter in the coordinates and radius of Circle 2
            double x2 = double.Parse(Prompt("Please enter the x coordinate for Circle 2"));
            double y2 = double.Parse(Prompt("Please enter the y coordinate for Circle 2"));
            //Added Math.Abs to this in order to account for negative radius (negative radius is still same radius)
            double radius2 = Math.Abs(double.Parse(Prompt("Please enter the radius for Circle 2")));

            //instantiating the circle class circle objects using user input data
            Circle circle1 = new Circle(radius1, x1, y1);
            Circle circle2 = new Circle(radius2, x2, y2);

            //calling compareCircles function to get the relationship btw the two circles
            string output = compareCircles(circle1, circle2);

            //displaying the compareCircles function output to the console screen for the user to see
            Console.WriteLine("\n" + output);
            Console.ReadKey();
        }

        
        //prompt function that accepts a string a returns a user input string
        static string Prompt(string msg){
            Console.Write(msg + ": ");
            return Console.ReadLine();
        }

        //compareCircles method that accepts two circle objects and returns a string
        //The method compares the distance btw the center of both circles and the sum of both radii
        //to determine if the circles are not touching, tangent, overlapping, or one inside the other
        static string compareCircles(Circle circle1, Circle circle2){

            //default return message if none of the cases are hit (also initializing the return message string)
            string rtnMessage = "Error, no comparison found.";

            //This is the mathmatical equation that gives the distance between two points
            //here those two points are the center of each circle
            //Equation is ((x2 - x1)^2 + (y2 - y1)^2)^(1/2)
            double distanceApart = Math.Sqrt(Math.Pow((circle2.center.x - circle1.center.x), 2) + Math.Pow((circle2.center.y - circle1.center.y), 2));

            //Calculating the sum of both radii for comparison to distance apart
            double totalRadii = circle2.circleRadius + circle1.circleRadius;

            //This calculates the larger circle in case one is inside the other
            bool circle1Larger = false;
            if (circle1.circleRadius > circle2.circleRadius){
                circle1Larger = true;
            }

            //Starting the process of elimination with circles not touching, then going to tangent, then going to overlapping/inside eachother

            //If the sum of the radii is less than the total distance btw the two center points then the circles do not touch
            if (totalRadii < distanceApart){
                rtnMessage = "These two circles do not touch.";

            //If the sum of the radii is equal to the total distance btw the two center points then the circles are tangent
            }else if (totalRadii == distanceApart){
                rtnMessage = "These two circles are tangent";

            //If the sum of the radii is greater than the total distance btw the two center points then the circles either overlap or are inside eachother
            }else if (totalRadii > distanceApart){

                //This checks which circle was already determined to be larger
                //If circle 1 is larger then we check if circle 2 is completely inside circle 1
                if (circle1Larger){

                    //If the distance btw the center of each circle plus the radius of the smaller circle is less than
                    //the radius of the larger circle then it can be assumed that smaller circle is inside the larger circle
                    if ((distanceApart + circle2.circleRadius) < circle1.circleRadius){
                        rtnMessage = "Circle 2 is inside of Circle 1.";
                    
                    //If one circle is not completely inside another then it can be assumed that they are overlapping
                    }else{
                        rtnMessage = "These two circles overlap.";
                    }

                //This checks which circle was already determined to be larger (if not true then auto false)
                //If circle 2 is larger then we check if circle 1 is completely inside circle 2
                }else{

                    //If the distance btw the center of each circle plus the radius of the smaller circle is less than
                    //the radius of the larger circle then it can be assumed that smaller circle is inside the larger circle
                    if ((distanceApart + circle1.circleRadius) < circle2.circleRadius){
                        rtnMessage = "Circle 1 is inside of Circle 2.";

                    //If one circle is not completely inside another then it can be assumed that they are overlapping
                    }else{
                        rtnMessage = "These two circles overlap.";
                    }
                }
            }
            //return the return message string
            return rtnMessage;
        }//end method
    }
}
