using Microsoft.AspNetCore.Mvc;
using WebApplication1.Modules;

namespace WebApplication1.Controllers;
[Route("api/animals")]
[ApiController]
public class AnimalsControler:ControllerBase
{
    private static readonly List<Animal> _animals = new()
    {
        new Animal { id=1,imie="bob",masa = 12.0,siersc="czarna",typ="pies" },
        new Animal { id=2,imie="gob",masa = 10.0,siersc="czarna",typ="kot" }
    };
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animals);
    }
    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = _animals.FirstOrDefault(an => an.id == id);
        if (animal == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }
        
        return Ok(animal);
    }
    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        _animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var animalToEdit= _animals.FirstOrDefault(s => s.id == id);

        if (animalToEdit == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }
        
        _animals.Remove(animalToEdit);
        _animals.Add(animal);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animalToEdit = _animals.FirstOrDefault(s => s.id == id);
        if (animalToEdit == null)
        {
            return NoContent();
        }

        _animals.Remove(animalToEdit);
        return NoContent();
    }
}