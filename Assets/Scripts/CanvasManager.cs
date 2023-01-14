using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private Text lockText; //Lock�� Text ������Ʈ
    [SerializeField] private Text keyText; //Key�� Text ������Ʈ
    [SerializeField] private Text lockPlusKeyText; //Lock + Key�� Text ������Ʈ

    private void Update()
    {
        /* �ؽ�Ʈ ���� */
        lockText.text = "<color=\"#FFFF80\">Lock </color>: " + AntiCheatVariable.varLock;
        keyText.text = "<color=\"#FFFF80\">Key</color> : " + AntiCheatVariable.varKey;
        lockPlusKeyText.text = "<color=\"#FF8000\">Lock + Key</color> : " + (AntiCheatVariable.varLock + AntiCheatVariable.varKey);
    }

    /* InputField�� �Է��� ����Ǿ��� �� ����Ǵ� �Լ� */
    public void OnEndEdit(string value)
    {
        if (int.TryParse(value, out int newValue))
        {
            AntiCheatVariable.var = newValue;
        }
    }
}