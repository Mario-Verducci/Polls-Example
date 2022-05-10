namespace Data.Entities;

public class Poll
{
    public int PollId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string Question { get; set; }
 
    public List<Answer> Answers { get; set; } = new List<Answer>();
    public List<Comment> Comments { get; set; } = new List<Comment>();
    public List<Vote> Votes { get; set; } = new List<Vote>();
}