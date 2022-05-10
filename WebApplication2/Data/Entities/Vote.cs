namespace WebApplication2.Data.Entities;

public class Vote
{
    public string Id { get; set; }
    public int UserId { get; set; }
    public int PollId { get; set; }
    public int AnswerId { get; set; }
    public Poll Poll { get; internal set; }
}
