using System;

class Program
{

    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Length { get; set; }
        public List<Comment> Comments { get; set; }

        public int GetNumberOfComments()
        {
            return Comments.Count;
        }
    }

    public class Comment
    {
        public string Name { get; set; }
        public string Text { get; set; }
    }


    
    static void Main(string[] args)
    {
        var videos = new List<Video>();

        var video1 = new Video
        {
            Title = "Cats rolling",
            Author = "Cat001",
            Length = 60,
            Comments = new List<Comment>
            {
                new Comment { Name = "juan495", Text = "Nice video" },
                new Comment { Name = "Dracula-man", Text = "Love this cats" },
                new Comment { Name = "Cat lover", Text = "They look so cute" }
            }
        };

        var video2 = new Video
        {
            Title = "invencible",
            Author = "Marvel-comics",
            Length = 120,
            Comments = new List<Comment>
            {
                new Comment { Name = "diegofernandez69", Text = "El chapulin colorado!!!" },
                new Comment { Name = "link.series", Text = "Insteresting chapter" }
            }
        };

        var video3 = new Video
        {
            Title = "Unknown-places",
            Author = "Unknown",
            Length = 180,
            Comments = new List<Comment>
        {
            new Comment { Name = "Gonk", Text = "listen to this amazing video" },
            new Comment { Name = "galapagus99", Text = "The world is bigger than the hate you got" },
            new Comment { Name = "watchman555", Text = "There is kindness and purpose" },
            new Comment { Name = "beingyourself", Text = "35 years old... Seeing more and more" }
        }
        };

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (var video in videos)
        {
            Console.WriteLine("");
            
            Console.WriteLine("Title: {0}", video.Title);
            Console.WriteLine("Author: {0}", video.Author);
            Console.WriteLine("Length: {0} seconds", video.Length);
            Console.WriteLine("Number of comments: {0}", video.GetNumberOfComments());

            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine("{0}: {1}", comment.Name, comment.Text);
            }

            Console.WriteLine("");
        }

    }

    
}

