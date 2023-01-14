using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private Text lockText; //Lock의 Text 컴포넌트
    [SerializeField] private Text keyText; //Key의 Text 컴포넌트
    [SerializeField] private Text lockPlusKeyText; //Lock + Key의 Text 컴포넌트

    private void Update()
    {
        /* 텍스트 갱신 */
        lockText.text = "<color=\"#FFFF80\">Lock </color>: " + AntiCheatVariable.varLock;
        keyText.text = "<color=\"#FFFF80\">Key</color> : " + AntiCheatVariable.varKey;
        lockPlusKeyText.text = "<color=\"#FF8000\">Lock + Key</color> : " + (AntiCheatVariable.varLock + AntiCheatVariable.varKey);
    }

    /* InputField의 입력이 종료되었을 때 실행되는 함수 */
    public void OnEndEdit(string value)
    {
        if (int.TryParse(value, out int newValue))
        {
            AntiCheatVariable.var = newValue;
        }
    }
}