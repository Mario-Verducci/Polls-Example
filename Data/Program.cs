using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

PollContext context = new PollContext();
context.Database.EnsureDeleted();
context.Database.Migrate();

//Init Database with Sample-Data
/* ----------------------------------------------------------------------------------------------------------- */

context.Users.Add(new User { UserName = "John Doe", Email = "info@web.de", Country = "Germany", Password = "passwd", PostalCode = "12345" });
context.Users.Add(new User { UserName = "Phill Hund", Email = "info2@web.de", Country = "Germany", Password = "passwd", PostalCode = "12345" });

context.Polls.Add(new Poll
{
    Title = "Best Soccer Team",
    Question = "What is the best Soccer Team in Germany?",
    Description = "Sport Poll",
    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d3/Soccerball.svg/500px-Soccerball.svg.png",
    Answers = new List<Answer>
    {
        new Answer { AnswerText ="Bayern München" },
        new Answer { AnswerText ="Borissia Dortmund" },
        new Answer { AnswerText = "VFB Stuttgart" }
    }
});

context.Polls.Add(new Poll
{
    Title = "Hot or Not",
    Question = "Who is the most beautiful woman in Germany? ",
    Description = "Sex Poll",
    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d3/Soccerball.svg/500px-Soccerball.svg.png",
    Answers = new List<Answer>
    {
        new Answer { AnswerText ="Heidi Klum" },
        new Answer { AnswerText ="Sophia Thomalla" },
        new Answer { AnswerText ="Palina Rojinski" }
    }
});

context.SaveChanges();

context.Votes.Add(new Vote { AnswerId = 2, UserId = 1, PollId = 1 });
context.Votes.Add(new Vote { AnswerId = 5, UserId = 1, PollId = 2 });
context.Votes.Add(new Vote { AnswerId = 5, UserId = 2, PollId = 2 });

context.Comment.Add(new Comment { Text = "Good poll...", PollId = 1, UserId = 1 });
context.Comment.Add(new Comment { Text = "BOOOOORING!", PollId = 1, UserId = 2 });
context.Comment.Add(new Comment { Text = "Bitches, yeah!", PollId = 2, UserId = 1 });

context.SaveChanges();

/* ----------------------------------------------------------------------------------------------------------- */

List<Poll> dbPolls = context.Polls.Include(x => x.Votes).ToList();

foreach (var poll in dbPolls)
{
    var comments = poll.Comments.Count(x => x.PollId == poll.PollId);
    Console.Write($"{poll.Question} (comments : {comments})");
    
    var position = Console.GetCursorPosition();
    Console.SetCursorPosition(75, position.Top);
    Console.Write("Votes\r\n");

    Console.WriteLine("".PadLeft(80, '-'));

    for (int i = 0; i < poll.Answers.Count; i++)
    {
        var votes = poll.Votes.Count(x => x.AnswerId == poll.Answers[i].AnswerId);

        Console.Write($"{i + 1}. {poll.Answers[i].AnswerText}");
        position = Console.GetCursorPosition();

        Console.SetCursorPosition(75, position.Top);

        Console.ForegroundColor = votes>=0? ConsoleColor.Green : ConsoleColor.White;

        Console.Write($"( {votes} )");

        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine();
    }

    Console.WriteLine();
    Console.WriteLine("".PadLeft(80, '-'));
}

Console.WriteLine();