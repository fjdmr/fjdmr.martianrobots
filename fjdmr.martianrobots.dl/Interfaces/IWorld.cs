using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace fjdmr.martianrobots.dl
{
    public interface IWorld
    {
        void Generate(int dimx, int dimy);
        bool CheckRobotScent(Vector2 prevPosition, string instruction);
        bool IsInBoundaries(Vector2 position);
        void RegisterScent(IRobot robot);
    }
}
