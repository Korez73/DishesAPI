namespace DishesAPI.Profiles;
using AutoMapper;
using DishesAPI.Entities;
using DishesAPI.Models;

public class IngredientProfile : Profile
{
    public IngredientProfile()
    {
        CreateMap<Ingredient, IngredientDto>()
            .ForMember(
                d => d.DishId,
                o => o.MapFrom(s => s.Dishes.First().Id)
            );
    }

}
