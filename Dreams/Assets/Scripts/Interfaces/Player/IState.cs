using UnityEngine.InputSystem;

public interface IState
{
    public InputActionReference inputState { get; set; }
    public void inti();
    public void IEnable();
    public void IDisable();
}

public enum EAnimationState
{
    Walk,
    Idel,
    Jump,
    Attack,
    Intractive
}
