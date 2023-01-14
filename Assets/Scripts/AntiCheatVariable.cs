using UnityEngine;
using System.Collections;

public class AntiCheatVariable : MonoBehaviour
{
    [Header("Definition")]
    private static readonly int minKeyValue = -100000000; //�ּ� Key ��
    private static readonly int maxKeyValue = 100000000; //�ִ� Key ��

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
    } //���� ����
    public static int varLock; //Lock
    public static int varKey; //Key
    private static int changedVarKey
    {
        set
        {
            int temp = var; //���� �� �ӽ� ����
            varKey = value; //Key ����
            var = temp; //���� �� ����
        }
    } //������ Key

    [Header("Cache")]
    private static readonly WaitForSeconds keyChangeInterval = new WaitForSeconds(2f); //Key ���� ����

    private void Start()
    {
        StartCoroutine(ChangeKey());
    }

    /* Key�� �ֱ������� �����ϴ� �ڷ�ƾ �Լ� */
    private IEnumerator ChangeKey()
    {
        while (true)
        {
            yield return keyChangeInterval; //Key ���� ���

            changedVarKey = Random.Range(minKeyValue, maxKeyValue); //Key ����
        }
    }
}