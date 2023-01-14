# 변수 안티치트

# 🖥 소개
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
