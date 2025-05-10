using UnityEngine;

public class Player_Fight : MonoBehaviour
{
    public FightStat Player;
    public FightStat Enemy;

    //Player Attack
    void OnTriggerEnter()
    {
        //Player Attack

        if (Input.GetKey(KeyCode.Mouse0))
        {
            GetComponent<Animator>().Play("Fight");
            Enemy.TakeDamage(Player.damage);
        }
        //Player Dodge

    }
}
