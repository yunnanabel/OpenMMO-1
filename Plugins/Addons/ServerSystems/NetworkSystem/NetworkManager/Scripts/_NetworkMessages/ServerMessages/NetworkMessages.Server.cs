//UPDATED MIRROR VERSION v13 to v42.2.8 BY DX4D
using System.Collections.Generic;
using OpenMMO.Network;
using OpenMMO;
using Mirror;

namespace OpenMMO.Network
{

    // -----------------------------------------------------------------------------------
    // ServerMessageResponse
    // @Server -> @Client
    // -----------------------------------------------------------------------------------
    /// <summary>
    /// Public partial Class <c>ServerMessageResponse</c> inherits from Mirror.MessageBase.
    /// Sent from Server to Client.
    /// Server Message response containing boolean dictating success, a text message, and a boolean dictating wether the message causes disconnection.
    /// </summary>
    /*public interface ServerResponse : NetworkMessage
    {
		bool success { get; set; }
		string text { get; set; }
        bool causesDisconnect { get; set; }
    }*/
    // ================================= MESSAGES AUTH ===================================

    // -----------------------------------------------------------------------------------
    // ServerMessageResponseUserDelete
    // @Server -> @Client
    // -----------------------------------------------------------------------------------
    /// <summary>
    /// Public Partial class <c>ServerResponseError</c> inherits <c>ServerResponse</c>.
    /// Sent from Server to Client.
    /// </summary>
    public partial struct ServerResponseError : ServerResponse
    {
        bool _success;
        public bool success { get { return _success; } set { _success = value; } }

        string _text;
        public string text { get { return _text; } set { _text = value; } }

        bool _causesDisconnect;
        public bool causesDisconnect { get { return _causesDisconnect; } set { _causesDisconnect = value; } }
    }

    // ================================= MESSAGES AUTH ===================================

    // -----------------------------------------------------------------------------------
    // ServerMessageResponseAuth
    // @Server -> @Client
    // -----------------------------------------------------------------------------------
    /// <summary>
    /// Public Partial class <c>ServerMessageResponseAuth</c> inherits <c>ServerMessageResponse</c>.
    /// Sent from Server to Client.
    /// </summary>
    public partial struct ServerResponseAuth : ServerResponse
    {
        bool _success;
        public bool success { get { return _success; } set { _success = value; } }

        string _text;
        public string text { get { return _text; } set { _text = value; } }

        bool _causesDisconnect;
        public bool causesDisconnect { get { return _causesDisconnect; } set { _causesDisconnect = value; } }
    }

    // ================================== MESSAGES USER ==================================


    // -----------------------------------------------------------------------------------
    // ServerMessageResponseUserPlayerPreviews
    // @Server -> @Client
    // -----------------------------------------------------------------------------------
    /// <summary>
    /// Public Partial class <c>ServerMessageResponseUserPlayerPreviews</c> inherits <c>ServerMessageResponse</c>.
    /// Sent from Server to Client.
    /// Contains an array of <c>PlayerPreview</c>(s) and the max player number.
    /// Also contains a <c>LoadPlayerPreviews</c> method.
    /// </summary>
    public partial struct ServerResponseUserPlayerPreviews : ServerResponse
    {
        bool _success;
        public bool success { get { return _success; } set { _success = value; } }

        string _text;
        public string text { get { return _text; } set { _text = value; } }

        bool _causesDisconnect;
        public bool causesDisconnect { get { return _causesDisconnect; } set { _causesDisconnect = value; } }

        public PlayerPreview[] players;
		public int maxPlayers;

        // -------------------------------------------------------------------------------
        // LoadPlayerPreviews
        // -------------------------------------------------------------------------------
        /// <summary>
        /// Public method <c>LoadPlayerPreviews</c> located inside <c>ServerMessageResponseUserPlayerPreviews</c>.
        /// Loads an array of players  previews from a list of players
        /// </summary>
        /// <param name="_players"></param>
        public void LoadPlayerPreviews(List<PlayerPreview> _players)
		{
			players = new PlayerPreview[_players.Count];
			players = _players.ToArray();
		}
	}

    // -----------------------------------------------------------------------------------
    // ServerMessageResponseUserLogin
    // @Server -> @Client
    // -----------------------------------------------------------------------------------
    /// <summary>
    /// Public Partial class <c>ServerMessageResponseUserLogin</c> inherits <c>ServerMessageResponseUserPlayerPreviews</c>.
    /// Sent from Server to Client.
    /// Based on ServerMessageResponseUserPlayerPreviews. Contains only inherited functionality.
    /// </summary>
    public partial struct ServerResponseUserLogin : ServerResponse
    {
        bool _success;
        public bool success { get { return _success; } set { _success = value; } }

        string _text;
        public string text { get { return _text; } set { _text = value; } }

        bool _causesDisconnect;
        public bool causesDisconnect { get { return _causesDisconnect; } set { _causesDisconnect = value; } }

        public PlayerPreview[] players;
        public int maxPlayers;

        // -------------------------------------------------------------------------------
        // LoadPlayerPreviews
        // -------------------------------------------------------------------------------
        /// <summary>
        /// Public method <c>LoadPlayerPreviews</c> located inside <c>ServerMessageResponseUserPlayerPreviews</c>.
        /// Loads an array of players  previews from a list of players
        /// </summary>
        /// <param name="_players"></param>
        public void LoadPlayerPreviews(List<PlayerPreview> _players)
        {
            players = new PlayerPreview[_players.Count];
            players = _players.ToArray();
        }
    }

