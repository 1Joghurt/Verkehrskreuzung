using System;

namespace traffic_control
{
    class Program
    {
        static Intersection intersection;
        static Car rightCar;
        static Car leftCar;
        static Car topCar;
        static Car bottomCar;

        static void Main(string[] args)
        {
            intersection = new Intersection();

            rightCar = new Car
            {
                Direction = Direction.Right
            };

            leftCar = new Car
            {
                Direction = Direction.Straight
            };

            topCar = new Car
            {
                Direction = Direction.Right
            };

            bottomCar = new Car
            {
                Direction = Direction.Left
            };

            intersection.RightCar = rightCar;
            intersection.LeftCar = leftCar;
            intersection.TopCar = topCar;
            intersection.BottomCar = bottomCar;

            while (true)
            {
                switch (Console.ReadLine()) {
                    case "top":
                        Console.WriteLine(may_drive(topCar));
                        break;
                    case "right":
                        Console.WriteLine(may_drive(rightCar));
                        break;
                    case "bottom":
                        Console.WriteLine(may_drive(bottomCar));
                        break;
                    case "left":
                        Console.WriteLine(may_drive(leftCar));
                        break;
                    default:
                        break;
                }
            }
        }

        private static Boolean may_drive(Car car) {
            return checkRight(car) && checkStraight(car);
        }

        private static Boolean checkRight(Car car)
        {
            Car comparisonCar = getRight(car);

            if ((comparisonCar.Direction == Direction.None) ||
               (car.Direction == Direction.Right && comparisonCar.Direction == Direction.Straight) ||
               (car.Direction == Direction.Right && comparisonCar.Direction == Direction.Right) ||
               (car.Direction == Direction.Left && comparisonCar.Direction == Direction.Right))
            {
                return true;
            }
            return false;
        
        }

        private static Boolean checkStraight(Car car)
        {
            Car comparisonCar = getStraight(car);

            if ((comparisonCar.Direction == Direction.None) ||
                (car.Direction == Direction.Straight && comparisonCar.Direction == Direction.Straight) ||
                (car.Direction == Direction.Straight && comparisonCar.Direction == Direction.Right) ||
                (car.Direction == Direction.Straight && comparisonCar.Direction == Direction.Left) ||
                (car.Direction == Direction.Right && comparisonCar.Direction == Direction.Straight) ||
                (car.Direction == Direction.Right && comparisonCar.Direction == Direction.Left) ||
                (car.Direction == Direction.Right && comparisonCar.Direction == Direction.Right) ||
                (car.Direction == Direction.Left && comparisonCar.Direction == Direction.Left))
            {
                return true;
            }
            return false;
        }

        private static Car getRight(Car car) {

            if (car == rightCar) { return topCar;  }
            else if (car == leftCar) { return bottomCar; }
            else if (car == topCar) { return leftCar;  }
            else if (car == bottomCar) { return rightCar; }
            else throw new Exception();
        }

        private static Car getStraight(Car car)
        {
            if (car == rightCar) { return leftCar; }
            else if (car == leftCar) { return rightCar; }
            else if (car == topCar) { return bottomCar; }
            else if (car == bottomCar) { return topCar; }
            else throw new Exception();
        }
    }
}
