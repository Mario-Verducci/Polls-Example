namespace Data.Entities;

public class Vote
{
    public int VoteId { get; set; }

    public int PollId { get; set; }
    public Poll Poll { get; internal set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int AnswerId { get; set; }
    public Answer Answer { get; set; }

    public DateTime VoteDate { get; set; } = DateTime.Now;
}
