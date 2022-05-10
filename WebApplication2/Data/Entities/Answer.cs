namespace WebApplication2.Data.Entities;

public class Answer
{
    public int Id { get; set; }
    public int PollId { get; set; }
    public string AnswerText { get; set; }
    public Poll Poll { get; internal set; }
}
