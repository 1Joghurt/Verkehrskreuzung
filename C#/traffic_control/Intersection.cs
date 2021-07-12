namespace traffic_control
{
    public class Intersection
    {
        private Car rightCar;
        private Car leftCar;
        private Car topCar;
        private Car bottomCar;

        public Car RightCar { get => rightCar; set => rightCar = value; }
        public Car LeftCar { get => leftCar; set => leftCar = value; }
        public Car TopCar { get => topCar; set => topCar = value; }
        public Car BottomCar { get => bottomCar; set => bottomCar = value; }
    }
}
