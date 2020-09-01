using System;

namespace Toy.Robot
{
    /// <summary>
    /// Contains all the valid Robot moves
    /// </summary>
    public class Robot
    {
        private const int _tableSize = 5;
        private int? _x;
        private int? _y;
        private Facing _facing;
        public string LastError { get; set; }

        public Robot()
        {
            LastError = "";
        }

        public bool Place(int x, int y, Facing facing)
        {            
            if (IsWithinTableRange(x, y, "be placed"))
            {
                _x = x;
                _y = y;
                _facing = facing;
                return true;
            }
            return false;
        }

        public bool Move()
        { 
            if (IsPlaced("move"))
            {
                int newX = GetXAfterMove();
                int newY = GetYAfterMove();
                if (IsWithinTableRange(newX, newY, "be moved"))
                {
                    _x = newX;
                    _y = newY;
                    return true;
                }                
            }
            return false;
        }

        private int GetXAfterMove()
        {
            if (_facing == Facing.EAST)
            {
                return _x.Value + 1;
            }
            else 
            {
                if (_facing == Facing.WEST) 
                {
                    return _x.Value - 1;
                }
            }
            return _x.Value;
        }

        private int GetYAfterMove()
        {
            if (_facing == Facing.NORTH)
            {
                return _y.Value + 1;
            }
            else
            {
                if (_facing == Facing.SOUTH)
                {
                    return _y.Value - 1;
                }
            }
            return _y.Value;
        }

        public bool Left()
        {
            return Turn(Direction.Left);
        }

        public bool Right()
        {
            return Turn(Direction.Right);
        }

        private bool Turn(Direction direction)
        {
            if (IsPlaced("turn"))
            {
                var facingAsNumber = (int)_facing;
                facingAsNumber += 1 * (direction == Direction.Right ? 1 : -1);
                if (facingAsNumber == 5) facingAsNumber = 1;
                if (facingAsNumber == 0) facingAsNumber = 4;
                _facing = (Facing)facingAsNumber;
                return true;
            }
            return false;
        }

        public string Report()
        {
            if (IsPlaced("report it's position"))
            {
                return String.Format("{0},{1},{2}", _x.Value, _y.Value, _facing.ToString().ToUpper());
            }
            return "";
        }

        private bool IsPlaced(string action)
        {
            if (!_x.HasValue || !_y.HasValue)
            {
                LastError = String.Format("Robot cannot {0} until it has been placed on the table.", action);
                return false;
            }
            return true;
        }

        private bool IsWithinTableRange(int x, int y, string action)
        {
            if (x < 0 || y < 0 || x >= _tableSize || y >= _tableSize)
            {
                LastError = String.Format("Robot cannot {0} outside the table", action);
                return false;
            }
            return true;
        }
    }
}