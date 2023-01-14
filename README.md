# 변수 안티치트

## 🖥 소개
+ 간단히 메모리 변조를 방지하기 위해 구현한 **변수 은닉 모듈**이다.

## 📖 개요
+ 변수는 런타임에 무작위로 할당한 메모리에 값을 저장한다.
+ 값이 변경될 때마다, 조건에 해당하는 **메모리 주소**를 찾아내어 범위를 좁혀가다보면 마침내 원하는 변수를 조작할 수 있게 된다.
+ 만약, 찾아낸 메모리 주소가 **화폐**나 **능력치** 등의 중요한 정보라면 피해가 크게 발생할 수 있다.

## ⚙ 테스트 환경
+ `Unity 2021.1.15f1`

## 🔍 원리
+ 두 개의 변수를 활용하여 암호화한다. (**Lock**, **Key**)
<div align="center">
  <img width="30%" height="30%" src="https://user-images.githubusercontent.com/60832219/212466177-bf696f35-a8b1-439d-b787-f7fa18d8afda.PNG"/>
</div>
  
+ 값을 참조하기 위해서는 두 변수를 더해야한다. (**Lock + Key**)
<div align="center">
  <img width="15%" height="15%" src="https://user-images.githubusercontent.com/60832219/212466304-b2300852-e33a-467c-aba5-e4ae2698d3b6.PNG"/>
</div>

+ 값을 변경하면 두 변수의 합이 변경되어야 하므로, Lock 변수를 변경한다. (**Lock = 새로운 값 - Key**)
<div align="center">
  <img width="30%" height="30%" src="https://user-images.githubusercontent.com/60832219/212466715-c738c634-d727-46f7-9f77-d6681e31c098.PNG"/>
</div>

+ 메모리 탐지를 막기 위해, 매 시간마다 Key 값을 무작위 갱신한다. (**Key = 무작위 값**)
<div align="center">
  <img width="30%" height="30%" src="https://user-images.githubusercontent.com/60832219/212467056-1431a0d3-b270-4d6f-b76d-d9ca4536d8d6.png"/>
</div>

- - -

<div align="center">
  <table border="0">
    <tr>
      <td align="center">
        <img width="100%" height="100%" src="https://user-images.githubusercontent.com/60832219/212467487-1a5750e8-d3a0-41c3-8e09-6975986ffa8f.gif"/>
      </td>
      <td align="center">
        <img width="100%" height="100%" src="https://user-images.githubusercontent.com/60832219/212467485-6de3ea54-7614-4676-ad1c-4fb2c5a2c39e.gif"/>
      </td>
    </tr>
    <tr>
      <td align="center">
        Key 갱신
      </td>
      <td align="center">
        값 변경
      </td>
    </tr>
  </table>
</div>

## ✔ 결과
+ 값을 온전히 변수에 저장하는 것이 아니므로, 직접적인 메모리 조작이 불가능하다.
+ 루팅된 기기에서도 게임치나 게임 가디언 등의 앱으로 변수 조작이 불가능하다.
+ 다만, 갱신 과정이 필요하기 때문에 성능 이슈가 발생하지 않도록 변수를 남발해서는 안된다.

<div align="center">
  <table border="0">
    <tr>
      <td align="center">
        <img width="100%" height="100%" src="https://user-images.githubusercontent.com/60832219/212467870-3412f3fa-d2d3-4b15-a061-8c224c9b2369.png"/>
      </td>
      <td align="center">
        <img width="100%" height="100%" src="https://user-images.githubusercontent.com/60832219/212467874-5f85fbd8-ac02-4e3e-96d9-e27332ec9ee4.png"/>
      </td>
    </tr>
    <tr>
      <td align="center">
        안티 치트 사용전
      </td>
      <td align="center">
        안티 치트 사용후
      </td>
    </tr>
  </table>
</div>

## 📃 스크립트
```C#
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
    private static int varLock; //Lock
    private static int varKey; //Key
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
```
