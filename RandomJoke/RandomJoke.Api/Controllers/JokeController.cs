using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RandomJoke.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokeController : ControllerBase
    {
        [HttpGet]
        public Joke Get()
        {
            Random random = new Random();
            int toSkip=random.Next(0,10);
            Joke joke = Repository()
                .Skip(toSkip)
                .Take(1)
                .FirstOrDefault();

            return joke;
        }


        public List<Joke> Repository()
        {
            List<Joke> jokeList = new List<Joke> {
                new Joke {Name = "RATTLE SNAKE", Text = "Two men are hiking through the woods when one of them cries out, “Snake! Run!” His companion laughs at him. “Oh, relax. It’s only a baby,” he says. “Don’t you!", Category="Animal" },
                new Joke {Name = "HORSE RIDER", Text = "To be or not to be a horse rider, that is equestrian. —Mark Simmons, comedian", Category="Animal" },
                new Joke {Name = "POSTURE CAT", Text = "What did the grandma cat say to her grandson when she saw him slouching? A: You need to pay more attention to my pawsture.", Category="Animal" },
                new Joke {Name = "HE CAN DO IT HIMSELF", Text = "It was my first night caring for an elderly patient. When he grew sleepy, I wheeled his chair as close to the bed as possible and, using the techniques I’d...", Category="Dockor" },
                new Joke {Name = "ON THE BADGE", Text = "My 85-year-old grandfather was rushed to the hospital with a possible concussion. The doctor asked him a series of questions: “Do you know where you are?” “I’m at Rex Hospital.”...", Category="Dockor" },
                new Joke {Name = "THE NURSE HAS MY TEETH", Text = "As a brain wave technologist, I often ask postoperative patients to smile to make sure their facial nerves are intact. It always struck me as odd to be asking this...", Category="Dockor" },
                new Joke {Name = "GLUTEN ATTACK", Text = "Guy staring at an ambulance in front of Whole Foods: “Somebody must have accidentally eaten gluten.”", Category="Food" },
                new Joke {Name = "MORNING TEA", Text = "What has T in the beginning, T in the middle, and T at the end? A: A teapot.", Category="Food" },
                new Joke {Name = "MAKE ME A SANDWICH", Text = "My husband and I were daydreaming about what we would do if we won the lottery. I started: “I’d hire a cook so that I could just say, ‘Hey, make...", Category="Marriage" },
                new Joke {Name = "SELL IT", Text = "As my wife and I prepared for our garage sale, I came across a painting. Looking at the back, I discovered that I had written “To my beautiful wife on...", Category="Marriage" }
                };

            return jokeList;
        }
    }
}
