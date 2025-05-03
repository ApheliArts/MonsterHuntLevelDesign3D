using UnityEngine;

public class Player_Fight : MonoBehaviour
{
    public FightStat Player;
    public FightStat Enemy;

    //Player Attack
    void Update()
    {
        //Player Attack
        Enemy.TakeDamage(Player.damage);
        //Player Dodge

    }
}
