namespace DishesAPI.Profiles;
using AutoMapper;
using DishesAPI.Entities;
using DishesAPI.Models;

public class DishProfile : Profile
{
    public DishProfile()
    {
        CreateMap<Dish, DishDto>();
        CreateMap<DishForCreationDto, Dish>();
        CreateMap<DishForUpdateDto, Dish>();
    }
}