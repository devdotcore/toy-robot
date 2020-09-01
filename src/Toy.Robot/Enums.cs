namespace Toy.Robot
{
    public enum Instruction
    {
        INVALID = 0,
        PLACE = 1,
        MOVE = 2,
        LEFT = 3,
        RIGHT = 4,
        REPORT = 5
    }

    public enum Facing
    {
        NORTH = 1,
        EAST = 2,
        SOUTH = 3,
        WEST = 4
    }

    public enum Direction 
    {
        Left = 1,
        Right = -1,
    }
}