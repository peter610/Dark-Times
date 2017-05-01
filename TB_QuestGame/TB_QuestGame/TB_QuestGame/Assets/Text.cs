using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// class to store static and to generate dynamic text for the message and input boxes
    /// </summary>
    public static class Text
    {
        public static List<string> HeaderText = new List<string>() { "Dark Times" };
        public static List<string> FooterText = new List<string>() { "Tiny Game Productions, 2017" };

        #region INTITIAL GAME SETUP

        public static string MissionIntro()
        {
            string messageBoxText =
            "You are a simple farmer caught in the middle of a war that " +
            "has been raging for as long as your people can remember. A " +
            "mysterious figure has approached you speaking of your destiny " +
            "as if it's prophecy. Unsure of his ramblings, you decide to " +
            "join him in hopes of becoming a part of the solution many have " +
            "been looking for.\n" +
            " \n" +
            "Press the Esc key to exit the game at any point.\n" +
            " \n" +
            "Your quest begins now.\n" +
            " \n" +
            "\tYour first task will be to set up the initial parameters of your mission.\n" +
            " \n" +
            "\tPress any key to begin the Mission Initialization Process.\n";

            return messageBoxText;
        }

        public static string CurrentLocationInfo(MapLocation mapLocation)
        {
            string messageBoxText =
                $"Current Location: {mapLocation.CommonName}\n" +
                " /n" +
                mapLocation.Description;

            /*"You have been lead through the desolate buffer of land between the four " +
            "civilzations of Paramethia known as No Man's Land. Your new associate brings " +
            "you to an old cottage hidden in this ownerless territory.\n" +
            " \n" +
            "\tChoose from the menu options to proceed.\n";*/

            return messageBoxText;
        }

        #region Initialize Mission Text

        public static string InitializeMissionIntro()
        {
            string messageBoxText =
                "Before you begin your mission we must gather your base data.\n" +
                " \n" +
                "You will be prompted for the required information. Please enter the information below.\n" +
                " \n" +
                "\tPress any key to begin.";

            return messageBoxText;
        }

        public static string InitializeMissionGetPlayerName()
        {
            string messageBoxText =
                "Enter your name player.\n" +
                " \n" +
                "Please use the name you wish to be referred during your quest.";

            return messageBoxText;
        }

        public static string InitializeMissionGetPlayerPetName(Player gameTraveler)
        {
            string messageBoxText =
                $"Enter your pet's name {gameTraveler.Name}.\n";

            return messageBoxText;
        }

        public static string InitializeMissionGetPlayerAge(Player gameTraveler)
        {
            string messageBoxText =
                $"Very good then, we will call you {gameTraveler.Name} on this quest.\n" +
                " \n" +
                "Enter your age below.\n" +
                " \n" +
                "Please use the standard Earth year as your reference.";

            return messageBoxText;
        }

        public static string InitializeMissionGetPlayerPetAge(Player gameTraveler)
        {
            string messageBoxText =
                $"How old is your pet?\n" +
                " \n" +
                "Enter your pet's age below.\n" +
                " \n" +
                "Please use the standard Earth year as your reference.";

            return messageBoxText;
        }

        public static string InitializeMissionGetPlayerRace(Player gameTraveler)
        {
            string messageBoxText =
                $"{gameTraveler.Name}, it will be important for us to know your race on this quest.\n" +
                " \n" +
                "Enter your race below.\n" +
                " \n" +
                "Please use the universal race classifications below." +
                " \n";

            string raceList = null;

            foreach (Character.RaceType race in Enum.GetValues(typeof(Character.RaceType)))
            {
                if (race != Character.RaceType.None)
                {
                    raceList += $"\t{race}\n";
                }
            }

            messageBoxText += raceList;

            return messageBoxText;
        }

        public static string InitializeMissionGetPlayerProfession(Player gameTraveler)
        {
            string messageBoxText =
                $"{gameTraveler.Name}, it will be important for us to know your profession on this quest.\n" +
                " \n" +
                "Enter your profession below.\n" +
                " \n" +
                "Please use job list provided below." +
                " \n";

            string professionList = null;

            foreach (Player.PlayerProfession profession in Enum.GetValues(typeof(Player.PlayerProfession)))
            {
                if (profession != Player.PlayerProfession.None)
                {
                    professionList += $"\t{profession}\n";
                }
            }

            messageBoxText += professionList;

            return messageBoxText;
        }

        public static string InitializeMissionGetPlayerGender(Player gameTraveler)
        {
            string messageBoxText =
                $"{gameTraveler.Name}, are you a male?\n" +
                " \n" +
                "Please enter true or false below.";

            return messageBoxText;
        }


        public static string InitializeMissionGetPlayerPet(Player gameTraveler)
        {
            string messageBoxText =
                $"{gameTraveler.Name}, do you have a pet?\n" +
                " \n" +
                "Please enter true or false below.";

            return messageBoxText;
        }

        public static string InitializeMissionEchoPlayerInfo(Player gameTraveler)
        {
            string messageBoxText =
                $"Very good then {gameTraveler.Name}.\n" +
                " \n" +
                "It appears we have all the necessary data to begin your quest. You will find it" +
                " listed below.\n" +
                " \n" +
                $"\tPlayer Name: {gameTraveler.Name}\n" +
                $"\tPlayer Age: {gameTraveler.Age}\n" +
                $"\tPlayer Race: {gameTraveler.Race}\n" +
                $"\tPlayer is Male: {gameTraveler.IsMale}\n" +
                $"\tPlayer Profession: {gameTraveler.Profession}\n" +
                $"\tPlayer has Pet: {gameTraveler.HasPet}\n" +
                $"\tPlayer Pet's Name: {gameTraveler.PetName}\n" +
                $"\tPlayer Pet's Age: {gameTraveler.PetAge}\n" +
                " \n" +
                "Press any key to begin your quest.";

            return messageBoxText;
        }

        #endregion

        #endregion

        #region MAIN MENU ACTION SCREENS

        public static string TravelerInfo(Player gameTraveler)
        {
            string messageBoxText =
                $"\tPlayer Name: {gameTraveler.Name}\n" +
                $"\tPlayer Age: {gameTraveler.Age}\n" +
                $"\tPlayer Race: {gameTraveler.Race}\n" +
                $"\tPlayer is Male: {gameTraveler.IsMale}\n" +
                $"\tPlayer Profession: {gameTraveler.Profession}\n" +
                $"\tPlayer has Pet: {gameTraveler.HasPet}\n" +
                $"\tPlayer Pet's Name: {gameTraveler.PetName}\n" +
                $"\tPlayer Pet's Age: {gameTraveler.PetAge}\n" +
                " \n";

            return messageBoxText;
        }

        public static string ListMapLocations(IEnumerable<MapLocation> mapLocations)
        {
            string messageBoxText =
                "Map Locations\n" +
                "\n" +

                //
                //display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "\n";

            //
            //display all locations
            //
            string mapLocationList = null;
            foreach (MapLocation mapLocation in mapLocations)
            {
                mapLocationList +=
                    $"{mapLocation.MapLocationID}".PadRight(10) +
                    $"{mapLocation.CommonName}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += mapLocationList;

            return messageBoxText;
        }

        public static string ListAllGameObjects(IEnumerable<GameObject> gameObjects)
        {
            //
            // display table name and column headers
            //
            string messageBoxText =
                "Game Objects\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(30) +
                "Map Location Id".PadRight(10) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) +
                "----------------------".PadRight(10) + "\n";

            //
            // display all player objects in rows
            //
            string gameObjectRows = null;
            foreach (GameObject gameObject in gameObjects)
            {
                gameObjectRows +=
                    $"{gameObject.Id}".PadRight(10) +
                    $"{gameObject.Name}".PadRight(30) +
                    $"{gameObject.MapLocationId}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += gameObjectRows;

            return messageBoxText;
        }

        public static string GameObjectsChooseList(IEnumerable<GameObject> gameObjects)
        {
            //
            // display table name and column headers
            //
            string messageBoxText =
                "Game Objects\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(30) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) + "\n";

            //
            // display all player objects in rows
            //
            string gameObjectRows = null;
            foreach (GameObject gameObject in gameObjects)
            {
                gameObjectRows +=
                    $"{gameObject.Id}".PadRight(10) +
                    $"{gameObject.Name}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += gameObjectRows;

            return messageBoxText;
        }

        public static string LookAt(GameObject gameObject)
        {
            string messageBoxText = "";

            messageBoxText =
                $"{gameObject.Name}\n" +
                " \n" +
                gameObject.Description + " \n" +
                " \n";

            //if (gameObject is PlayerObject)
            //{
                PlayerObject playerObject = gameObject as PlayerObject;

            //    messageBoxText += $"The {travelerObject.Name} has a value of {travelerObject.Value} and ";

            //    if (travelerObject.CanInventory)
            //    {
            //        messageBoxText += "may be added to your inventory.";
            //    }
            //    else
            //    {
            //        messageBoxText += "may not be added to your inventory.";
            //    }
            //}
            //else
            //{
            //    messageBoxText += $"The {gameObject.Name} may not be added to your inventory.";
            //}

            return messageBoxText;
        }

        public static string CurrentInventory(IEnumerable<PlayerObject> inventory)
        {
            string messageBoxText = "";

            //
            // display table header
            //
            messageBoxText =
            "ID".PadRight(10) +
            "Name".PadRight(30) +
            "Type".PadRight(10) +
            "\n" +
            "---".PadRight(10) +
            "----------------------------".PadRight(30) +
            "----------------------".PadRight(10) +
            "\n";

            //
            // display all player objects in rows
            //
            string inventoryObjectRows = null;
            foreach (PlayerObject inventoryObject in inventory)
            {
                inventoryObjectRows +=
                    $"{inventoryObject.Id}".PadRight(10) +
                    $"{inventoryObject.Name}".PadRight(30) +
                    $"{inventoryObject.Type}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += inventoryObjectRows;

            return messageBoxText;
        }

        public static string LookAround(MapLocation mapLocation)
        {
            string messageBoxText =
                $"Current Location: {mapLocation.CommonName}\n" +
                " \n" +
                mapLocation.GeneralContents;

            return messageBoxText;
        }

        public static string Travel(Player gamePlayer, List<MapLocation> mapLocations)
        {
            string messageBoxText =
                $"{gamePlayer.Name}, Aion Base will need to know the name of the new location.\n" +
                " \n" +
                "Enter the ID number of your desired location from the table below.\n" +
                " \n" +

            //
            // display table header
            //
            "ID".PadRight(10) + "Name".PadRight(30) + "Accessible".PadRight(10) + "\n" +
                "---".PadRight(10) + "---------------".PadRight(30) + "-------".PadRight(10) + "\n";

            //
            // display all locations except the current location
            //

            string mapLocationList = null;

            foreach (MapLocation mapLocation in mapLocations)
            {
                if (mapLocation.MapLocationID != gamePlayer.MapLocationID)
                {
                    mapLocationList +=
                    $"{mapLocation.MapLocationID}".PadRight(10) +
                    $"{mapLocation.CommonName}".PadRight(30) +
                    $"{mapLocation.Accessable}".PadRight(10) +
                    Environment.NewLine;
                }
            }

            messageBoxText += mapLocationList;

            return messageBoxText;
        }

        //
        // display all locations already visited
        //

        public static string VisitedLocations(IEnumerable<MapLocation> mapLocations)
        {
            string messageBoxText =
                "Locations Visited\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "\n";

            //
            // display all locations
            //
            string mapLocationList = null;
            foreach (MapLocation mapLocation in mapLocations)
            {
                mapLocationList +=
                    $"{mapLocation.MapLocationID}".PadRight(10) +
                    $"{mapLocation.CommonName}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += mapLocationList;

            return messageBoxText;
        }

        public static List<string> StatusBox(Player player, Kingdom kingdom)
        {
            List<string> statusBoxText = new List<string>();

            statusBoxText.Add($"Experience Points: {player.ExperiencePoints}\n");
            statusBoxText.Add($"Health: {player.Health}\n");
            statusBoxText.Add($"Lives: {player.Lives}\n");

            return statusBoxText;
        }

        #endregion
    }
}
