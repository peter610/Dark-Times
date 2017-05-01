using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public static partial class KingdomObjects
    {
        public static List<MapLocation> MapLocations = new List<MapLocation>
        {
            new MapLocation
            {
                CommonName = "Mysterious Cottage",
                MapLocationID = 1,
                KingdomLocation = "No-Man's Land",
                Description = "This cottage is located in the heart of No-Man's " +
                    "Land hidden from sight among the dense foliage and large rocks. " +
                    "there's not but old, decrepit ruins and wildlife for miles in any " + 
                    "direction.",
                GeneralContents = "The cottage is a small structure of wood and stone, lit " +
                    "only by the fireplace at the back of the room. A few men and women of all races " +
                    "are gathered here.",
                Accessable = true,
                ExperiencePoints = 10
            },

            new MapLocation
            {
                CommonName = "Xoran Palace",
                MapLocationID = 2,
                KingdomLocation = "Hylian Ocean",
                Description = "The xoran palace is located quite a distance off the western coast  " +
                    "far beneath the surface of the water. The palace sits amidst a grand city " +
                    "of beautiful architecture known as Xoran Domain.",
                GeneralContents = "Coral and large shells provide structure for the walls which have been " +
                    "reinforced with stone. A thick sheet of glass overhead allows for sunlight to " +
                    "reach the city. Xorans move all about, there are only a few outsiders among them. ",
                Accessable = true,
                ExperiencePoints = 20
            },

            new MapLocation
            {
                CommonName = "Dwarven Palace",
                MapLocationID = 3,
                KingdomLocation = "Lonely Mountain",
                Description = "The dwarven palace sits deep within the Lonely Mountain far to the " +
                    "north. The treacherous path there is riddled with the remains of those who " +
                    "have lost their footing. ",
                GeneralContents = "The geometric corridors of the palace are carved into the mountain with " + 
                    "great attention to detail and adorned with jewels of all colors and sizes. " +
                    "Aside from a few guards placed at many of the enterances, the great halls seem abandoned. ",
                Accessable = false,
                ExperiencePoints = 20
            },

            new MapLocation
            {
                CommonName = "Dol Blathanna",
                MapLocationID = 4,
                KingdomLocation = "Lost Woods",
                Description = "The elven city is located within the dense forests to the east. Few have ventured into " +
                              "these forests and returned. Those that have cling to life threatened by poisons " +
                              "and toxins produced by the local flora.",
                GeneralContents = "The walls and structures of the city seem to be naturally grown from the trees surrounding " +
                            "it's residents. The towering elves move about continuously watching any outsiders, most out of " +
                            "caution, but some out of curiosity.",
                Accessable = true,
                ExperiencePoints = 20
            },

            new MapLocation
            {
                CommonName = "Camelot",
                MapLocationID = 5,
                KingdomLocation = "Southern Plains",
                Description = "Camelot is located in the vast plains to the south. The fields before it's walls " +
                              "are littered with arrows and the bodies of their intended targets. ",
                GeneralContents = "The imposing stone walls of the castle rise toward the sky. Inside, many of the residents " +
                            "look on with disgust at any non-humans granted entry often throwing stones or food scraps at those " +
                            "daring enough to look them in the eye.",
                Accessable = true,
                ExperiencePoints = 20
            },
            new MapLocation
            {
                CommonName = "Castle of Aaaargh",
                MapLocationID = 9,
                KingdomLocation = "Southern Plains",
                Description = "This old castle is in ruins. Located just south of Camelot, " +
                              "not many people venture to these ruins despite their close proximity " +
                              "for fear of the two who do reside within the crumbling walls. ",
                GeneralContents = "The walls of this old castle are all but destroyed. The area is " +
                             "barren save a guarded plank bridge, leading to a chest. ",
                Accessable = true,
                ExperiencePoints = 30
            },
            new MapLocation
            {
                CommonName = "Water Temple",
                MapLocationID = 6,
                KingdomLocation = "Hylian Ocean",
                Description = "Camelot is located in the vast plains to the south. The fields before it's walls " +
                              "are littered with arrows and the bodies of their intended targets. ",
                GeneralContents = "The imposing stone walls of the castle rise toward the sky. Inside, many of the residents " +
                            "look on with disgust at any non-humans granted entry often throwing stones or food scraps at those " +
                            "daring enough to look them in the eye.",
                Accessable = true,
                ExperiencePoints = 30
            },
            new MapLocation
            {
                CommonName = "City of Dale",
                MapLocationID = 7,
                KingdomLocation = "Lonely Mountain",
                Description = "Camelot is located in the vast plains to the south. The fields before it's walls " +
                              "are littered with arrows and the bodies of their intended targets. ",
                GeneralContents = "The imposing stone walls of the castle rise toward the sky. Inside, many of the residents " +
                            "look on with disgust at any non-humans granted entry often throwing stones or food scraps at those " +
                            "daring enough to look them in the eye.",
                Accessable = true,
                ExperiencePoints = 30
            },
            new MapLocation
            {
                CommonName = "Tir Na'Lia",
                MapLocationID = 8,
                KingdomLocation = "Unknown Universe",
                Description = "Camelot is located in the vast plains to the south. The fields before it's walls " +
                              "are littered with arrows and the bodies of their intended targets. ",
                GeneralContents = "The imposing stone walls of the castle rise toward the sky. Inside, many of the residents " +
                            "look on with disgust at any non-humans granted entry often throwing stones or food scraps at those " +
                            "daring enough to look them in the eye.",
                Accessable = true,
                ExperiencePoints = 30
            }
        };
    }
}
