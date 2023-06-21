# In_the_shadows (3D-игра-головоломка)
Учебное задание школы программирования Ecole 42.

Игра для Windows, Linux, MacOS. 
Разработана в unity3D(С#)

![image](https://user-images.githubusercontent.com/51932861/188352402-e4095242-5d89-4d3e-aef0-7c9cab6f94da.png)

Игра головоломка по мотивам мобильной игры shadowmatic. Игрок должен менять положение и поворачивать один или несколько объектов таким образом, чтобы их тень образовала нужный предмет.

#### Запуска игры на пк:
1. Ознакомиться с управлением: файл "управление.md"
2. Скачайте папку _Play_in_game
3. В папке _Play_in_game зайдити в папку с нужной ОС, далее выбирите папку с нужной ОС:
   - В папке для Windows: запустить файл "In_the_shadows.exe"
   - В папке для Linux -> выбрать папку с желаемым разрешением -> запустить файл "linux_gconger_windowed.x86_64"
   - В папке для MacOS: запустить файл "In_the_shadows_gconger"

# Main Menu

![image](https://user-images.githubusercontent.com/51932861/188350755-334bb066-6fe4-4f9e-9e99-3aa0e6fcbfdc.png)

# Два режима игры:
 ## 1. PLAY - Обычный режим:
 - Уровни открываются последовательно, после прохлждения текущего уровня.
 - Пройденный уровень сохраняется(Данные, сохраненяются на локальном диске в формате json)
 - Используя кнопку RESET, можно сбросить сохраненные пройденные уровни

![image](https://user-images.githubusercontent.com/51932861/188350858-5f747168-c13d-4f4b-aee6-564d25d5249c.png)

 ## 2. Training - Тестовый режим (режим чита):
 - Неограниченный доступ ко всем уровням
  
![image](https://user-images.githubusercontent.com/51932861/188354351-84ee2698-89b1-4e83-a3d6-f8811905b038.png)

#### Выбор уровня в обычном режим:
 - Анимация при разблокировке уровня
 - Анимация выбора при выборе уровня
 - Для каждого уровня отображается текстовая подсказка
 - Статус соответствующего уровня :
      красный: Заблокирован
      зеленый: Доступен

# Уровни сложности
 1. Вращение предмета только по горизонтали (управление по горизонтали: зажатая ПКМ + клавиша ←/→)
 2. Вращение предмета и по горизонтали и вертикали (управление по вертикали: зажатая ПКМ +  клавиша ↑/↓)
 3. Горизонтальные и вертикальные вращения нескольких объектов по очереди и изменение их положения в пространстве (переключение на другой объект по нажатию на клавишу spase)

![image](https://user-images.githubusercontent.com/51932861/188352887-32d14099-d094-4ac7-aba7-0247ef8b6dc0.png)

Объекты отбрасывает тень и когда тень при вращении/перемещении объектов будет похожа на предмет задуманный автором игры, то тогда игра остановится. Объект автоматически докрутиться до идеальной формы предмета, и следующий уровень будет доступен для прохождения. Если уровень пройден: перейдите в меню выбора уровня с помощью кнопки "WIN".
