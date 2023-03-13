# In_the_shadows

###Игра для desktop версий ос написанная в unity3D на С#

###Описание игры:
Игра головоломка по мотивам мобильной игры shadowmatic. 
Игрок должен менять положение и поворачивать один или несколько объектов таким образом, чтобы их тень образовала нужный предмет.

###Как запустить игру у себя на ПК:
Для тестирования игры необходимо скачать папку _Play_in_game. Далее нужно зайти в одну из папкок предназначенных для разных ОС(windows, linux, Mac):
1) in_the_shadows_gconger_linux

![image](https://user-images.githubusercontent.com/51932861/224725065-3286a5c2-a43b-49fe-84c8-92dd5c26eafe.png)


42 school project: 3D Puzzle game. Single player shadow puppet game. Shadowmatic like on what?
Game developed with Unity (C#).

# Main Menu

![image](https://user-images.githubusercontent.com/51932861/188350755-334bb066-6fe4-4f9e-9e99-3aa0e6fcbfdc.png)

## Two play modes:
  ### 1.Normal mode:
    - First level unlocked, by finishing a level you unlock the next one
    - The completed level is saved
    - Using the RESET button, it is possible to reset the progress of unlocked levels
  ### 2.Test mode (Cheat mode):
    - Unlimited access to all levels
    - Easy access to test each models validations
![image](https://user-images.githubusercontent.com/51932861/188354351-84ee2698-89b1-4e83-a3d6-f8811905b038.png)

## Data saved on local disk, in json format

# Level selection

![image](https://user-images.githubusercontent.com/51932861/188350858-5f747168-c13d-4f4b-aee6-564d25d5249c.png)

## Selector
  - Animation when level is unlocked
  - Selection animation when a level is choosed
  - A text hint is displayed for each level
  - Status of corresponding level :

                 - red : Locked
                 - green : Available

### levels of difficulty related to mouse movement possibilities.

  1. Horizontal rotation only (Horizontal:  Right Clic button Mouse  + mouse movement ← or →)
  2. Horizontal and vertical rotations (Vertical: Right Clic button Mouse + mouse movement ↑ or ↓)
  3. Horizontal and vertical rotations + object positions (Positions(switch to another object): cpase)

If the level is passed: go to the Level selection menu - click on the "WIN" button.

![image](https://user-images.githubusercontent.com/51932861/188352402-e4095242-5d89-4d3e-aef0-7c9cab6f94da.png)

# Level scene

![image](https://user-images.githubusercontent.com/51932861/188352887-32d14099-d094-4ac7-aba7-0247ef8b6dc0.png)

Distorted object representing a specific shadow with specific rotation and position.


### When your shadow is close to a recognizable object: 
#### The game will stop, and the object will slowly spin up to the ideal shape of the object.
