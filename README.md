# .NET Framework
The .NET Framework is a software framework developed by Microsoft that runs primarily on Microsoft Windows. It includes a large class library called Framework Class Library and provides language interoperability(আন্তঃব্যবহার্যতা) across several programming languages

# [MonoBehaviour](https://docs.unity3d.com/ScriptReference/MonoBehaviour.html)
MonoBehaviour is the base class from which every Unity script derives.
When you use C#, you must explicitly derive from MonoBehaviour.
Start()
Update()
FixedUpdate()
LateUpdate()
OnGUI()
OnDisable()
OnEnable()

# [Application.targetFrameRate](https://docs.unity3d.com/ScriptReference/Application-targetFrameRate.html)

Instructs the game to try to render at a specified frame rate.

The default targetFrameRate is a special value of -1, which indicates that the game should render at the platform's default frame rate. This default rate depends on the platform:

- On standalone platforms the default frame rate is the maximum achievable frame rate.

- **On mobile platforms the default frame rate is less than the maximum achievable frame rate due to the need to conserve battery power. Typically on mobile platforms the default frame rate is 30 frames per second**.

- All mobile platforms have a fix cap for their maximum achievable frame rate, that is equal to the refresh rate of the screen (60 Hz = 60 fps, 40 Hz = 40 fps, ...). **Screen.currentResolution** contains the screen's refresh rate.

 ```csharp
 // Make the game run as fast as possible
Application.targetFrameRate = 300;
```
# event functions :
# Awake
This function is always called before any Start functions and also just after a prefab is instantiated. (If a GameObject is inactive during start up Awake is not called until it is made active.)

Awake is the first thing that is called when an object is activated. This makes it useful for **setting up the game object itself. It is not, however, the place to reference other objects as they may not be active yet.**


# OnEnable
(only called if the Object is active): This function is called just after the object is enabled. This happens when a MonoBehaviour **instance is created**, such as when a **level is loaded** or a GameObject with the script component is instantiated.

##### OnEnabled is unique because it is called every time the game object is enabled no matter how many times this happens. Put code here that needs to be executed each time the object is activated.

# Start
Start is called before the first frame update only if the script instance is enabled. Start is only ever called once for a giver script.

# [Time](https://docs.unity3d.com/ScriptReference/Time.html)
The interface to get time information from Unity.

# DeltaTime vs fixedDeltaTime
##### Time.DeltaTime
Depends on frame rate (Frame rate depends on Screen Refresh Rate, Screen Refresh Rate(Hz) depends on Screen Resolution )
0.0059693
0.0063711
0.0058189

##### Time.fixedDeltaTime
Always Constant (Set in Settings->Time->Time Stamp)
0.02
##### fixedTime
The time the latest FixedUpdate has started (Read Only) Increment by fixedDeltaTime.
4.16
4.18
##### timeScale
The scale at which time passes. This can be used for slow motion effects.
# FPS
```csharp
1.0f / Time.deltaTime
```


# Update
Update is called **once per frame**. It is the main workhorse function for frame updates.

# LateUpdate
LateUpdate is called once per frame, after Update has finished. Any calculations that are performed in Update will have completed when LateUpdate begins. A common use for LateUpdate would be a **following third-person camera**. If you make your character move and turn inside Update, you can perform all camera movement and rotation calculations in LateUpdate. This will ensure that the character has moved completely before the camera tracks its position.

# [FixedUpdate()](https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html)

FixedUpdate is often called more frequently than Update. It can be called multiple times per frame, if the frame rate is low and it may not be called between frames at all if the frame rate is high. All physics **calculations and updates** occur immediately after FixedUpdate. When applying movement calculations inside FixedUpdate, you do not need to multiply your values by Time.deltaTime. This is because FixedUpdate is called on a reliable timer, independent of the frame rate.


<small>Details: Frame-rate independent MonoBehaviour. FixedUpdate message for physics calculations.

MonoBehaviour.FixedUpdate has the frequency of the physics system; it is called every fixed frame-rate frame. Compute Physics system calculations after FixedUpdate. 0.02 seconds (50 calls per second) is the default time between calls. Use Time.fixedDeltaTime to access this value. Alter it by setting it to your preferred value within a script, or, navigate to Edit > Settings > Time > Fixed Timestep and set it there. The FixedUpdate frequency is more or less than Update. If the application runs at 25 frames per second (fps), Unity calls it approximately twice per frame, Alternatively, 100 fps causes approximately two rendering frames with one FixedUpdate. Control the required frame rate and Fixed Timestep rate from Time settings. Use Application.targetFrameRate to set the frame rate.

Use FixedUpdate when using Rigidbody. Set a force to a Rigidbody and it applies each fixed frame. FixedUpdate occurs at a measured time step that typically does not coincide with MonoBehaviour.Update.</small>

