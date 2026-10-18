using AutoMapper;
using URBS.Dtos;
using URBS.Models;

namespace URBS.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<RegisterDto, User>();
            CreateMap<User, DriverDto>();
        }
    }
}
