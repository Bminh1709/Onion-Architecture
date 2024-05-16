﻿using AutoMapper;
using Entities.Models;
using static Shared.DataTransferObjects;

namespace WebApp;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyDto>()
            .ForCtorParam("FullAddress",
            opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
    }
}