# Profiler overview
The Unity Profiler is a tool you can use to get performance information about your application. You can connect it to devices on your network or devices connected to your machine to test how your application runs on your intended release platform. You can also run it in the Editor to get an overview of resource allocation while you’re developing your application. To access the Profiler window go to menu: Window > Analysis > Profiler

# Script Execution Order
You cannot specify the order in which an event function is called for different instances of the same MonoBehaviour subclass. You can specify that the event functions of one MonoBehaviour subclass should be invoked before those of a different subclass (using the Script Execution Order panel of the Project Settings window).

# [Update vs Fixedupdate](https://stackoverflow.com/questions/34447682/what-is-the-difference-between-update-fixedupdate-in-unity#:~:text=Update%20runs%20once%20per%20frame,fast%2Fslow%20the%20framerate%20is.)
Update runs once per frame. FixedUpdate can run once, zero, or several times per frame, depending on how many physics frames per second are set in the time settings, and how fast/slow the framerate is

FixedUpdate is used for being in-step with the physics engine, so anything that needs to be **applied to a rigidbody** should happen in FixedUpdate. Update, on the other hand, works independantly of the physics engine. This can be benificial if a user's framerate were to drop but you need a certain calculation to keep executing, like if you were updating a **chat or voip client**, you would want regular old update.

# Unity state machine
In Unity, you can create an asset called an Animator Controller. This is a state machine template. There are states inside your state machine. ... To run your state machine, add a component called Animator to a GameObject and set it up with any Animator Controller that you've created

# Animation update loop
Out of Control 


# Rendering
**OnPreCull**: Called before the camera culls the scene. Culling determines which objects are visible to the camera. OnPreCull is called just before culling takes place.
OnBecameVisible/OnBecameInvisible: Called when an object becomes visible/invisible to any camera.
**OnWillRenderObject**: Called once for each camera if the object is visible.
**OnPreRender**: Called before the camera starts rendering the scene.
**OnRenderObject**: Called after all regular scene rendering is done. You can use GL class or Graphics.DrawMeshNow to draw custom geometry at this point.
**OnPostRender**: Called after a camera finishes rendering the scene.
**OnRenderImage**: Called after scene rendering is complete to allow post-processing
 of the image, see Post-processing Effects.
**OnGUI**: Called multiple times per frame in response to GUI events. The Layout and Repaint events are processed first, followed by a Layout and keyboard/mouse event for each input event.
**OnDrawGizmos**: Used for drawing Gizmos
 in the scene view
 for visualisation purposes.

# Coroutines
Normal coroutine updates are run after the Update function returns. A coroutine is a function that can suspend its execution (yield) until the given YieldInstruction finishes. Different uses of Coroutines:

**yield** The coroutine will continue after all Update functions have been called on the next frame.
**yield WaitForSeconds** Continue after a specified time delay, after all Update functions have been called for the frame.
**yield WaitForFixedUpdate** Continue after all FixedUpdate has been called on all scripts. If the coroutine yielded before FixedUpdate, then it resumes after FixedUpdate in the current frame.
**yield WWW** Continue after a WWW download has completed.
**yield StartCoroutine** Chains the coroutine, and will wait for the MyFunc coroutine to complete first.

```csharp
//its refresh the coroutine for next update ie this coroutine will perform again at the next update
yeild return null;
// while(condition) me if condition is satisfied , the coroutine will execute.

```

## IEnumerator
IEnumerator is a . NET type that is used to fragment large collection or files, or simply to pause an iteration. Coroutine is a Unity type that is used to create parallel actions returning a IEnumerator to do so

*When the Object is destroyed*
**OnDestroy**: This function is called after all frame updates for the last frame of the object’s existence (the object might be destroyed in response to Object.Destroy or at the closure of a scene).

*When quitting*
These functions get called on all the active objects in your scene:

**OnApplicationQuit**: This function is called on all game objects before the application is quit. In the editor it is called when the user stops playmode.
**OnDisable**: This function is called when the behaviour becomes disabled or inactive.



# [Threads](https://support.unity.com/hc/en-us/articles/208707516-Why-should-I-use-Threads-instead-of-Coroutines-)

##### Unity has a functionality called Coroutines that can be a substitution for Threads in some cases.
##### Unity Coroutines use concurrency and Threads use parallelism.

### When threads are useful to use: 

When you are computing some expensive and/or long-term operations, Threads can still be useful. Examples of this are:
* AI
* Pathfinding
* Network communication
* Files operations 


# Order of execution for event functions

# [DoTween](http://dotween.demigiant.com/getstarted.php)
## [Download and Setup DoTween Package in unity](http://dotween.demigiant.com/getstarted.php)
*Import from Asset Store, Go to DoTween Utility Panel -> Setup*
 
![DoTween](dotween.png) 

