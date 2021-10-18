using fjdmr.martianrobots.dl.Interfaces;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace fjdmr.martianrobots.dl.Domain
{
    public class Robot: IRobot
    {
        private int x;
        private int y;
        private int oldx;
        private int oldy;
        private int dirx;
        private int diry;
        private bool isLost;
        private string lastInstruction;

        public Robot()
        {
            
        }

        public void ExecuteInstruction(string instruction)
        {
            lastInstruction = instruction;
            this.oldx = this.x;
            this.oldy = this.y;
            var instructionMethod = typeof(IRobotInstructions).GetMethod(instruction.ToString());
            instructionMethod.Invoke(this, null);
        }

        public Vector2 GetPosition()
        {
            return new Vector2(this.x, this.y);
        }

        public Vector2 GetPreviousPosition()
        {
            return new Vector2(this.oldx, this.oldy);
        }

        public void F()
        {
            this.x = this.dirx + this.x;
            this.y = this.diry + this.y;
        }

        public void L()
        {
            int temp = this.dirx;
            this.dirx = -this.diry;
            this.diry = temp;
        }

        public void R()
        {
            int temp = this.dirx;
            this.dirx = this.diry;
            this.diry = -temp;
        }

        public void SetAsLost()
        {
            isLost = true;
        }

        public bool IsLost()
        {
            return isLost;
        }

        public string GetLastInstruction()
        {
            return lastInstruction;
        }

        public void Deploy(int x, int y, int dirx, int diry)
        {
            if (!(Math.Abs(dirx - diry) == 1 && dirx * diry == 0))
                throw new ArgumentException("dirx and diry must be one of the following combinations (1,0), (-1,0), (0,1), (0,-1)");


            this.dirx = dirx;
            this.diry = diry;
            this.x = x;
            this.y = y;
            oldx = 0;
            oldy = 0;
            isLost = false;
        }

        public Vector2 GetDirection()
        {
            return new Vector2(dirx, diry);
        }
    }
}
