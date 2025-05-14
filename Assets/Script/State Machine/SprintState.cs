using UnityEngine;

public class SprintState : StateMachine
{
    public SprintState(PlayerController _player) : base(_player) { }

    public override void Enter()
    {
        // player.ProcessMove();
        Debug.Log("SprintState");
        animator.SetFloat(player.animation_blend_name, player.TarGetSpeed());
    }

    public override void Exit()
    {
        Debug.Log("Exit SprintState");
    }
    public override void Update()
    {
        if (!player.CheckSprintInput())
        {
            if (!player.CheckMoveInput())
            {
                player.SetState(new IdleState(this.player));
            }
            player.SetState(new WalkState(this.player));
        }
        if (player.CheckJumpInput()) player.SetState(new JumpState(this.player));
        player.ProcessMove(player.TarGetSpeed());
    }
}