##  What is tweening
 **Inbetweening**, also commonly known as tweening, is a process in animation that involves generating intermediate frames, called inbetweens, between two keyframes. The intended result is to create the illusion of movement by smoothly transitioning one image into another
 
 ## Tweener 
 A tween that takes control of a value and animates it.
 ## Sequence
 A special tween that, instead of taking control of a value, takes control of other tweens and animates them as a group.
 ## Tween
 A generic word that indicates both a Tweener and a Sequence.
 ## Nested tween
 A tween contained inside a Sequence.
 
##### Do:
Prefix for all tween
##### Set:
Prefix for all settings
##### On:
Prefix for all callbacks

 ![DoTween](splash_shortcuts.png) 
 ![DoTween](splash_lambda.png) 
 ##### Basic Code Structure
 ```csharp
// The shortcuts way
﻿﻿﻿﻿﻿﻿﻿﻿transform.DOMove(new Vector3(2,2,2), 1);
﻿﻿﻿﻿﻿﻿﻿﻿// The generic way
﻿﻿﻿﻿﻿﻿﻿﻿DOTween.To(()=> transform.position, x=> transform.position = x, new Vector3(2,2,2), 1);
```
##### Practice
```csharp
// (DG stands for Demigiant, Tweening for, uh, tweening)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenMaruf : MonoBehaviour
{
    public Vector3 movePostion = Vector3.zero;
    public Vector3 gameObjectPosition = Vector3.zero;
    public float moveSpeed = 1.0f;
    public Ease ease = new Ease();
    private Material material;
    float i = 0;
    private void Start()
    {
        material = gameObject.GetComponent<Renderer>().material;
    }
    void Update()
    {
       if( Input.GetKeyDown(KeyCode.Space)){


            /*1 Basic movement*/
            gameObject.transform.DOMove(movePostion, moveSpeed).SetEase(ease);
            material.DOColor(Color.blue, 0);
            material.DOFade(0.5f, 2);  ALPHA:  works on supported material
              transform.DOLocalRotate(new Vector3(0, 180, 0), 1);

             i++;
             transform.DORotateQuaternion(Quaternion.Euler(0, 36*i, 0), i);

            /* 2. Sequence*/
             DOTween.Sequence()
                 .Append(gameObject.transform.DOMove(movePostion, moveSpeed).SetEase(ease))
                 .Append(gameObject.GetComponent<Renderer>().material .DOColor(Color.red, 1))
                .Append(gameObject.transform.DOMove(gameObjectPosition, moveSpeed).SetEase(ease));

            /* 3a Loop and Complete another function*/
            transform.DOMove(new Vector3(2, 2, 2), 2)
                .SetEase(Ease.OutQuint)
                .SetLoops(4)
                .OnComplete(myFunction);

            /* 3b Same as above but storing the tween and applying settings without chaining*/
            Tween myTween = transform.DOMove(new Vector3(2, 2, 2), 2);
            myTween.SetEase(Ease.OutQuint);
            myTween.SetLoops(4);
            myTween.OnComplete(myFunction);

            /* 4 You can even copy all settings from one tween to another, using SetAs():*/

             Tween myTween = transform.DOMove(new Vector3(2, 3, 4), 2)
            ﻿﻿﻿﻿﻿  .SetEase(Ease.OutQuint)
            .OnComplete(myFunction);

             material.DOColor(Color.blue, 1).SetAs(myTween);


             5. Callback without parameters
             transform.DOMoveX(4, 1).OnComplete(myFunction);  1
             transform.DOMoveX(4, 1).OnComplete(() => myCallback("Maruf") );
            /*Similar to Swift Completion handler*/
            transform.DOMoveX(4, 1).OnComplete(() => {
                myCallback("Maruf");
            })
                .SetSpeedBased(true) ;


            /*6 TweenParams + infinite looping*/
        
            TweenParams tParms = new TweenParams().SetLoops(-1).SetEase(Ease.OutElastic);
            transform.DOMoveX(15, 1).SetAs(tParms);

            transform.DOMoveX(4, 1).OnUpdate(myFunction);  Sets a callback that will be fired every time the tween updates.

        }
    }

    private void myFunction()
    {
        Debug.Log(" on completion");
    }
    private void myCallback(string name)
    {
        Debug.Log($"{name.Length}");
    }
}


```
# Tween Caution: 
```csharp
DOTween.Init(autoKillMode, useSafeMode, logBehaviour);
```

When you create a tween it will play automatically (unless you change the global defaultAutoPlay behaviour) until it completes all its loops.

When a tween is complete it is automatically killed (unless you change the global defaultAutoKill behaviour), which means you won't be able to use it anymore.

If you want to reuse the same tween, just set its autoKill behaviour to FALSE (either by changing the global autoKill settings for all tweens, or by chaining SetAutoKill(false) to your tween).

If your tween's target becomes NULL while a tween is playing errors might happen. You'll have to either be careful or activate the safe mode

 
