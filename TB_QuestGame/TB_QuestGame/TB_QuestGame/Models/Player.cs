using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Player : Character
    {
        #region ENUMERABLES

        public enum PlayerProfession
        {
            None,
            Blacksmith,
            Farmer,
            Fisherman,
            Butcher
        }

        #endregion

        #region FIELDS

        private PlayerProfession _profession;
        private bool _hasPet;
        private string _petName;
        private int _petAge = 0;
        private int _experiencePoints;
        private int _health;
        private int _lives;
        private List<int> _mapLocationsVisited;
        private List<PlayerObject> _inventory;
        
        #endregion

        #region PROPERTIES

        public PlayerProfession Profession
        {
            get { return _profession; }
            set { _profession = value; }
        }

        public bool HasPet
        {
            get { return _hasPet; }
            set { _hasPet = value; }
        }

        public string PetName
        {
            get { return _petName; }
            set { _petName = value; }
        }

        public int PetAge
        {
            get { return _petAge; }
            set { _petAge = value; }
        }

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }

        public List<int> MapLocationsVisited
        {
            get { return _mapLocationsVisited; }
            set { _mapLocationsVisited = value; }
        }

        public List<PlayerObject> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            _mapLocationsVisited = new List<int>();
            _inventory = new List<PlayerObject>();
        }

        public Player(string name, RaceType race, int mapLocationID) : base(name, race, mapLocationID)
        {
            _mapLocationsVisited = new List<int>();
            _inventory = new List<PlayerObject>();
        }

        public Player(string petName, PlayerProfession profession, int petAge)
        {
            _petName = petName;
            _profession = profession;
            _petAge = petAge;
        }

        /*public Player(string name, int age, RaceType race) : base(name, age, race)
        {

        }*/

        #endregion

        #region METHODS

        public bool HasVisited(int _mapLocationID)
        {
            if (MapLocationsVisited.Contains(_mapLocationID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
