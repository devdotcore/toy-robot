using System;

namespace Toy.Robot
{
    /// <summary>
    /// Contains the definition for all the valid robot moves
    /// </summary>
    public class Instructions
    {

        public Robot _robot { get; set; }

        public Instructions(Robot robot)
        {
            this._robot = robot;
        }

        public string Execute(string command)
        {
            string response = "";
            InstructionArguments args = null;
            var instruction = GetInstruction(command, ref args);

            switch (instruction)
            {
                case Instruction.PLACE:
                    var placeArgs = (PlaceInstructionArguments)args;
                    if (_robot.Place(placeArgs.X, placeArgs.Y, placeArgs.Facing))
                        response = "Success";
                    else
                        response = _robot.LastError;
                    break;
                case Instruction.MOVE:
                    if (_robot.Move())
                        response = "Done.";
                    else
                        response = _robot.LastError;
                    break;
                case Instruction.LEFT:
                    if (_robot.Left())
                        response = "Done.";
                    else
                        response = _robot.LastError;
                    break;
                case Instruction.RIGHT:
                    if (_robot.Right())
                        response = "Done.";
                    else
                        response = _robot.LastError;
                    break;
                case Instruction.REPORT:
                    response = _robot.Report();
                    break;
                default:
                    response = "Invalid command.";
                    break;
            }
            return response;
        }

        private Instruction GetInstruction(string command, ref InstructionArguments args)
        {
            Instruction result;
            string argString = "";

            int argsSeperatorPosition = command.IndexOf(" ");
            if (argsSeperatorPosition > 0)
            {
                argString = command.Substring(argsSeperatorPosition + 1);
                command = command.Substring(0, argsSeperatorPosition);
            }
            command = command.ToUpper();

            if (Enum.TryParse<Instruction>(command, true, out result))
            {
                if (result == Instruction.PLACE)
                {
                    if (!TryParsePlaceArgs(argString, ref args))
                    {
                        result = Instruction.INVALID;
                    }
                }
            }
            else
            {
                result = Instruction.INVALID;
            }
            return result;
        }

        private bool TryParsePlaceArgs(string argString, ref InstructionArguments args)
        {
            var argParts = argString.Split(',');
            int x, y;
            Facing facing;

            if (argParts.Length == 3 &&
                TryGetCoordinate(argParts[0], out x) &&
                TryGetCoordinate(argParts[1], out y) &&
                TryGetFacingDirection(argParts[2], out facing))
            {
                args = new PlaceInstructionArguments
                {
                    X = x,
                    Y = y,
                    Facing = facing,
                };
                return true;
            }
            return false;
        }

        private bool TryGetCoordinate(string coordinate, out int coordinateValue)
        {
            return int.TryParse(coordinate, out coordinateValue);
        }

        private bool TryGetFacingDirection(string direction, out Facing facing)
        {
            return Enum.TryParse<Facing>(direction, true, out facing);
        }
    }
}