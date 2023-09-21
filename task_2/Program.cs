using System.IO;

public sealed class Movie
{
    private readonly string title;
    private readonly int duration;

    public Movie(string title, int duration)
    {
        this.title = title;
        this.duration = duration;
    }
    public string Title
    {
        get { return title; }
    }

    public Movie changeTitle(string newTitle)
    {
        return new Movie(newTitle, duration);
    }
    public int Duration
    {
        get { return duration; }
    }
    public Movie changeDuration(int newDuration)
    {
        return new Movie(title, newDuration);
    }


}

class Program
{
    static void Main(string[] args)
    {
        Movie fstVideo = new Movie("fst", 23);
        Console.WriteLine(fstVideo.Title);
        Movie copy = fstVideo.changeTitle("copy");
        Console.WriteLine(copy.Title);
        Console.WriteLine(copy.Duration);
    

    }

}
