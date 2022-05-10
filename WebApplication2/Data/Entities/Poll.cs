namespace WebApplication2.Data.Entities;

public class Poll
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Question { get; set; }
    public List<Answer> Answers { get; set; } = new List<Answer>();
    public List<Vote> Votes { get; set; } = new List<Vote>();
}