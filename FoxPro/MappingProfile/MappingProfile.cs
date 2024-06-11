using AutoMapper;
using FoxPro.DTOs;
using FoxPro.Models;

namespace FoxPro.MappingProfile;

public class MappingProfile : Profile
{
    public MappingProfile() {
        CreateMap<Models.Task,TaskDto>();
        CreateMap<TaskDto,Models.Task>();
    }
}
