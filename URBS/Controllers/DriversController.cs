using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using URBS.Dtos;
using URBS.Unit_O__Work;

namespace URBS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public DriversController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetDrivers()
        {
            var users = await unitOfWork.Users.GetAll();
            var drivers = users.Where(u => u.Role == "Driver").ToList();
            if(drivers == null|| drivers.Count == 0)
            {
                return NotFound();
            }
            var dto = mapper.Map<List<DriverDto>>(drivers);
            return Ok(dto);
        }
    }
}
