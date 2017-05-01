using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public static partial class KingdomObjects
    {
        public static List<GameObject> gameObjects = new List<GameObject>()
        {
            new PlayerObject
            {
                Id = 1,
                Name = "Xoran Sapphire",
                MapLocationId = 6,
                Description = "One of the jewels that had adorned the ancient crown. It" +
                " glows with a brilliant blue light.",
                Type = PlayerObjectType.Crown
            },
            new PlayerObject
            {
                Id = 2,
                Name = "Dwarven Ruby",
                MapLocationId = 3,
                Description = "One of the jewels that had adorned the ancient crown. It" +
                " gives off a feint red light and is warm to the touch.",
                Type = PlayerObjectType.Crown
            },
            new PlayerObject
            {
                Id = 3,
                Name = "Elven Emerald",
                MapLocationId = 4,
                Description = "One of the jewels that had adorned the ancient crown. It" +
                " glows slightly and gives off a strange magical energy.",
                Type = PlayerObjectType.Crown
            },
            new PlayerObject
            {
                Id = 4,
                Name = "Human Diamond",
                MapLocationId = 5,
                Description = "One of the jewels that had adorned the ancient crown. It" +
                " is ridgid and the light seems to pierce the darkness",
                Type = PlayerObjectType.Crown
            },
            new PlayerObject
            {
                Id = 5,
                Name = "Rebreather",
                MapLocationId = 8,
                Description = "This is a xoran device that is granted to non-xoran's who" +
                " are deemed worthy of entering their city. It allows the user to breath under water.",
                Type = PlayerObjectType.Key
            },
            new PlayerObject
            {
                Id = 6,
                Name = "Banner of Camelot",
                MapLocationId = 7,
                Description = "This banner is carried by the friends of Camelot to signal" +
                " their approach to the city.",
                Type = PlayerObjectType.Key
            },
            new PlayerObject
            {
                Id = 7,
                Name = "Map of the Lost Woods",
                MapLocationId = 9,
                Description = "This map was drawn as a path through the forests between " +
                "No-Man's Land and Dol Blathanna. It is given to elven children to be memorize.",
                Type = PlayerObjectType.Key
            },
            new PlayerObject
            {
                Id = 8,
                Name = "Climbing Gear",
                MapLocationId = 6,
                Description = "This gear was created by the dwarves with metals from the " +
                "Lonely Mountain. The dwarves use it to traverse the slopes of the mountain. ",
                Type = PlayerObjectType.Key
            },
            new PlayerObject
            {
                Id = 9,
                Name = "Heart of the Mountain",
                MapLocationId = 7,
                Description = "This stone, though beautiful, seems trivial to anyone  " +
                "save the dwarves. To them, it represents their empire.  ",
                Type = PlayerObjectType.Quest
            },
            new PlayerObject
            {
                Id = 10,
                Name = "Holy Grail",
                MapLocationId = 9,
                Description = "Human prophecy tells that this chalice, golden, and adorned with " +
                "many jewels, is blessed by their god with holy power.",
                Type = PlayerObjectType.Quest
            },
            new PlayerObject
            {
                Id = 11,
                Name = "Vial of the Elderblood",
                MapLocationId = 8,
                Description = "This blood is believed to have come from an important ancestor of the elves. " +
                "Bearers of the Elderblood are said to be able to travel through time and space at will.  ",
                Type = PlayerObjectType.Quest
            },
                        new PlayerObject
            {
                Id = 12,
                Name = "Ancient Crown",
                MapLocationId = 0,
                Description = "The crown that long ago was worn by the king who lead all of the races. " +
                "There are four empty slots for jewels from each of the races meant to represent unity under one leader.  ",
                Type = PlayerObjectType.Quest
            }
        };
    }
}