    // -----------------------------------------------------------------------------------
    // ServerMessageResponseUserRegister
    // @Server -> @Client
    // -----------------------------------------------------------------------------------
    /// <summary>
    /// Public Partial class <c>ServerMessageResponseUserRegister</c> inherits <c>ServerMessageResponse</c>.
    /// Sent from Server to Client.
    /// </summary>
    public partial struct ServerResponseUserRegister : ServerResponse
    {
        bool _success;
        public bool success { get { return _success; } set { _success = value; } }

        string _text;
        public string text { get { return _text; } set { _text = value; } }

        bool _causesDisconnect;
        public bool causesDisconnect { get { return _causesDisconnect; } set { _causesDisconnect = value; } }
    }

    // -----------------------------------------------------------------------------------
    // ServerMessageResponseUserDelete
    // @Server -> @Client
    // -----------------------------------------------------------------------------------
    /// <summary>
    /// Public Partial class <c>ServerMessageResponseUserDelete</c> inherits <c>ServerMessageResponse</c>.
    /// Sent from Server to Client.
    /// </summary>
    public partial struct ServerResponseUserDelete : ServerResponse
    {
        bool _success;
        public bool success { get { return _success; } set { _success = value; } }

        string _text;
        public string text { get { return _text; } set { _text = value; } }

        bool _causesDisconnect;
        public bool causesDisconnect { get { return _causesDisconnect; } set { _causesDisconnect = value; } }
    }

    // -----------------------------------------------------------------------------------
    // ServerMessageResponseUserChangePassword
    // @Server -> @Client
    // -----------------------------------------------------------------------------------
    /// <summary>
    /// Public Partial class <c>ServerMessageResponseUserChangePassword</c> inherits <c>ServerMessageResponse</c>.
    /// Sent from Server to Client.
    /// </summary>
    public partial struct ServerResponseUserChangePassword : ServerResponse
    {
        bool _success;
        public bool success { get { return _success; } set { _success = value; } }

        string _text;
        public string text { get { return _text; } set { _text = value; } }

        bool _causesDisconnect;
        public bool causesDisconnect { get { return _causesDisconnect; } set { _causesDisconnect = value; } }
    }

    // -----------------------------------------------------------------------------------
    // ServerMessageResponseUserConfirm
    // @Server -> @Client
    // -----------------------------------------------------------------------------------
    /// <summary>
    /// Public Partial class <c>ServerMessageResponseUserConfirm</c> inherits <c>ServerMessageResponse</c>.
    /// Sent from Server to Client.
    /// </summary>
    public partial struct ServerResponseUserConfirm : ServerResponse
    {
        bool _success;
        public bool success { get { return _success; } set { _success = value; } }

        string _text;
        public string text { get { return _text; } set { _text = value; } }

        bool _causesDisconnect;
        public bool causesDisconnect { get { return _causesDisconnect; } set { _causesDisconnect = value; } }
    }

    // ================================ MESSAGES PLAYER ==================================

    // -----------------------------------------------------------------------------------
    // ServerMessageResponsePlayerLogin
    // @Server -> @Client
    // -----------------------------------------------------------------------------------
    /// <summary>
    /// Public Partial class <c>ServerMessageResponsePlayerLogin</c> inherits <c>ServerMessageResponse</c>.
    /// Sent from Server to Client.
    /// </summary>
    public partial struct ServerResponsePlayerLogin : ServerResponse
    {
        bool _success;
        public bool success { get { return _success; } set { _success = value; } }

        string _text;
        public string text { get { return _text; } set { _text = value; } }

        bool _causesDisconnect;
        public bool causesDisconnect { get { return _causesDisconnect; } set { _causesDisconnect = value; } }
    }

    // -----------------------------------------------------------------------------------
    // ServerMessageResponsePlayerRegister
    // @Server -> @Client
    // -----------------------------------------------------------------------------------
    /// <summary>
    /// Public Partial class <c>ServerMessageResponsePlayerRegister</c> inherits <c>ServerMessageResponse</c>.
    /// Sent from Server to Client.
    /// </summary>
    public partial struct ServerResponsePlayerRegister : ServerResponse
    {
        bool _success;
        public bool success { get { return _success; } set { _success = value; } }

        string _text;
        public string text { get { return _text; } set { _text = value; } }

        bool _causesDisconnect;
        public bool causesDisconnect { get { return _causesDisconnect; } set { _causesDisconnect = value; } }

        public string playername;
	}

    // -----------------------------------------------------------------------------------
    // ServerMessageResponsePlayerDelete
    // @Server -> @Client
    // -----------------------------------------------------------------------------------
    /// <summary>
    /// Public Partial class <c>ServerMessageResponsePlayerDelete</c> inherits <c>ServerMessageResponse</c>.
    /// Sent from Server to Client.
    /// </summary>
    public partial struct ServerResponsePlayerDelete : ServerResponse
    {
        bool _success;
        public bool success { get { return _success; } set { _success = value; } }

        string _text;
        public string text { get { return _text; } set { _text = value; } }

        bool _causesDisconnect;
        public bool causesDisconnect { get { return _causesDisconnect; } set { _causesDisconnect = value; } }
    }

	// -------------------------------------------------------------------------------
	
}