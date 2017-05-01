using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class Kingdom
    {
        #region ***** define all lists to be maintained by the Kingdom object *****

        //
        // list of all map locations, game, and NPC objects
        //
        private List<MapLocation> _mapLocations;
        private List<GameObject> _gameObjects;
        private List<Npc> _npcs;



        public List<MapLocation> MapLocations
        {
            get { return _mapLocations; }
            set { _mapLocations = value; }
        }
        public List<GameObject> GameObjects
        {
            get { return _gameObjects; }
            set { _gameObjects = value; }
        }

        public List<Npc> Npcs
        {
            get { return _npcs; }
            set { _npcs = value; }
        }


        #endregion

        #region ***** constructor *****

        //
        // default Kingdom constructor
        //
        public Kingdom()
        {
            //
            // add all of the kingdom objects to the game
            // 
            IntializeKingdom();
        }

        #endregion

        #region ***** define methods to initialize all game elements *****

        /// <summary>
        /// initialize the kingdom with all of the map locations
        /// </summary>
        private void IntializeKingdom()
        {
            _mapLocations = KingdomObjects.MapLocations;
            _gameObjects = KingdomObjects.gameObjects;
            _npcs = KingdomObjects.Npcs;
        }

        #endregion

        #region ***** define methods to return game element objects and information *****

        /// <summary>
        /// determine if the Map Location Id is valid
        /// </summary>
        /// <param name="mapLocationId">true if Map Location exists</param>
        /// <returns></returns>
        public bool IsValidMapLocationId(int mapLocationId)
        {
            List<int> mapLocationIds = new List<int>();

            //
            // create a list of map location ids
            //
            foreach (MapLocation stl in _mapLocations)
            {
                mapLocationIds.Add(stl.MapLocationID);
            }

            //
            //determine if the map location id is valid id and return the result
            //
            if (mapLocationIds.Contains(mapLocationId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// validate NPC object id number in current location
        /// </summary>
        /// <param name="npcId"></param>
        /// <returns>is Id valid</returns>
        public bool IsValidNpcByLocationId(int npcId, int currentMapLocation)
        {
            List<int> npcIds = new List<int>();

            //
            // create a list of NPC ids in current map location
            //
            foreach (Npc npc in _npcs)
            {
                if (npc.MapLocationID == currentMapLocation)
                {
                    npcIds.Add(npc.Id);
                }

            }

            //
            // determine if the game object id is a valid id and return the result
            //
            if (npcIds.Contains(npcId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// determine if a location is accessible to the player
        /// </summary>
        /// <param name="mLocationId"></param>
        /// <returns>accessible</returns>
        public bool IsAccessibleLocation(int mapLocationId)
        {
            MapLocation mapLocation = GetMapLocationById(mapLocationId);
            if (mapLocation.Accessable == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// return the next available ID for a KingdomLocation object
        /// </summary>
        /// <returns>next MapLocationObjectID </returns>
        public int GetMaxMapLocationId()
        {
            int MaxId = 0;

            foreach (MapLocation mapLocation in _mapLocations)
            {
                if (mapLocation.MapLocationID > MaxId)
                {
                    MaxId = mapLocation.MapLocationID;
                }
            }

            return MaxId;
        }

        /// <summary>
        /// get a KingdomLocation object using an Id
        /// </summary>
        /// <param name="Id">map location ID</param>
        /// <returns>requested map location</returns>
        public MapLocation GetMapLocationById(int Id)
        {
            MapLocation mapLocation = null;

            //
            //run through the map location list and grab the correct one
            //
            foreach (MapLocation location in _mapLocations)
            {
                if (location.MapLocationID == Id)
                {
                    mapLocation = location;
                }
            }

            //
            //the specified ID was not found in the Kingdom
            //throw an exception
            //
            if (mapLocation == null)
            {
                string feedbackMessage = $"The Map location ID {Id} does not exist in the current Kingdom.";
                throw new ArgumentException(Id.ToString(), feedbackMessage);
            }

            return mapLocation;
        }

        /// <summary>
        /// validate game object id number in current location
        /// </summary>
        /// <param name="gameObjectId"></param>
        /// <returns>is Id valid</returns>
        public bool IsValidGameObjectByLocationId(int gameObjectId, int currentMapLocation)
        {
            List<int> gameObjectIds = new List<int>();

            //
            // create a list of game object ids in current map location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.MapLocationId == currentMapLocation)
                {
                    gameObjectIds.Add(gameObject.Id);
                }

            }

            //
            // determine if the game object id is a valid id and return the result
            //
            if (gameObjectIds.Contains(gameObjectId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// get a game object using an Id
        /// </summary>
        /// <param name="Id">game object Id</param>
        /// <returns>requested game object</returns>
        public GameObject GetGameObjectById(int Id)
        {
            GameObject gameObjectToReturn = null;

            //
            // run through the game object list and grab the correct one
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.Id == Id)
                {
                    gameObjectToReturn = gameObject;
                }
            }

            //
            // the specified ID was not found in the kingdom
            // throw an exception
            //
            if (gameObjectToReturn == null)
            {
                string feedbackMessage = $"The Game Object ID {Id} does not exist in the Kingdom.";
                throw new ArgumentException(Id.ToString(), feedbackMessage);
            }

            return gameObjectToReturn;
        }

        /// <summary>
        /// get an NPC object using an Id
        /// </summary>
        /// <param name="Id">NPC object Id</param>
        /// <returns>requested NPC object</returns>
        public Npc GetNpcById(int Id)
        {
            Npc npcToReturn = null;

            //
            // run through the NPC object list and grab the correct one
            //
            foreach (Npc npc in _npcs)
            {
                if (npc.Id == Id)
                {
                    npcToReturn = npc;
                }
            }

            //
            // the specified ID was not found in the kingdom
            // throw an exception
            //
            if (npcToReturn == null)
            {
                string feedbackMessage = $"The NPC ID {Id} does not exist in the current Kingdom.";
                throw new ArgumentException(Id.ToString(), feedbackMessage);
            }

            return npcToReturn;
        }

        public List<GameObject> GetGameObjectsByMapLocationId(int mapLocationId)
        {
            List<GameObject> gameObjects = new List<GameObject>();

            //
            // run through the game object list and grab all that are in the current map location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.MapLocationId == mapLocationId)
                {
                    gameObjects.Add(gameObject);
                }
            }

            return gameObjects;
        }

        /// <summary>
        /// get all NPC objects in a location
        /// </summary>
        /// <param name="mapLocationId">map location id</param>
        /// <returns>list of NPC objects</returns>
        public List<Npc> GetNpcsByMapLocationId(int mapLocationId)
        {
            List<Npc> npcs = new List<Npc>();

            //
            // run through the NPC object list and grab all that are in the current map location
            //
            foreach (Npc npc in _npcs)
            {
                if (npc.MapLocationID == mapLocationId)
                {
                    npcs.Add(npc);
                }
            }

            return npcs;
        }

        /// <summary>
        /// validate player object id number in current location
        /// </summary>
        /// <param name="playerObjectId"></param>
        /// <returns>is Id valid</returns>
        public bool IsValidPlayerObjectByLocationId(int playerObjectId, int currentMapLocation)
        {
            List<int> playerObjectIds = new List<int>();

            //
            // create a list of player object ids in current map location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.MapLocationId == currentMapLocation && gameObject is PlayerObject)
                {
                    playerObjectIds.Add(gameObject.Id);
                }

            }

            //
            // determine if the game object id is a valid id and return the result
            //
            if (playerObjectIds.Contains(playerObjectId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<PlayerObject> GetPlayerObjectsByMapLocationId(int mapLocationId)
        {
            List<PlayerObject> playerObjects = new List<PlayerObject>();

            //
            // run through the game object list and grab all that are in the current map location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.MapLocationId == mapLocationId && gameObject is PlayerObject)
                {
                    playerObjects.Add(gameObject as PlayerObject);
                }
            }

            return playerObjects;
        }



        #endregion
    }
}

