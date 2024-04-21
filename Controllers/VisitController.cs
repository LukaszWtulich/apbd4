using Microsoft.AspNetCore.Mvc;
using WebApplication1.Modules;

namespace WebApplication1.Controllers;

[Route("api/visits")]
[ApiController]
public class VisitController:ControllerBase
{
    private static readonly List<Visit> _visits = new()
    {
        //new Visit{animal=new Animal{id=1,imie="a",masa=2,siersc="b",typ="c"},Description="aaaaaa",Id=1,Price=12,VisitDate = Convert.ToDateTime("12/12/2001 12:12:12")}
    };
    [HttpGet("{id:int}")]
    public IActionResult GetVisit(int id)
    {
        var visit_list = _visits.FindAll(v => v.animal.id == id);//_visits.FirstOrDefault(v => v.animal.id == animal_id);
        if (visit_list.Count==0)
        {
            return NotFound($"Visit with animal of id {id} was not found");
        }
        
        return Ok(visit_list);
    }
    [HttpPost]
    public IActionResult CreateVisit(Visit visit)
    {
        _visits.Add(visit);
        return StatusCode(StatusCodes.Status201Created);
    }
}