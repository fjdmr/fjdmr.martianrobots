using fjdmr.martianrobots.dl.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace fjdmr.martianrobots.dl.Domain
{
    public class RobotOperator : IRobotOperator
    {
        private readonly IWorld world;

        public RobotOperator(IWorld world)
        {
            this.world = world;
        }

        public void ExecuteInstruction(IRobot robot, string instruction)
        {
            //Get robot current position
            var prevPosition = robot.GetPosition();
            //Check 'scent'
            if (!world.CheckRobotScent(prevPosition, instruction))
            {
                return;
            }

            //Execute instruction
            robot.ExecuteInstruction(instruction);

            //Check robot position
            var newPosition = robot.GetPosition();

            //Set as lost if out of boundaries
            if (!world.IsInBoundaries(newPosition))
            {
                robot.SetAsLost();
            }

        }
    }
}
