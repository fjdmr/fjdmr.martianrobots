using fjdmr.martianrobots.dl.Dto;
using System.Collections.Generic;

namespace fjdmr.martianrobots.dl.Services
{
    public interface IRobotService
    {
        List<string> ProcessRobotWorld(int worldX, int worldY, List<RobotParametersDto> robots);
    }
}