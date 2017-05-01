using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// static class to hold all npc objects
    /// </summary>
    public static partial class KingdomObjects
    {
        public static List<Npc> Npcs = new List<Npc>()
        {
            new Civilian
            {
                Id = 1,
                Name = "Mysterious Stranger",
                MapLocationID = 1,
                Description = "An old man wearing robes. He keeps his face mostly concealed",
                Messages = new List<string>
                {
                    "You are the one.",
                    "Find all of the gems to restore the crown."
                }
            },

            new Civilian
            {
                Id = 7,
                Name = "Smaug",
                MapLocationID = 7,
                Description = "An large, menacing serpent that breathes fire. His scales are brown and his eyes seem to pierce your very soul.",
                Messages = new List<string>
                {
                    "I am fire! I am...death!",
                    "RRRAAAAAAAGH!"
                }
            },

            new Civilian
            {
                Id = 3,
                Name = "Black Knight",
                MapLocationID = 9,
                Description = "An imposing man dressed in black armor and tabard, wielding a two-handed sword.",
                Messages = new List<string>
                {
                    "Tis but a scratch.",
                    "I've had worse.", 
                    "Have at you!",
                    "None shall pass!"
                }
            },

            new Civilian
            {
                Id = 2,
                Name = "King Arthur",
                MapLocationID = 5,
                Description = "A brave man, leader of the humans. He wears a crown and royal armor.",
                Messages = new List<string>
                {
                    "I am Arthur, King of the Britons.",
                    "Bring me the Holy Grail."
                }
            },

            new Civilian
            {
                Id = 4,
                Name = "Princess Ruto",
                MapLocationID = 2,
                Description = "A young Xoran. Her father leads the xoran people.",
                Messages = new List<string>
                {
                    "Hi, I'm Princess Ruto.",
                    "Please retrieve our precious stone from the temple.",
                    "Be carefull."
                }
            },

            new Civilian
            {
                Id = 5,
                Name = "Morpha",
                MapLocationID = 6,
                Description = "A strange gelatinous monster with a single eye that moves throughout its body."
            }
        };
    }
}
