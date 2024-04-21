namespace WebApplication1.Modules;

public class Visit
{
    public int Id { get; set; }
    public DateTime VisitDate { get; set; }
    public string Description { get; set; }
    public Animal animal { get; set; }
    public double Price { get; set; }
}