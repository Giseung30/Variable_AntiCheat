using UnityEngine;
using System.Collections;

public class AntiCheatVariable : MonoBehaviour
{
    [Header("Definition")]
    private static readonly int minKeyValue = -100000000; //최소 Key 값
    private static readonly int maxKeyValue = 100000000; //최대 Key 값

    public static int var
    {
        get
        {
            return varLock + varKey;
        }
        set
        {
            varLock = value - varKey;
        }
    } //참조 변수
    public static int varLock; //Lock
    public static int varKey; //Key
    private static int changedVarKey
    {
        set
        {
            int temp = var; //기존 값 임시 저장
            varKey = value; //Key 변경
            var = temp; //기존 값 복구
        }
    } //변경할 Key

    [Header("Cache")]
    private static readonly WaitForSeconds keyChangeInterval = new WaitForSeconds(2f); //Key 갱신 간격

    private void Start()
    {
        StartCoroutine(ChangeKey());
    }

    /* Key를 주기적으로 갱신하는 코루틴 함수 */
    private IEnumerator ChangeKey()
    {
        while (true)
        {
            yield return keyChangeInterval; //Key 갱신 대기

            changedVarKey = Random.Range(minKeyValue, maxKeyValue); //Key 갱신
        }
    }
}