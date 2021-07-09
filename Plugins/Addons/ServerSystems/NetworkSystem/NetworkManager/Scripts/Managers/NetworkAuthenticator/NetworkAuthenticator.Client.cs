//MIRROR UPDATE - VERSION v13 to v42.2.8 BY DX4D
using OpenMMO;
using OpenMMO.Network;
using OpenMMO.UI;
using OpenMMO.Zones;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections.Generic;
using Mirror;

namespace OpenMMO.Network
{

    // ===================================================================================
	// NetworkAuthenticator
	// ===================================================================================
    public partial class NetworkAuthenticator
    {
    	
    	[Header("Client Settings")]
    	public bool checkApplicationVersion = true;
    	[Range(0,99)]
    	public int connectDelayMin = 4;
    	[Range(0,99)]
    	public int connectDelayMax = 8;
    	[Range(1,999)]
    	public int connectTimeout = 999;
    	
    	[HideInInspector] public int connectDelay;
    	
        // -------------------------------------------------------------------------------
        // OnStartClient
        // @Client
		// -------------------------------------------------------------------------------
        /// <summary>
        /// Public override event <c>OnStartClient</c>.
        /// Event triggered on client start.
        /// This Event occurs on the client.
        /// The even registers the authentication event.
        /// </summary>
        public override void OnStartClient()
        {
            NetworkClient.RegisterHandler<ServerResponseAuth>(OnServerMessageResponseAuth, false);  
            
            this.InvokeInstanceDevExtMethods(nameof(OnStartClient)); //HOOK
        }

        // -------------------------------------------------------------------------------
        // OnClientAuthenticate
        // @Client
        // -------------------------------------------------------------------------------
        /// <summary>
        /// Public override event <c>OnClientAuthenticate</c>.
        /// This event is triggered upon requestion authentication.
        /// Invokes a authentication request to trigger.
        /// </summary>
        /// <param name="conn"></param>
        public override void OnClientAuthenticate() //FIX - MIRROR UPDATE - NetworkConnection conn parameter Replaced with NetworkClient.connection - DX4D
        {
        	if (GetComponent<ZoneManager>() != null && !GetComponent<ZoneManager>().GetAutoConnect)
        		Invoke(nameof(ClientAuthenticate), connectDelay);

            this.InvokeInstanceDevExtMethods(nameof(OnClientAuthenticate)); //HOOK //, conn); //FIX - MIRROR UPDATE - conn parameter is no longer passed through - it was replaced with NetworkClient.connection - DX4D
        }
        
		// -------------------------------------------------------------------------------
        // ClientAuthenticate
        // @Client -> @Server
		// -------------------------------------------------------------------------------
        /// <summary>
        /// Public Method <c>ClientAuthenticate</c>
        /// Sends a authentication request message from the client to the server.
        /// </summary>
		public void ClientAuthenticate()
		{

            ClientRequestAuth msg = new ClientRequestAuth
            {
                clientVersion = Application.version
            };

            NetworkClient.Send(msg);
            
            debug.LogFormat(this.name, nameof(ClientAuthenticate)); //DEBUG
		}

        // ========================== MESSAGE HANDLERS - AUTH ============================
        
        // -------------------------------------------------------------------------------
        /// <summary>
        /// Event <c>OnServerMessageResponseAuth</c>.
        /// Is triggered when the server returns a authentication response message.
        /// Either authenicates the client, disconnects the client and returns an error message if there is one. 
        /// If the authentication was succesful the client is readied.
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="msg"></param>
        //void OnServerMessageResponseAuth(NetworkConnection conn, ServerMessageResponseAuth msg) //REMOVED - MIRROR UPDATE - DX4D
        void OnServerMessageResponseAuth(ServerResponseAuth msg) //ADDED - MIRROR UPDATE - DX4D
        {
            NetworkConnection conn = NetworkClient.connection; //ADDED - MIRROR UPDATE - DX4D

        	// -- show popup if error message is not empty
        	if (!String.IsNullOrWhiteSpace(msg.text))
               	UIPopupConfirm.singleton.Init(msg.text);
    		
        	// -- disconnect and un-authenticate if anything went wrong
            if (msg.causesDisconnect)//!msg.success || 
            {
                conn.isAuthenticated = false;
                conn.Disconnect();
                NetworkManager.singleton.StopClient();
                
                debug.LogFormat(this.name, nameof(OnServerMessageResponseAuth), conn.Id(), "DENIED"); //DEBUG
            }
            
            // -- ready client
            if (msg.success)// && !msg.causesDisconnect
            {
            	CancelInvoke();
               	base.OnClientAuthenticated.Invoke(conn);
               	
               	UIWindowAuth.singleton.Hide();
               	UIWindowMain.singleton.Show();
               	
				debug.LogFormat(this.name, nameof(OnServerMessageResponseAuth), conn.Id(), "Authenticated"); //DEBUG
            }
        	
        }
        
        // -------------------------------------------------------------------------------
               
    }
}

// =======================================================================================