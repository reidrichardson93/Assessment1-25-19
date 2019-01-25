using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment4
{
    class Circle
    {
        //Creating center and circleRadius members as doubles
        public Point center;
        public double circleRadius{get; private set;}


        //Circle constructor that can take the coordinates as x and y but default to origin if no
        //x or y are specified
        //that being said, this constructor only requires the radius of a circle
        public Circle(double radius, double x = 0, double y = 0){
            center = new Point(x,y);
            circleRadius = radius;
        }

        //Constructor that tkaes a radius and a point object
        public Circle(double radius, Point centerPt){
            center = centerPt;
            circleRadius = radius;
        }

    }
}
