using fjdmr.martianrobots.dl.Domain;
using fjdmr.martianrobots.dl.Dto;
using fjdmr.martianrobots.dl.Interfaces;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace fjdmr.martianrobots.dl.Services
{
    public class RobotService : IRobotService
    {
        private readonly IWorld world;
        private readonly IRobotOperator robotOperator;

        public RobotService(IWorld world, IRobotOperator robotOperator)
        {
            this.world = world;
            this.robotOperator = robotOperator;
        }

        public List<string> ProcessRobotWorld(int worldX, int worldY, List<RobotParametersDto> robots)
        {
            List<string> result = new List<string>();
            world.Generate(worldX, worldY);
            foreach (var robotDeploy in robots)
            {
                int x = robotDeploy.X;
                int y = robotDeploy.Y;

                Vector2 direction = GetDirectionVector(robotDeploy.Direction);
                int dirX = (int)direction.X;
                int dirY = (int)direction.Y;

                IRobot robot = new Robot();
                robot.Deploy(x, y, dirX, dirY);

                foreach (var instruction in robotDeploy.Instructions)
                {
                    robotOperator.ExecuteInstruction(robot, instruction.ToString());
                }
                Vector2 resultPos;
                Vector2 resultDir;
                string lostStr = string.Empty;
                if (robot.IsLost())
                {
                    resultPos = robot.GetPreviousPosition();
                    resultDir = robot.GetDirection();
                    lostStr = "LOST";
                }
                else
                {
                    resultPos = robot.GetPosition();
                    resultDir = robot.GetDirection();
                }
                result.Add($"{resultPos.X} {resultPos.Y} {GetDirectionString(resultDir)} {lostStr}");
            }
            return result;
        }

        private static string GetDirectionString(Vector2 vector)
        {
            if (vector.X + vector.Y > 0)
            {
                // (1, 0) E
                if (vector.X > 0)
                {
                    return "E";
                }
                // (0, 1) N
                else
                {
                    return "N";
                }
            }
            else
            {
                // (-1, 0) W
                if (vector.X < 0)
                {
                    return "W";
                }
                // (0, -1) S
                else
                {
                    return "S";
                }
            }
        }

        private static Vector2 GetDirectionVector(string direction)
        {
            switch (direction)
            {
                case "N":
                    return new Vector2(0, 1);
                case "S":
                    return new Vector2(0, -1);
                case "E":
                    return new Vector2(1, 0);
                case "W":
                    return new Vector2(-1, 0);
                default:
                    throw new ArgumentException("Invalid argument must be one of the following (N,S,E,W)");
            }
        }
    }
}
