using UnityEngine;
public interface IInteractable
{
    string GetPrompt(); //返回显示文字

    void Interact(); //执行互动

    void HighLight();//高光

    void UnHighLight(); //非高光
}

