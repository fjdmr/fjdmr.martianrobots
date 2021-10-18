using System;
using System.Collections.Generic;

namespace fjdmr.martianrobots.api
{
    public class WorldParameters
    {
        public int WorldX { get; set; }
        public int WorldY { get; set; }
        public List<RobotParameters> Robots { get; set; }
    }

    public class RobotParameters
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Direction { get; set; }
        public string Instructions { get; set; }
    }
}
