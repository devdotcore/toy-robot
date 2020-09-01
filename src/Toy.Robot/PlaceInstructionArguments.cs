namespace Toy.Robot
{
    public class PlaceInstructionArguments : InstructionArguments
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Facing Facing { get; set; }
    }
}