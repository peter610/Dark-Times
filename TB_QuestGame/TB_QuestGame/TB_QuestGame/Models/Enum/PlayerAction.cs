using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// enum of all possible player actions
    /// </summary>
    public enum PlayerAction
    {
        None,
        MissionSetup,
        LookAround,
        LookAt,
        PickUp,
        PutDown,
        Inventory,
        Travel,
        PlayerInfo,
        PlayerLocationsVisited,
        ListMapLocations,
        ListGameObjects,
        AdminMenu,
        ReturnToMainMenu,
        Exit
    }
}
