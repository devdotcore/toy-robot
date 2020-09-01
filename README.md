
## Toy Robot

A toy robot on a table top, a grid of 5 x 5 units, there are no obstructions. You can issue commands to your robot allowing it to roam around the table top.

### COMMANDS
The following commands are valid when you run the console application.

* PLACE X,Y,FACING
* MOVE
* LEFT
* RIGHT
* REPORT

### Setup
The following steps are for running the codebase locally on a Mac using Visual Studio Code, you find similar or better options online.


1. Download and install [.Net Core v5.0.0-preview.7](https://dotnet.microsoft.com/download/dotnet/5.0) SDK on your machine.
2. Download this repo into a working directory and take latest from master branch
```markdown
git clone https://github.com/devdotcore/toy-robot.git
```
3. Open the project in [VS Code](https://code.visualstudio.com/) and build -
```markdown
dotnet build
```
4. Make sure all the test case are running -
```markdown
dotnet test
```
5. Start the project directly on VS Code or run the following command -
```markdown
dotnet run --project ./src/Toy.Robot/Toy.Robot.csproj
```
5. You can then enter the command as listed [above](#COMMANDS).
