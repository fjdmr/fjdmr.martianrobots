using AutoMapper;
using fjdmr.martianrobots.dl.Dto;
using fjdmr.martianrobots.dl.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fjdmr.martianrobots.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MartianRobotsController : ControllerBase
    {
        private readonly ILogger<MartianRobotsController> _logger;
        private readonly IRobotService _robotService;
        private readonly IMapper _mapper;

        public MartianRobotsController(ILogger<MartianRobotsController> logger, IRobotService robotService, IMapper mapper)
        {
            _logger = logger;
            _robotService = robotService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<IEnumerable<string>> Process(WorldParameters worldParameters)
        {
            return _robotService.ProcessRobotWorld(worldParameters.WorldX, worldParameters.WorldY, _mapper.Map<List<RobotParametersDto>>(worldParameters.Robots));
        }
    }
}
