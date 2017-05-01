using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class MapLocation
    {
        #region FIELDS

        private string _commonName;
        private int _mapLocationID; // must be a unique value for each object
        private string _kingdomLocation;
        private string _description;
        private string _generalContents;
        private bool _accessible;
        private int _experiencePoints;

        #endregion


        #region PROPERTIES

        public string CommonName
        {
            get { return _commonName; }
            set { _commonName = value; }
        }

        public int MapLocationID
        {
            get { return _mapLocationID; }
            set { _mapLocationID = value; }
        }

        public string KingdomLocation
        {
            get { return _kingdomLocation; }
            set { _kingdomLocation = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string GeneralContents
        {
            get { return _generalContents; }
            set { _generalContents = value; }
        }

        public bool Accessable
        {
            get { return _accessible; }
            set { _accessible = value; }
        }

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
        }

        #endregion


        #region CONSTRUCTORS



        #endregion


        #region METHODS



        #endregion
    }
}
