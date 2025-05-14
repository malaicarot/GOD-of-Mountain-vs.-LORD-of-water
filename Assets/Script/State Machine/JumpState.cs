using UnityEngine;

public class JumpState : StateMachine
{
    public JumpState(PlayerController _player) : base(_player) { }


    public override void Enter()
    {
        Debug.Log("JumpState");

    }

    public override void Exit()
    {
        Debug.Log("Exit JumpState");
    }

    public override void Update()
    {
        player.ProcessJump();
        if (player.CheckSprintInput())
        {
            player.SetState(new SprintState(this.player));
        }
        if (player.CheckMoveInput())
        {
            player.SetState(new WalkState(this.player));
        }
        player.SetState(new IdleState(this.player));
    }
}
