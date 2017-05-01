using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private Player _gamePlayer;
        private Kingdom _gameKingdom;
        private bool _playingGame;
        private MapLocation _currentLocation;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            //
            // setup all of the objects in the game
            //
            InitializeGame();

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame()
        {
            _gamePlayer = new Player();
            _gameKingdom = new Kingdom();
            _gameConsoleView = new ConsoleView(_gamePlayer, _gameKingdom);
            _playingGame = true;

            //
            //add initial items to player inventory
            //
            _gamePlayer.Inventory.Add(_gameKingdom.GetGameObjectById(12) as PlayerObject);

            _gamePlayer.MapLocationID = 1;

            Console.CursorVisible = false;
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            PlayerAction travelerActionChoice = PlayerAction.None;

            //
            // display splash screen
            //
            _playingGame = _gameConsoleView.DisplaySpashScreen();

            //
            // player chooses to quit
            //
            if (!_playingGame)
            {
                Environment.Exit(1);
            }

            //
            // display introductory message
            //
            _gameConsoleView.DisplayGamePlayScreen("Mission Intro", Text.MissionIntro(), ActionMenu.MissionIntro, "");
            _gameConsoleView.GetContinueKey();

            //
            // initialize the mission traveler
            // 
            InitializeMission();

            //
            // prepare game play screen
            //
            _currentLocation = _gameKingdom.GetMapLocationById(_gamePlayer.MapLocationID);
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");

            //
            // game loop
            //
            while (_playingGame)
            {
                //
                // process all flags, events, and stats
                //
                UpdateGameStatus();

                //
                // get next game action from player
                //
                if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.MainMenu)
                {
                    travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                }
                else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.AdminMenu)
                {
                    travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdminMenu);
                }

                //
                // choose an action based on the user's menu choice
                //
                switch (travelerActionChoice)
                {
                    case PlayerAction.None:
                        break;

                    case PlayerAction.PlayerInfo:
                        _gameConsoleView.DisplayTravelerInfo();
                        break;

                    case PlayerAction.ListMapLocations:
                        _gameConsoleView.DisplayListOfMapLocations();
                        break;

                    case PlayerAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;

                    case PlayerAction.Travel:
                        //
                        // get new location choice and update the current location property
                        //
                        _gamePlayer.MapLocationID = _gameConsoleView.DisplayGetNextMapLocation();
                        _currentLocation = _gameKingdom.GetMapLocationById(_gamePlayer.MapLocationID);

                        //
                        //set the game play screen to the current location info format
                        //
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo
                            (_currentLocation), ActionMenu.MainMenu, "");
                        break;

                    case PlayerAction.PlayerLocationsVisited:
                        _gameConsoleView.DisplayLocationsVisited();
                        break;

                    case PlayerAction.ListGameObjects:
                        _gameConsoleView.DisplayListOfAllGameObjects();
                        break;

                    case PlayerAction.LookAt:
                        LookAtAction();
                        break;

                    case PlayerAction.AdminMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an operation from the menu.",
                            ActionMenu.AdminMenu, "");
                        break;

                    case PlayerAction.ReturnToMainMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo
                            (_currentLocation), ActionMenu.MainMenu, "");
                        break;

                    case PlayerAction.Inventory:
                        _gameConsoleView.DisplayInventory();
                        break;

                    case PlayerAction.PickUp:
                        PickUpAction();
                        break;

                    case PlayerAction.PutDown:
                        PutDownAction();
                        break;

                    case PlayerAction.Exit:
                        _playingGame = false;
                        break;

                    default:
                        break;
                }
            }

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// process the Look At action
        /// </summary>
        private void LookAtAction()
        {
            //
            // display a list of game objects in map location and get a player choice
            //
            int gameObjectToLookAtId = _gameConsoleView.DisplayGetGameObjectToLookAt();

            //
            // display game object info
            //
            if (gameObjectToLookAtId != 0)
            {
                //
                // get the game object from the kingdom
                //
                GameObject gameObject = _gameKingdom.GetGameObjectById(gameObjectToLookAtId);

                //
                // display information for the object chosen
                //
                _gameConsoleView.DisplayGameObjectInfo(gameObject);
            }
        }

        /// <summary>
        /// process the Pick Up action
        /// </summary>
        private void PickUpAction()
        {
            //
            // display a list of player objects in map location and get a player choice
            //
            int playerObjectToPickUpId = _gameConsoleView.DisplayGetPlayerObjectToPickUp();

            //
            // add the player object to player's inventory
            //
            if (playerObjectToPickUpId != 0)
            {
                //
                // get the game object from the kingdom
                //
                PlayerObject playerObject = _gameKingdom.GetGameObjectById(playerObjectToPickUpId) as PlayerObject;

                //
                // note: player object is added to list and the map location is set to 0
                //
                _gamePlayer.Inventory.Add(playerObject);
                playerObject.MapLocationId = 0;

                //
                // display confirmation message
                //
                _gameConsoleView.DisplayConfirmPlayerObjectAddedToInventory(playerObject);
            }
        }

        /// <summary>
        /// process the put down action
        /// </summary>
        private void PutDownAction()
        {
            //
            // display a list of player objects in inventory and get a player choice
            //
            int inventoryObjectToPutDownId = _gameConsoleView.DisplayGetInventoryObjectToPutDown();

            //
            // get the game object from the kingdom
            //
            PlayerObject playerObject = _gameKingdom.GetGameObjectById(inventoryObjectToPutDownId) as PlayerObject;

            //
            // remove the object from inventory and set the map location to the current value
            //
            _gamePlayer.Inventory.Remove(playerObject);
            playerObject.MapLocationId = _gamePlayer.MapLocationID;

            //
            // display confirmation message
            //
            _gameConsoleView.DisplayConfirmPlayerObjectRemovedFromInventory(playerObject);

        }

        /// <summary>
        /// initialize the player info
        /// </summary>
        private void InitializeMission()
        {
            Player traveler = _gameConsoleView.GetInitialTravelerInfo();

            _gamePlayer.Name = traveler.Name;
            _gamePlayer.Age = traveler.Age;
            _gamePlayer.Race = traveler.Race;
            _gamePlayer.IsMale = traveler.IsMale;
            _gamePlayer.Profession = traveler.Profession;
            _gamePlayer.HasPet = traveler.HasPet;
            _gamePlayer.PetName = traveler.PetName;
            _gamePlayer.PetAge = traveler.PetAge;

            _gamePlayer.ExperiencePoints = 0;
            _gamePlayer.Health = 100;
            _gamePlayer.Lives = 3;

        }

        private void UpdateGameStatus()
        {
            if (!_gamePlayer.HasVisited(_currentLocation.MapLocationID))
            {
                //
                // add new location to the list of visited locations if this is a first visit
                //
                _gamePlayer.MapLocationsVisited.Add(_currentLocation.MapLocationID);

                //
                // update experience points for visiting locations
                //
                _gamePlayer.ExperiencePoints += _currentLocation.ExperiencePoints;
                _gameConsoleView.DisplayStatusBox();
            }
        }

        #endregion
    }
}
