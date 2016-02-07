using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkCommunicator : NetworkBehaviour {
	public Transform transform;
	[SyncVar] Transform serverState;

	void Awake () {
		InitState();
	}

	void Start () {
		
	}

	void Update () {
		if (isLocalPlayer) {			
			CmdMove();
		}
		SyncState ();
	}

	[Command] void CmdMove() {
		serverState = transform;
	}

	[Server] void InitState () {
		serverState = transform;
	}

	void SyncState() {
		this.transform = serverState;
	}

}
