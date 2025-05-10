using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlayerTeleport;
    void OnTriggerEneter()
    {
        Player.transform.position = PlayerTeleport.transform.position;
    }
}
