using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// view class
    /// </summary>
    public class ConsoleView
    {
        #region ENUMS

        private enum ViewStatus
        {
            TravelerInitialization,
            PlayingGame
        }

        #endregion

        #region FIELDS

        //
        // declare game objects for the ConsoleView object to use
        //
        Player _gamePlayer;
        Kingdom _gameKingdom;

        ViewStatus _viewStatus;
        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Player gameTraveler, Kingdom gameKingdom)
        {
            _gamePlayer = gameTraveler;
            _gameKingdom = gameKingdom;

            InitializeDisplay();
        }

        #endregion

        #region METHODS
        /// <summary>
        /// display all of the elements on the game play screen on the console
        /// </summary>
        /// <param name="messageBoxHeaderText">message box header title</param>
        /// <param name="messageBoxText">message box text</param>
        /// <param name="menu">menu to use</param>
        /// <param name="inputBoxPrompt">input box text</param>
        public void DisplayGamePlayScreen(string messageBoxHeaderText, string messageBoxText, Menu menu, string inputBoxPrompt)
        {
            //
            // reset screen to default window colors
            //
            Console.BackgroundColor = ConsoleTheme.WindowBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.WindowForegroundColor;
            Console.Clear();

            ConsoleWindowHelper.DisplayHeader(Text.HeaderText);
            ConsoleWindowHelper.DisplayFooter(Text.FooterText);

            DisplayMessageBox(messageBoxHeaderText, messageBoxText);
            DisplayMenuBox(menu);
            DisplayInputBox();
            DisplayStatusBox();
        }

        /// <summary>
        /// wait for any keystroke to continue
        /// </summary>
        public void GetContinueKey()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// get a action menu choice from the user
        /// </summary>
        /// <returns>action menu choice</returns>
        public PlayerAction GetActionMenuChoice(Menu menu)
        {
            PlayerAction choosenAction = PlayerAction.None;
            Console.CursorVisible = false;

            //
            //crate an array of valid keys from menu dictionary
            //
            char[] validKeys = menu.MenuChoices.Keys.ToArray();

            //
            //validate key pressed an in MenuChoices dictionary
            //
            char keyPressed;
            do
            {
                ConsoleKeyInfo keyPressedInfo = Console.ReadKey();
                keyPressed = keyPressedInfo.KeyChar;
            } while (!validKeys.Contains(keyPressed));


            choosenAction = menu.MenuChoices[keyPressed];
            Console.CursorVisible = true;

            return choosenAction;
        }

        /// <summary>
        /// get a string value from the user
        /// </summary>
        /// <returns>string value</returns>
        public string GetString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>
        public bool GetInteger(string prompt, int minimumValue, int maximumValue, out int integerChoice)
        {
            bool validResponse = false;
            integerChoice = 0;

            //
            //validate on range if either minimumValue and MaximumVAlue are not 0 
            //
            bool validateRange = (minimumValue != 0 || maximumValue != 0);

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
                if (int.TryParse(Console.ReadLine(), out integerChoice))
                {
                    if (validateRange)
                    {
                        if (integerChoice >= minimumValue && integerChoice <= maximumValue)
                        {
                            validResponse = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                            DisplayInputBoxPrompt(prompt);
                        }
                    }
                    else
                    {
                        validResponse = true;
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            return true;
        }

        /// <summary>
        /// get bool from the user
        /// </summary>
        /// <returns>userChoice</returns>
        public bool GetBool(string prompt, out bool boolChoice)
        {
            bool validResponse = false;
            boolChoice = false;

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
                if (bool.TryParse(Console.ReadLine(), out boolChoice))
                {
                    if (boolChoice == false)
                    {
                        validResponse = true;
                    }
                    else if (boolChoice == true)
                    {
                        validResponse = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage($"You must enter true or false. Please try again.");
                        DisplayInputBoxPrompt(prompt);
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter true or false. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }
            return boolChoice;
        }

        /// <summary>
        /// get a character race value from the user
        /// </summary>
        /// <returns>character race value</returns>
        public Character.RaceType GetRace()
        {
            Character.RaceType raceType;
            Enum.TryParse<Character.RaceType>(Console.ReadLine(), out raceType);

            return raceType;
        }

        /// <summary>
        /// get the players profession from the user
        /// </summary>
        /// <returns></returns>
        public Player.PlayerProfession GetProfession()
        {
            Player.PlayerProfession profession;
            Enum.TryParse<Player.PlayerProfession>(Console.ReadLine(), out profession);

            return profession;
        }

        /// <summary>
        /// display splash screen
        /// </summary>
        /// <returns>player chooses to play</returns>
        public bool DisplaySpashScreen()
        {
            bool playing = true;
            ConsoleKeyInfo keyPressed;

            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.SplashScreenForegroundColor;
            Console.Clear();
            Console.CursorVisible = false;


            Console.SetCursorPosition(0, 10);
            string tabSpace = new String(' ', 35);
            Console.WriteLine(tabSpace + @" (");
            Console.WriteLine(tabSpace + @" )\ )                 )    *   )         ");
            Console.WriteLine(tabSpace + @"(()/(      )  (    ( /(  ` )  /( (      )      (");
            Console.WriteLine(tabSpace + @" /(_))  ( /(  )(   )\())  ( )(_)))\    (      ))\ (");
            Console.WriteLine(tabSpace + @"(_))_   )(_))(()\ ((_)\  (_(_())((_)   )\  ' /((_))\");
            Console.WriteLine(tabSpace + @" |   \ ((_)_  ((_)| |(_) |_   _| (_) _((_)) (_)) ((_)");
            Console.WriteLine(tabSpace + @" | |) |/ _` || '_|| / /    | |   | || '  \()/ -_)(_-<");
            Console.WriteLine(tabSpace + @" |___/ \__,_||_|  |_\_\    |_|   |_||_|_|_| \___|/__/");




            Console.SetCursorPosition(80, 25);
            Console.Write("Press any key to continue or Esc to exit.");
            keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                playing = false;
            }

            return playing;
        }

        /// <summary>
        /// initialize the console window settings
        /// </summary>
        private static void InitializeDisplay()
        {
            //
            // control the console window properties
            //
            ConsoleWindowControl.DisableResize();
            ConsoleWindowControl.DisableMaximize();
            ConsoleWindowControl.DisableMinimize();
            Console.Title = "Dark Times";

            //
            // set the default console window values
            //
            ConsoleWindowHelper.InitializeConsoleWindow();

            Console.CursorVisible = false;
        }

        /// <summary>
        /// display the correct menu in the menu box of the game screen
        /// </summary>
        /// <param name="menu">menu for current game state</param>
        private void DisplayMenuBox(Menu menu)
        {
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuBorderColor;

            //
            // display menu box border
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MenuBoxPositionTop,
                ConsoleLayout.MenuBoxPositionLeft,
                ConsoleLayout.MenuBoxWidth,
                ConsoleLayout.MenuBoxHeight);

            //
            // display menu box header
            //
            Console.BackgroundColor = ConsoleTheme.MenuBorderColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(menu.MenuTitle, ConsoleLayout.MenuBoxWidth - 4));

            //
            // display menu choices
            //
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            int topRow = ConsoleLayout.MenuBoxPositionTop + 3;

            foreach (KeyValuePair<char, PlayerAction> menuChoice in menu.MenuChoices)
            {
                if (menuChoice.Value != PlayerAction.None)
                {
                    string formatedMenuChoice = ConsoleWindowHelper.ToLabelFormat(menuChoice.Value.ToString());
                    Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
                    Console.Write($"{menuChoice.Key}. {formatedMenuChoice}");
                }
            }
        }

        /// <summary>
        /// display the text in the message box of the game screen
        /// </summary>
        /// <param name="headerText"></param>
        /// <param name="messageText"></param>
        private void DisplayMessageBox(string headerText, string messageText)
        {
            //
            // display the outline for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxBorderColor;
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MessageBoxPositionTop,
                ConsoleLayout.MessageBoxPositionLeft,
                ConsoleLayout.MessageBoxWidth,
                ConsoleLayout.MessageBoxHeight);

            //
            // display message box header
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBorderColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MessageBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(headerText, ConsoleLayout.MessageBoxWidth - 4));

            //
            // display the text for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            List<string> messageTextLines = new List<string>();
            messageTextLines = ConsoleWindowHelper.MessageBoxWordWrap(messageText, ConsoleLayout.MessageBoxWidth - 4);

            int startingRow = ConsoleLayout.MessageBoxPositionTop + 3;
            int endingRow = startingRow + messageTextLines.Count();
            int row = startingRow;
            foreach (string messageTextLine in messageTextLines)
            {
                Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, row);
                Console.Write(messageTextLine);
                row++;
            }

        }

        /// <summary>
        /// draw the status box on the game screen
        /// </summary>
        public void DisplayStatusBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            //
            // display the outline for the status box
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.StatusBoxPositionTop,
                ConsoleLayout.StatusBoxPositionLeft,
                ConsoleLayout.StatusBoxWidth,
                ConsoleLayout.StatusBoxHeight);

            //
            // display the text for the status box if playing game
            //
            if (_viewStatus == ViewStatus.PlayingGame)
            {
                //
                // display status box header with title
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("Game Stats", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;

                //
                // display stats
                //
                int startingRow = ConsoleLayout.StatusBoxPositionTop + 3;
                int row = startingRow;
                foreach (string statusTextLine in Text.StatusBox(_gamePlayer, _gameKingdom))
                {
                    Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 3, row);
                    Console.Write(statusTextLine);
                    row++;
                }
            }
            else
            {
                //
                // display status box header without header
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
            }
        }

        /// <summary>
        /// draw the input box on the game screen
        /// </summary>
        public void DisplayInputBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.InputBoxPositionTop,
                ConsoleLayout.InputBoxPositionLeft,
                ConsoleLayout.InputBoxWidth,
                ConsoleLayout.InputBoxHeight);
        }

        /// <summary>
        /// display the prompt in the input box of the game screen
        /// </summary>
        /// <param name="prompt"></param>
        public void DisplayInputBoxPrompt(string prompt)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 1);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.Write(prompt);
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the error message in the input box of the game screen
        /// </summary>
        /// <param name="errorMessage">error message text</param>
        public void DisplayInputErrorMessage(string errorMessage)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 2);
            Console.ForegroundColor = ConsoleTheme.InputBoxErrorMessageForegroundColor;
            Console.Write(errorMessage);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.CursorVisible = true;
        }

        /// <summary>
        /// clear the input box
        /// </summary>
        private void ClearInputBox()
        {
            string backgroundColorString = new String(' ', ConsoleLayout.InputBoxWidth - 4);

            Console.ForegroundColor = ConsoleTheme.InputBoxBackgroundColor;
            for (int row = 1; row < ConsoleLayout.InputBoxHeight - 2; row++)
            {
                Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + row);
                DisplayInputBoxPrompt(backgroundColorString);
            }
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
        }

        /// <summary>
        /// get the player's initial information at the beginning of the game
        /// </summary>
        /// <returns>traveler object with all properties updated</returns>
        public Player GetInitialTravelerInfo()
        {
            Player traveler = new Player();

            //
            // intro
            //
            DisplayGamePlayScreen("Mission Initialization", Text.InitializeMissionIntro(), ActionMenu.MissionIntro, "");
            GetContinueKey();

            //
            // get traveler's name
            //
            DisplayGamePlayScreen("Mission Initialization - Name", Text.InitializeMissionGetPlayerName(), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt("Enter your name: ");
            traveler.Name = GetString();

            //
            // get traveler's age
            //
            DisplayGamePlayScreen("Mission Initialization - Age", Text.InitializeMissionGetPlayerAge(traveler), ActionMenu.MissionIntro, "");
            int gameTravelerAge;

            GetInteger($"Enter your age {traveler.Name}: ", 0, 1000000, out gameTravelerAge);
            traveler.Age = gameTravelerAge;

            //
            // get traveler's race
            //
            DisplayGamePlayScreen("Mission Initialization - Race", Text.InitializeMissionGetPlayerRace(traveler), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt($"Enter your race {traveler.Name}: ");
            traveler.Race = GetRace();

            //
            // get traveler's gender
            //
            DisplayGamePlayScreen("Mission Initialization - Gender", Text.InitializeMissionGetPlayerGender(traveler), ActionMenu.MissionIntro, "");
            bool genderBool;

            GetBool($"Enter true if you are male or false if you are female: ", out genderBool);
            traveler.IsMale = genderBool;

            //
            // get traveler's profession
            //
            DisplayGamePlayScreen("Mission Initialization - Profession", Text.InitializeMissionGetPlayerProfession(traveler), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt($"Enter your profession {traveler.Name}: ");
            traveler.Profession = GetProfession();

            //
            // get traveler's pet
            //
            DisplayGamePlayScreen("Mission Initialization - Pet", Text.InitializeMissionGetPlayerPet(traveler), ActionMenu.MissionIntro, "");
            bool petBool;

            GetBool($"Enter true if you have a pet or false if you do not: ", out petBool);
            traveler.HasPet = petBool;

            if (traveler.HasPet == true)
            {
                //
                // get traveler's pet's name
                //
                DisplayGamePlayScreen("Mission Initialization - Pet's Name", Text.InitializeMissionGetPlayerPetName(traveler), ActionMenu.MissionIntro, "");
                DisplayInputBoxPrompt("Enter your pet's name: ");
                traveler.PetName = GetString();

                //
                // get traveler's pet's age
                //
                DisplayGamePlayScreen("Mission Initialization - Age", Text.InitializeMissionGetPlayerAge(traveler), ActionMenu.MissionIntro, "");
                int gameTravelerPetAge;

                GetInteger($"Enter your pet's age {traveler.Name}: ", 0, 1000000, out gameTravelerPetAge);
                traveler.PetAge = gameTravelerPetAge;
            }
            //
            // echo the traveler's info
            //
            DisplayGamePlayScreen("Mission Initialization - Complete", Text.InitializeMissionEchoPlayerInfo(traveler), ActionMenu.MissionIntro, "");
            GetContinueKey();
            _viewStatus = ViewStatus.PlayingGame;

            return traveler;
        }

        /// <summary>
        /// list of locations
        /// </summary>
        public void DisplayListOfMapLocations()
        {
            DisplayGamePlayScreen("List: Map Locations", Text.ListMapLocations
                (_gameKingdom.MapLocations), ActionMenu.AdminMenu, "");
        }

        /// <summary>
        /// display info on current location
        /// </summary>
        public void DisplayLookAround()
        {
            //
            // get current map location
            //
            MapLocation currentMapLocation = _gameKingdom.GetMapLocationById(_gamePlayer.MapLocationID);

            //
            //get list of game objects in current map location
            //
            List<GameObject> gameObjectsInCurrentMapLocation = _gameKingdom.GetGameObjectsByMapLocationId(_gamePlayer.MapLocationID);

            string messageBoxText = Text.LookAround(currentMapLocation) + Environment.NewLine + Environment.NewLine;
            messageBoxText += Text.GameObjectsChooseList(gameObjectsInCurrentMapLocation);

            DisplayGamePlayScreen("Current Location", messageBoxText, ActionMenu.MainMenu, "");
        }

        /// <summary>
        /// get next destination from the user
        /// </summary>
        /// <returns></returns>
        public int DisplayGetNextMapLocation()
        {
            int mapLocationId = 0;
            bool validMapLocationId = false;

            DisplayGamePlayScreen("Travel to a New Location", Text.Travel(_gamePlayer, _gameKingdom.MapLocations), ActionMenu.MainMenu, "");

            while (!validMapLocationId)
            {
                //
                // get an integer from the player
                //
                GetInteger($"Enter your new location {_gamePlayer.Name}: ", 1, _gameKingdom.GetMaxMapLocationId(), out mapLocationId);

                //
                // validate integer as a valid map location id and determine accessibility
                //
                if (_gameKingdom.IsValidMapLocationId(mapLocationId))
                {
                    if (_gameKingdom.GetMapLocationById(mapLocationId).Accessable)
                    {
                        validMapLocationId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you attempting to travel to an inaccessible location. Please try again.");
                    }
                }
                else
                {
                    DisplayInputErrorMessage("It appears you entered an invalid location id. Please try again.");
                }
            }

            return mapLocationId;
        }

        public int DisplayGetGameObjectToLookAt()
        {
            int gameObjectId = 0;
            bool validGamerObjectId = false;

            //
            // get a list of game objects in the current map location
            //
            List<GameObject> gameObjectsInMapLocation = _gameKingdom.GetGameObjectsByMapLocationId(_gamePlayer.MapLocationID);

            if (gameObjectsInMapLocation.Count > 0)
            {
                DisplayGamePlayScreen("Look at an Object", Text.GameObjectsChooseList(gameObjectsInMapLocation), ActionMenu.MainMenu, "");

                while (!validGamerObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the object you wish to look at: ", 0, 0, out gameObjectId);

                    //
                    // validate integer as a valid game object id and in current location
                    //
                    if (_gameKingdom.IsValidGameObjectByLocationId(gameObjectId, _gamePlayer.MapLocationID))
                    {
                        validGamerObjectId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid game object id. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Look at an Object", "It appears there are no game objects here.", ActionMenu.MainMenu, "");
            }

            return gameObjectId;
        }

        public int DisplayGetPlayerObjectToPickUp()
        {
            int gameObjectId = 0;
            bool validGameObjectId = false;

            //
            // get a list of player objects in the current map location
            //
            List<PlayerObject> playerObjectsInMapLocation = _gameKingdom.GetPlayerObjectsByMapLocationId(_gamePlayer.MapLocationID);

            if (playerObjectsInMapLocation.Count > 0)
            {
                DisplayGamePlayScreen("Pick Up Game Object", Text.GameObjectsChooseList(playerObjectsInMapLocation), ActionMenu.MainMenu, "");

                while (!validGameObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the object you wish to add to your inventory: ", 0, 12, out gameObjectId);

                    //
                    // validate integer as a valid game object id and in current location
                    //
                    if (_gameKingdom.IsValidPlayerObjectByLocationId(gameObjectId, _gamePlayer.MapLocationID))
                    {
                        PlayerObject playerObject = _gameKingdom.GetGameObjectById(gameObjectId) as PlayerObject;
                        validGameObjectId = true;
                        //if (playerObject.CanInventory)
                        //{
                        //    validGameObjectId = true;
                        //}
                        //else
                        //{
                        //    ClearInputBox();
                        //    DisplayInputErrorMessage("It appears you may not inventory that object. Please try again.");
                        //}
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid game object id. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Pick Up Game Object", "It appears there are no game objects here.", ActionMenu.MainMenu, "");
            }

            return gameObjectId;
        }

        public void DisplayConfirmPlayerObjectAddedToInventory(PlayerObject objectAddedToInventory)
        {
            DisplayGamePlayScreen("Pick Up Game Object", $"The {objectAddedToInventory.Name} " + 
            "has been added to your inventory.", ActionMenu.MainMenu, "");
        }

        public int DisplayGetInventoryObjectToPutDown()
        {
            int playerObjectId = 0;
            bool validInventoryObjectId = false;

            if (_gamePlayer.Inventory.Count > 0)
            {
                DisplayGamePlayScreen("Put Down Game Object", Text.GameObjectsChooseList(_gamePlayer.Inventory), ActionMenu.MainMenu, "");

                while (!validInventoryObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the object you wish to remove from your inventory: ", 0, 12, out playerObjectId);

                    //
                    // find object in inventory
                    // 
                    //
                    PlayerObject objectToPutDown = _gamePlayer.Inventory.FirstOrDefault(o => o.Id == playerObjectId);

                    //
                    // validate object in inventory
                    //
                    if (objectToPutDown != null)
                    {
                        validInventoryObjectId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered the Id of an object not in the inventory. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Pick Up Game Object", "It appears there are no objects currently in inventory.", ActionMenu.MainMenu, "");
            }

            return playerObjectId;
        }

        public void DisplayConfirmPlayerObjectRemovedFromInventory(PlayerObject objectRemovedFromInventory)
        {
            DisplayGamePlayScreen("Put Down Game Object", $"The {objectRemovedFromInventory.Name} has been removed from your inventory.", ActionMenu.MainMenu, "");
        }

        //
        // display object info
        //

        public void DisplayGameObjectInfo(GameObject gameObject)
        {
            DisplayGamePlayScreen("Current Location", Text.LookAt(gameObject), ActionMenu.MainMenu, "");
        }

        //
        // Display locations visited
        //

        public void DisplayLocationsVisited()
        {
            //
            // generate a list of map locations that have been visited
            //
            List<MapLocation> visitedMapLocations = new List<MapLocation>();
            foreach (int mapLocationId in _gamePlayer.MapLocationsVisited)
            {
                visitedMapLocations.Add(_gameKingdom.GetMapLocationById(mapLocationId));
            }

            DisplayGamePlayScreen("Locations Visited", Text.VisitedLocations(visitedMapLocations), ActionMenu.MainMenu, "");
        }

        #region ----- display responses to menu action choices -----

        public void DisplayTravelerInfo()
        {
            DisplayGamePlayScreen("Player Information", Text.TravelerInfo(_gamePlayer), ActionMenu.MainMenu, "");
        }

        public void DisplayListOfAllGameObjects()
        {
            DisplayGamePlayScreen("List: Game Objects", Text.ListAllGameObjects(_gameKingdom.GameObjects), ActionMenu.AdminMenu, "");
        }

        public void DisplayInventory()
        {
            DisplayGamePlayScreen("Current Inventory", Text.CurrentInventory(_gamePlayer.Inventory), ActionMenu.MainMenu, "");
        }
        #endregion

        #endregion
    }
}
