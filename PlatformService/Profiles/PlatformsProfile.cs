using AutoMapper;

namespace PlatformService.Profiles
{
    public class PlatformsProfile:Profile
    {
        public PlatformsProfile()
        {
            // Source -> Target
            CreateMap<Models.Platform, Dtos.PlateformReadDto>();
            CreateMap<Dtos.PlatformCreateDto, Models.Platform>();
        }

    }
}
