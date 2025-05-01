using UnityEngine;

public class Player_Fight : MonoBehaviour
{
    public FightStat Player;
    public FightStat Enemy;

    //Player Attack
    void Update()
    {
        Enemy.TakeDamage(Player.damage);
    }
}
