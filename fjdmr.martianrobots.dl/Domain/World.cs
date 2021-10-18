using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace fjdmr.martianrobots.dl.Domain
{
    public class World : IWorld
    {
        private List<IRobot> lostRobots;
        private int dimX;
        private int dimY;

        public World()
        {
            
        }

        public bool CheckRobotScent(Vector2 position, string instruction)
        {
            foreach (var lostRobot in lostRobots)
            {
                //TODO añadir direccion al check
                if (lostRobot.GetPreviousPosition().Equals(position) && instruction == lostRobot.GetLastInstruction())
                {
                    return false;
                }
            }
            return true;
        }

        public void Generate(int dimX, int dimY)
        {
            this.dimX = dimX;
            this.dimY = dimY;
            this.lostRobots = new List<IRobot>();
        }

        public bool IsInBoundaries(Vector2 position)
        {
            if (position.X >= 0 && position.Y >= 0 && position.X < dimX + 1 && position.Y < dimY + 1)
            {
                return true;
            }
            return false;
        }

        public void RegisterScent(IRobot robot)
        {
            lostRobots.Add(robot);
        }
    }
}
