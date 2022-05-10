using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class Answer
{
    public int AnswerId { get; set; }
    public int PollId { get; set; }
    public Poll Poll { get; internal set; }

    [Required]
    public string AnswerText { get; set; }
}
