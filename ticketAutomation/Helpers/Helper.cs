using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticketAutomation.Models;

namespace ticketAutomation.Helpers
{
    public class Helper
    {
        public static List<Movie> CreateMovies()
        {
            string basePath = "C:/Users/Asus/Desktop/udemy/udemy_cs/Cinema Ticket Automation/ticketAutomation/ticketAutomation/Pictures/";
            return new List<Movie>()
            {
                new Movie()
                {
                    movieName = "The Notebook",
                    category = Enums.Category.drama,
                    minute = "2 hours 15 minutes",
                    price =40,
                    picturePath = basePath + "theNotebook.jpg"
                },
                new Movie()
                {
                    movieName = "Big Lebowski",
                    category = Enums.Category.comedy,
                    minute = "2 hours 16 minutes",
                    price =40,
                    picturePath = basePath + "bigLebowski.jpg"
                },
                new Movie()
                {
                    movieName = "Star Wars",
                    category = Enums.Category.scienceFiction,
                    minute = "2 hours",
                    price =40,
                    picturePath = basePath + "starWars.jpg"
                },
                 new Movie()
                {
                    movieName = "Gone Girl",
                    category = Enums.Category.thriller,
                    minute = "2 hours",
                    price =40,
                    picturePath = basePath + "goneGirl.jpg"
                },
                  new Movie()
                {
                    movieName = "Into the Wild",
                    category = Enums.Category.adventure,
                    minute = "2 hours",
                    price =40,
                    picturePath = basePath + "intoTheWild.jpg"
                },
                    new Movie()
                {
                    movieName = "Mulholland Drive",
                    category = Enums.Category.mystery,
                    minute = "2 hours",
                    price =40,
                    picturePath = basePath + "mulhollandDrive.jpg"
                },
            };
        }
    }
}
