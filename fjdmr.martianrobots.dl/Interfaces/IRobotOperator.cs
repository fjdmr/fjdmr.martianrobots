using System;
using System.Collections.Generic;
using System.Text;

namespace fjdmr.martianrobots.dl.Interfaces
{
    public interface IRobotOperator
    {

        void ExecuteInstruction(IRobot robot, string instruction);
    }
}
