using fjdmr.martianrobots.dl.Interfaces;
using System;
using System.Numerics;

namespace fjdmr.martianrobots.dl
{
    public interface IRobot: IRobotInstructions
    {
        
        void ExecuteInstruction(string instructions);
        Vector2 GetPosition();
        Vector2 GetDirection();
        void SetAsLost();
        bool IsLost();
        Vector2 GetPreviousPosition();
        string GetLastInstruction();
        void Deploy(int x, int y, int dirx, int diry);
    }
}
