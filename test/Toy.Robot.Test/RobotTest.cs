using Xunit;

namespace Toy.Robot.Test
{
    public class RobotTest
    {
        [Fact]
        public void Robot_InitializedButNotPlaced_CannotBeMoved()
        {
            var robot = new Robot();
            var result = robot.Move();
            Assert.False(result);
            Assert.Equal("Robot cannot move until it has been placed on the table.", robot.LastError);
        }


        [Fact]
        public void Robot_PlacedAndTurnedLeft_ReportsCorrectPosition()
        {
            var robot = new Robot();
            robot.Place(1, 1, Facing.NORTH);
            robot.Left();
            Assert.Equal("1,1,WEST", robot.Report());
        }

        [Fact]
        public void Robot_PlacedAndTurnedRight_ReportsCorrectPosition()
        {
            var robot = new Robot();
            robot.Place(1, 1, Facing.NORTH);
            robot.Right();
            Assert.Equal("1,1,EAST", robot.Report());
        }

        [Fact]
        public void Robot_PlacedAndMoved_ReportsCorrectPosition()
        {
            var robot = new Robot();
            robot.Place(1, 1, Facing.NORTH);
            robot.Move();
            Assert.Equal("1,2,NORTH", robot.Report());
        }

        [Fact]
        public void Robot_PlacedMovedAndTurned_ReportsCorrectPosition()
        {
            var robot = new Robot();
            robot.Place(1, 2, Facing.EAST);
            robot.Move();
            robot.Move();
            robot.Left();
            robot.Move();
            Assert.Equal("3,3,NORTH", robot.Report());
        }
    }
}