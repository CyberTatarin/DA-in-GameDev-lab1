# РАЗРАБОТКА ИГРОВЫХ СЕРВИСОВ
Отчет по лабораторной работе #6 выполнил(а):
- Шайханов Марат Артурович
- РИ300019
Отметка о выполнении заданий (заполняется студентом):

| Задание | Выполнение | Баллы |
| ------ | ------ | ------ |
| Задание 1 | * | 60 |
| Задание 2 | # | 20 |
| Задание 3 | * | 20 |

знак "*" - задание выполнено; знак "#" - задание не выполнено;

Работу проверили:
- к.т.н., доцент Денисов Д.В.
- к.э.н., доцент Панов М.А.
- ст. преп., Фадеев В.О.

[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

## Цель работы
Cоздание интерактивного приложения с рейтинговой системой пользователя и интеграция игровых сервисов в готовое приложение.

## Задание 1
### Используя видео-материалы практических работ 1-5 повторить реализацию приведенного ниже функционала:
1. Практическая работа «Интеграция баннерной рекламы»
2. Практическая работа «Интеграция видеорекламы»
3. Практическая работа «Показ видеорекламы пользователю за вознаграждение»
4. Практическая работа «Создание внутриигрового магазина»
5. Практическая работа «Система антиблокировки рекламы»

### Интеграция баннерной рекламы

Заполнил страницу приложения до 86%, но мне до сих пор не прислали письмо 
с подтверждением для открытия рекламных блоков в яндекс консоли(.
![image](https://user-images.githubusercontent.com/94743111/208495628-5637c00e-102d-4db1-b1be-66dd6bbe4aaa.png)


###Сюда я добавляю id рекламного блока YG.
![image](https://user-images.githubusercontent.com/94743111/208494650-ab1c554f-40f3-4fca-b3cd-526329fbc37e.png)

Затем добавляю код показа рекламы после проигрыша и при запуске игры.
```c#
YandexGame.RewVideoShow(0);
```
Ставлю паузу при показе рекламы на скрипте "ViewingAdsYG".
---
Добавляю на сцену новый объект со скриптом:
```c#
using UnityEngine;
using YG;

public class AdRewardManager : MonoBehaviour
{
    public void OpenAd() => YandexGame.RewVideoShow(0);

    private void OnEnable() => YandexGame.CloseVideoEvent += OnReward;

    private void OnDisable() => YandexGame.CloseVideoEvent -= OnReward;

    private void OnReward(int id) => Debug.Log("Player rewarded!");
}
```
---

Добавляю в главное меню кнопку с наградами:
![image](https://user-images.githubusercontent.com/94743111/208496212-947815ca-0feb-491b-8d36-a471a08970ac.png)

---
Ставлю флажок проверки на адблок.
![image](https://user-images.githubusercontent.com/94743111/208497252-210a3dae-ba78-4bb6-a504-d60dcff7526a.png)

Для лидербордов нам нужна такая строчка кода.

```c#
YandexGame.NewLeaderboardScores("BestPlayerScore", int.Parse(scoreGT.text));
```
В яндекс консоли разработчика ставим флажок лидербордов и меняем настройки в соответствующем разделе.

<img src="https://github.com/CyberTatarin/DA-in-GameDev-lab1/blob/main/lab5/screenshots/lead.png">

<img src="https://github.com/CyberTatarin/DA-in-GameDev-lab1/blob/main/lab5/screenshots/leader.png">

---

Достижения.
Код из метода UserSave:
```c#
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
```

https://user-images.githubusercontent.com/94743111/206452890-49f00ed7-c75e-4d2d-8145-9d88079ee489.mp4

---

## Задание 2
### Не сделал.
<img src="https://media.giphy.com/media/vFKqnCdLPNOKc/giphy.gif" width="40" height="40" />


## Задание 3
### Предложить наиболее подходящий на ваш взгляд способ монетизации игры D.Picker. Дать развернутый ответ с комментариями.
Цель в игре - набрать как можно больше очков, исходя из этого можно сделать платные модификаторы превращающие каждое пойманное яйцо в 2,3,5 и т.д. очков.
Также можно добавить одноразовые предметы с различными эффектами: замедление времени, увеличенные модельки щита или яиц, режим бессмертия.
Внутриигровые покупки сделать преимущественно за игровую валюту, чтобы пользователь более лояльно реагировал на цену. Количество покупаемой игровой валюты сделать 
немного больше чем стоимость предметов, чтобы после покупки предмета игрок склонялся к докупке валюты, видя в этом выгоду.
## Выводы

Я познакомился с плагином YG и изучил способы мнетизации игры.

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**

