namespace traffic_control
{
    public class Car
    {
        private Direction direction;
        public Direction Direction { get => direction; set => direction = value; }
    }

    public enum Direction
    {
        Straight,
        Right,
        Left,
        None,
    }
}
