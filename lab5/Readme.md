# РАЗРАБОТКА ИГРОВЫХ СЕРВИСОВ
Отчет по лабораторной работе #5 выполнил(а):
- Шайханов Марат Артурович
- РИ300019
Отметка о выполнении заданий (заполняется студентом):

| Задание | Выполнение | Баллы |
| ------ | ------ | ------ |
| Задание 1 | * | 60 |
| Задание 2 | * | 20 |
| Задание 3 | # | 20 |

знак "*" - задание выполнено; знак "#" - задание не выполнено;

Работу проверили:
- к.т.н., доцент Денисов Д.В.
- к.э.н., доцент Панов М.А.
- ст. преп., Фадеев В.О.

[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

Структура отчета

- Данные о работе: название работы, фио, группа, выполненные задания.
- Цель работы.
- Задание 1.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Задание 2.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Задание 3.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Выводы.
- ✨Magic ✨

## Цель работы
Создание интерактивного приложения с рейтинговой системой пользователя и интеграция игровых сервисов в готовое приложение.

## Задание 1
### Используя видео-материалы практических работ 1-5 повторить реализацию приведенного ниже функционала:
- 1 Практическая работа «Интеграции авторизации с помощью Яндекс SDK».
- 2 Практическая работа «Сохранение данных пользователя на платформе Яндекс Игры».
- 3 Практическая работа «Сбор данных об игроке и вывод их в интерфейсе».
- 4 Практическая работа «Интеграция таблицы лидеров».
- 5  Практическая работа «Интеграция системы достижений в проект».

Сначала пишем скрипт для проверки данных YandexSDK. 
OnEnable, OnDisable для проверки и CheckSDK для проверки авторизации

```c#
using YG;
public class CheckConnectYG : MonoBehaviour
{
    
    private void OnEnable() => YandexGame.GetDataEvent += CheckSDK;
    private void OnDisable() => YandexGame.GetDataEvent -= CheckSDK;
        
    
    void Start()
    {
        if (YandexGame.SDKEnabled == true) {
            CheckSDK();
        }
    }

   public void CheckSDK()
   {
    if (YandexGame.auth == true)
    {
        Debug.Log("User is authorized");
    }
    else 
    {
        Debug.Log("User is not authorized");
        YandexGame.AuthDialog();
    }
   }
}
```

Создаём пустой объект на сцене и прикрепляем к нему наш скрипт. Собираем билд и идём тестировать в браузер. Не забываем поставить флажок авторизации и лидербордов.
Консоль выдаёт такой ответ.

<img src="https://github.com/CyberTatarin/DA-in-GameDev-lab1/blob/main/lab5/screenshots/%D1%8412.jpg">

Если выйти из аккаунта, то нам поступит предложение авторизации.

<img src="https://github.com/CyberTatarin/DA-in-GameDev-lab1/blob/main/lab5/screenshots/auth.png">

---

Теперь напишим скрипт для сохранения пользовательских данных.
Ниже обновленный скрипт DragonPicker.cs

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using TMPro;

public class DragonPicker : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += GetLoadSave;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoadSave;

    public GameObject energyShieldPrefab;
    public int numEnergyShield = 3;
    public float energyShieldBottomY = -6f;
    public float energyShieldRadius = 1.5f;
    public TextMeshProUGUI scoreGT;
    private TextMeshProUGUI playerName;
    public List<GameObject> shieldList;
    // Start is called before the first frame update
    void Start()
    {
        if (YandexGame.SDKEnabled == true)
        {
            GetLoadSave();
        }
        shieldList = new List<GameObject>();
        

        for (int i = 1; i <= numEnergyShield; i++){
            GameObject tShieldGo = Instantiate<GameObject>(energyShieldPrefab);
            tShieldGo.transform.position = new Vector3(0, energyShieldBottomY, 0);
            tShieldGo.transform.localScale = new Vector3(1*i, 1*i, 1*i);
            shieldList.Add(tShieldGo);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DragonEggDestroyed(){
        GameObject[] tDragonEggArray = GameObject.FindGameObjectsWithTag("Dragon Egg");
        foreach (GameObject tGO in tDragonEggArray){
            Destroy(tGO);
        }
        int shieldIndex = shieldList.Count - 1;
        GameObject tShieldGo = shieldList[shieldIndex];
        shieldList.RemoveAt(shieldIndex);
        Destroy(tShieldGo);

        if (shieldList.Count == 0){
            GameObject scoreGO = GameObject.Find("Score");
            scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
            string[] achivList;
            achivList = YandexGame.savesData.achiveMent;
            achivList[0] = "Береги щиты!";
            UserSave(int.Parse(scoreGT.text),YandexGame.savesData.bestScore, achivList);
            YandexGame.NewLeaderboardScores("TOPPlayerScore", int.Parse(scoreGT.text));
            SceneManager.LoadScene("_0Scene");
            GetLoadSave();
        }
    }
    public void GetLoadSave()
    {
        Debug.Log(YandexGame.savesData.score);
        GameObject playerNamePrefabGUI = GameObject.Find("PlayerName");
        playerName = playerNamePrefabGUI.GetComponent<TextMeshProUGUI>();
        playerName.text = YandexGame.playerName;
    }

    public void UserSave(int currentScore, int currentBestScore, string[] currenAchiv)
    {
        YandexGame.savesData.score = currentScore;
        if (currentScore > currentBestScore)
        {
             YandexGame.savesData.bestScore = currentScore;   
        }
        YandexGame.savesData.achiveMent = currenAchiv;
        YandexGame.SaveProgress();
    }
}

```

При выгрузке билда не забываем про флажок облачные сохранения.

---

Для лидербордов нам нужна такая строчка кода.

```c#
YandexGame.NewLeaderboardScores("BestPlayerScore", int.Parse(scoreGT.text));
```
В яндекс консоли разработчика ставим флажок лидербордов и меняем настройки в соответствующем разделе.

<img src="https://github.com/CyberTatarin/DA-in-GameDev-lab1/blob/main/lab5/screenshots/lead.png">

<img src="https://github.com/CyberTatarin/DA-in-GameDev-lab1/blob/main/lab5/screenshots/leader.png">

---

Достижения

https://user-images.githubusercontent.com/94743111/206452890-49f00ed7-c75e-4d2d-8145-9d88079ee489.mp4

---

## Задание 2
### Описать не менее трех дополнительных функций Яндекс SDK, которые могут быть интегрированы в игру. 


Сборку можно осуществлять под разные платформы: Windows, Mac, Linux, PlayStation, Android, даже на удалённый сервак. Для изменения платформы следуем 
"File -> Build Settings -> Platform" и выбираем желаемую. Иногда требуется ковыряться в настройках для фикса ошибок(у меня например вылезла ошибка рендринга
Color Space* ). Следует разделять систему обработки ввода, так как у разных платформ разные способы ввода. 


## Задание 3
### Не сделал
<img src="https://media.giphy.com/media/vFKqnCdLPNOKc/giphy.gif" width="40" height="40" />


## Выводы

Я научился писать некоторые скрипты для объектов на движке Unity.

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**
