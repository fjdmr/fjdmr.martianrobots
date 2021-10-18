using Autofac;
using fjdmr.martianrobots.dl;
using fjdmr.martianrobots.dl.Domain;
using fjdmr.martianrobots.dl.Dto;
using fjdmr.martianrobots.dl.Interfaces;
using fjdmr.martianrobots.dl.Services;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace fjdmr.martianrobots.cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = BuildContainer();
            
            // Data insertion
            // World
            Console.WriteLine("Insert the world size separate by whitespaces: 5 3 ");
            string worldSize = Console.ReadLine().Trim();
            string[] worldSizes = worldSize.Split(" ");
            int worldX = int.Parse(worldSizes[0].Trim());
            int worldY = int.Parse(worldSizes[1].Trim());

            // Robots
            List<RobotParametersDto> robotDeploys = new List<RobotParametersDto>();
            Console.WriteLine("Insert number of robots: 3");
            int numberOfRobots = int.Parse(Console.ReadLine().Trim());
            for (int i = 0; i < numberOfRobots; i++)
            {
                Console.WriteLine("Insert the robot deploy coordinates and direction separated by whitespaces: 1 1 E");
                string robotPosition = Console.ReadLine().Trim();
                string[] robotPositions = robotPosition.Split(" ");
                int robotX = int.Parse(robotPositions[0].Trim());
                int robotY = int.Parse(robotPositions[1].Trim());
                string robotDirection = robotPositions[2].Trim();

                Console.WriteLine("Insert the instructions for the robot using the letters R F L: RFRL");
                robotDeploys.Add(new RobotParametersDto() { X = robotX, Y = robotY, Direction = robotDirection, Instructions = Console.ReadLine().Trim() });
            }

            // Data process
            IRobotService robotService = container.Resolve<IRobotService>();
            var result = robotService.ProcessRobotWorld(worldX, worldY, robotDeploys);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Robot>().As<IRobot>();
            builder.RegisterType<World>().As<IWorld>().SingleInstance();
            builder.RegisterType<RobotOperator>().As<IRobotOperator>();
            builder.RegisterType<RobotService>().As<IRobotService>();

            return builder.Build();
        }
    }
}
