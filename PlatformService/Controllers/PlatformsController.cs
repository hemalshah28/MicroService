using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data.Repository;
using PlatformService.Dtos;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController: ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlateformReadDto>> GetPlatfomrs()
        {
            const string message = "Getting PlatformServices";
            Console.WriteLine(message);

            var platformItems = _repository.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlateformReadDto>>(platformItems));
        }
        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlateformReadDto> GetPlatformById(int id)
        {
            var platformItem = _repository.GetPlatformById(id);
            if (platformItem != null)
            {
                return Ok(_mapper.Map<PlateformReadDto>(platformItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<PlateformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            var platformModel = _mapper.Map<Models.Platform>(platformCreateDto);
            _repository.CreatePlatform(platformModel);
            _repository.SaveChanges();
            var platformReadDto = _mapper.Map<PlateformReadDto>(platformModel);
            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDto.Id }, platformReadDto);
        }
    }
}
