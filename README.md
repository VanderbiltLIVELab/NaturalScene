# NaturalScene

Distance perception in an AR realistic environment. Designed for Microsoft HoloLens.
This project is created using Unity 2018.2.21f1. Any Unity 2018.2.x should work fine with this project.

## Overview

![Overview](/Pictures/overview.png?raw=true "Overview")

This project is designed for assessing human distance perception abilities in an AR realistic environment through Microsoft HoloLens. Project consists of a large 70m \* 30m terrain with trees, 6 different objects at 5 distinct distances that appear in pre-randomized order under voice commands, and floating text to indicate experiment status and data. This project implements a full experimental protocol that will be explained in [Details](#Details).

## Details

### Setup

HoloLens should be facing the area where the subject is supposed to be facing when the program starts. Camera height is set to 1.6m by default, but can be changed to whatever subject feels comfortable with. This sets the initial tracking position of the device and allows for a smooth visual experience. There should be a marked position on the ground where the subject stays at throughout the experiment. Real-world reference objects with sample unit lengths should also be provided, in whatever unit the subject desires. Subject is allowed to estimate distances in whatever unit he/she feels comfortable with.

### Experimental Protocol

Subject should stand at a fixed location without moving until the end of all trials. Floating texts to the right of the subject indicate the list and trial number that the subject is currently at. If necessary, subject is to be asked his/her current list and trial number at any point in case of errors. The texts also indicate additional status of the experiment, including Reset, Anchored, and Released. Details of those status are to be explained later.

Each list contains 30 trials in the order recorded in [NaturalSceneExpOrder.xlsx](/NaturalSceneExpOrder.xlsx). When ready, subject should say "List One" or whatever list number he/she is to be tested. Saying "Next" will begin, navigate through, and ultimately end the trials in a given order depending on the current list. For each trial, subject should indicate what object it is and an estimation of the object's distance from himself/herself. The experiment supervisor is free to determine how many lists he/she wants in a session, but a minimum of three is recommended.

### Objects

![Objects](/Pictures/objects.png?raw=true "Objects")

There are six objects used in total. The SurvivalCharacter, the Cube, the FemaleCharacter, the Tiger, the Cone, and the Bush. Heights of these objects are recorded in [NaturalSceneExpOrder.xlsx](/NaturalSceneExpOrder.xlsx), under the tab "Heights".

### Text UI

![TextUI](/Pictures/textUI.png?raw=true "Text UI")

The floating text UI is located to the front-right of the subject. It indicates:

- Current list number (1 - 4)
- Current trial number (1 - 30)
- Status of the experiment (Anchored, Released, Reset)
- Debug text from HoloToolkit Anchor Manager, appearing at the bottom near the ground

None of these should be noticeable to the subject during the trials. The debug text shall be removed in future versions where Anchor and Release features function properly.

### Voice commands

Subject is allowed to control the experiment by saying certain keywords. Supported keywords in this program are:

- **Anchor**: anchor the terrain to the current spatial mapping of the surrounded environment. This allows HoloLens to remember where the virtual scene is in regard to the real-world environment next time it starts the program. However this feature is currently under development and disabled.

- **Release**: release the stored spatial anchor. Camera will start at default location next time the program starts.

- **Next**: go to the next trial in current list. The current object on the terrain will disappear and a new one will appear at a different distance. If reached the end of list, the last object will disappear and trial number will reset. Saying "Next" again will start the list from beginning. This is the only command allowed for subject to navigate through the list.

- **Reset**: reset the experiment. List number will be set to 1, trial number set to uninitialized, and status displayed as Reset.

- **List [One, Two, Three, Four]**: set current list to be one of the four pre-randomized lists. The trial number will be reset regardless of what trial the subject was at.

## Notes

- As previously noted, the Anchor and Release features are temporarily disabled in this version. Current implementations of these commands cannot cover moving parts (objects, text UI) and premature use of these commands would cause severe visual defects.

- \[Update 08/28/19\] Camera is now set to 1.6m above ground initially and adjustable in height. This offers more flexibility while avoiding all the inconveniences of the anchor system which heavily depends on HoloLens's unreliable spatial mapping capabilities.

- Some users report that when deployed to their HoloLens, a Debug Console would appear at the lower left corner of the display with an error message that says "NullReferenceException: Object reference not set to an instance of an object". It might be inevitable to have that message since a null GameObject reference is used in [ExpManager.cs](\Assets\ExpManager.cs). The solution is to add `Debug.developerConsoleVisible = false;` to the `Update ()` function in [ExpManager.cs](\Assets\ExpManager.cs) but some text may still be visible. Currently there is no perfect solution to this problem. Please make sure to uncheck the "Development Build" option when building the project. In some cases that will effectively prevent this problem.

- When building a `.sln` solution, please build to a separate folder. Unity will create a file called `UnityOverwrite.txt` under that folder. If different, delete its contents that do not start with `#` and write `overwrite-all` instead. This makes sure Unity rebuilds all solution files and reduces chances of error.

- When deploying, make sure the settings are `Release`, `x86` and `Device` if HoloLens is connected to the computer, or `Remote Machine` if connected via wireless network.

- For each trial, object will appear at a random position at a fixed distance away from the subject. Subject must be looking at the front whey saying "Next" since the program reads user's viewing direction and determines where the next object should appear.

## Credits

This project is made under supervision of Professor Robert E. Bodenheimer at Vanderbilt University EECS Department, in collaboration with Sarah Creem-Regeher, Jeanine Stefanucci and Holly Gagnon at the University of Utah Department of Psychology. Special thanks to Lauren E. Buck at Vanderbilt EECS Department for development advices, Taylor Smith who offered code for positioning objects, and Carlos Salas who assisted to test the program.
