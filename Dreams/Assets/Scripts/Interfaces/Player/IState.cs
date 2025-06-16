using UnityEngine.InputSystem;

public interface IState
{
    public EAnimationState animationState {  get; set; }
    public InputActionReference inputState { get; set; }
    public void inti();
    public void IEnable();
    public void IDisable();
}

public enum EAnimationState
{
    Walk,
    Look,
    Idel,
    Jump,
    Attack,
    Intractive
}
