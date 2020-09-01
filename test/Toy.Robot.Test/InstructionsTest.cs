using Xunit;

namespace Toy.Robot.Test
{
    public class InstructionsTest
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
        public void Robot_PlacedOffTable_CannotBePlaced()
        {
            var robot = new Robot();
            var result = robot.Place(-1, 0, Facing.NORTH);
            Assert.False(result);
            Assert.Equal("Robot cannot be placed outside the table", robot.LastError);

            result = robot.Place(0, 6, Facing.NORTH);
            Assert.False(result);
            Assert.Equal("Robot cannot be placed outside the table", robot.LastError);
        }

        [Fact]
        public void Robot_Placed_CanReportItsPosition()
        {
            var robot = new Robot();
            var result = robot.Place(3, 2, Facing.EAST);
            var position = robot.Report();
            Assert.True(result);
            Assert.Equal("", robot.LastError);
            Assert.Equal("3,2,EAST", position);
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