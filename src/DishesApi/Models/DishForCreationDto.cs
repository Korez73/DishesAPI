namespace DishesAPI.Models;
using System.ComponentModel.DataAnnotations;

public class DishForCreationDto
{
    [Required, StringLength(100, MinimumLength = 3)]
    public required string Name {get; set;}

}