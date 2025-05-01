using UnityEngine;

public class Player_Fight : MonoBehaviour
{
    public FightStat Player;
    public FightStat Enemy;
    public void PlayerAttack()
    {
        Enemy.TakeDamage(Player.damage);
    }
}
