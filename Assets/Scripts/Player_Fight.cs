using UnityEngine;

public class Player_Fight : MonoBehaviour
{
    public FightStat Player;
    public FightStat Enemy;

    //Animation Code!!
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    //Player Attack
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            _animator.SetTrigger(name: "Attack");
        }
        //Player Attack
        Enemy.TakeDamage(Player.damage);
        //Player Dodge

    }
}
