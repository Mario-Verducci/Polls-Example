using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class Comment
{
    public int CommentId { get; set; }
    
    public int PollId { get; set; }
    public Poll Poll { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
    
    [Required]
    public string Text { get; set; }

    public DateTime CommentDate { get; set; } = DateTime.Now;
}