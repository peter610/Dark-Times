using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// base class for the player and all game characters
    /// </summary>
    public class Character
    {
        #region ENUMERABLES

        public enum RaceType
        {
            None,
            Human,
            Dwarven,
            Elven,
            Xoran
        }

        #endregion

        #region FIELDS

        private string _name;
        private int _age;
        private int _mapLocationID;
        private RaceType _race;
        private bool _isMale;
        
        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public int MapLocationID
        {
            get { return _mapLocationID; }
            set { _mapLocationID = value; }
        }

        public RaceType Race
        {
            get { return _race; }
            set { _race = value; }
        }

        public bool IsMale
        {
            get { return _isMale; }
            set { _isMale = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, RaceType race, int mapLocationID)
        {
            _name = name;
            _race = race;
            _mapLocationID = mapLocationID;
        }

        #endregion

        #region METHODS



        #endregion
    }
}
