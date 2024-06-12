# Team Members
 - [Rares Papusoi](https://github.com/rarese19)
 - [Hutanu Ciprian](https://github.com/ciprianhutanu)
 - [Baesu Serban](https://github.com/Serban096)
 - [Dogarel Andrei](https://github.com/AndreiDogarel)

# Grading Requirements

- [X] [User Stories (min 10); Backlog Creation](#stories) - 2 points
- [X] [Diagrams](#diagram) - 2 points
- [X] [Source Control using GIT](#git) - 2 points
- [ ] Unit testing - 2 points
- [X] [Bug reporting with solution linked to a pull request](#bug) - 1 point
- [X] [Refactoring, Code Standards](#refactoring) - 1 point
- [X] [Code commentaries](#commentaries) - 1 point
- [X] [Design Patterns](#design) - 1 point
- [X] [Using an AI tool](#ai) - 1 point

# Short Description
 
A first person shooter game with a "Prison Break" theme has the player, while controlling a dangerous inmate, going through a series of challenges to escape the prison that he has been put in. At first, you have to pass by the security guards and reach the main court where a series of guards will try and stop you. In order to successfully escape, you have to defeat all the waves withouth being caught and leave the prison. 

Video demo: [Unity-FPS](https://www.youtube.com/watch?v=_AYYKlaQhME)

Gameplay features:
- Realistic movement and interaction with the game environment
- Enemies
- Intuitive and responsive shooting mechanics
- Weapon switching system
- Ammunition 
- Map layout
- Clean HUD

Controls:
- WASD - movement
- Mouse - look around
- Left click - shoot
- R - reload
- C - crouch
- Space - jump
- Shift - run

Main Points:
- The game is a first person shooter with a "Prison Break" theme
- The player has to escape the prison by defeating all the waves of guards
- In order to fight the guards, the player has to find the weapons situated in the bathroom
- Just shoot around
<a name="stories"></a> 
# User Stories and Backlog

## User Stories
1. Rares, 20 - As a FPS enjoyer, I want to control my character's movement fluidly and interact with the game environment realistically so that I can fully immerse myself in the game world and strategically navigate through challenges.
2. Alex, 18 - As a gamer, I want to encounter a variety of enemies with unique behaviours and abilities that challenge my skills and strategies, ensuring that the gameplay remains engaging and unpredictable as I progress through different levels.
3. Ionut, 30 - As an experienced shooter player, I want intuitive and responsive shooting mechanics, a seamless weapon switching system, and a realistic ammunition management strategy that together enhance the tactical depth and immersion of combat, encouraging skill development and strategic planning.
4. Tudor, 21 - As a professional esports player, I want to immediately understand the map layout. I want an interactive and divers environment, which allows me to think different strategies for the same level.
5. Gabriel, 24 - I am a casual gamer. When I boot a game, I don't want to get tired just by looking at a pause menu, or home screen. I like to see a clean HUD with only the important stuff, like health, ammo and a minimap.
6. Ciprian, 20 - As a game critic I had the opportunity to play lots of games, and, even though I agree that gameplay matters the most, nowadays a video game should have pleasant esthetics. The universe built around the game must be consistent and believing. The theme doesn't matter as long as it has character.
7. Mihai, 35 - As someone who has been playing video games for a long time, especially enjoying the FPS genre, I truly appreciate when developers create an immersive experience, and I believe that the sound effects are a big part of that.
8. Mircea, 12 - As the best gamer there is, I can never play video games that are not optimized well enough. I want them to run smoothly on my computer, and not feel like I’m playing some 30 years old game. Also, there can’t be no mistakes done by the NPCs in the games I play, that is a big red flag.
9. Cosmin, 24 - As a passionate player, I want to contribute to the improvement of the game's quality by participating in testing and bug fixing processes. Also, I believe that it is essential for any game to have a balanced difficulty setting so that it is enjoyable for all players, regardless of skill level
10. Eusebiu, 20 - As a passionate gamer, I seek an enriched gaming experience through personalized control options and meaningful progression systems. I envision a game that allows me to tailor controls to my preferences and offers a rewarding journey of achievements and progression.

## Backlog
The backlog was created using Trello:
![Backlog](/images/backlog.png)

Each user story created a series of tasks to be done to accomodate the needs of our players.

<a name="diagram"></a>
# Diagrams
The following is a behavioral diagram that describes how the enemies are functioning:
![Diagrama inamic](/images/enemy_diagram.png)
As seen above, the enemy is idling while us, the player, are not in sight. If we are in sight, and he is capable of shooting us, he will, but if not, he will come towards us until it has the capability to shoot us.

<a name="git"></a>
# Source control using GIT
In order to leave the main branch untouched, besides feature branching, we also had every developer create his own branch, which would simulate the main branch, so that in case of a merge conflict we would be able to solve it without affecting the main branch. Even though we had some issues, we managed to solve them and have a clean main branch. Each developer had to create a pull request in order to merge his feature branch with "his main branch" and if no conflicts were found, then merge it with the main branch.
![Branches](/images/branches.png)

<a name="bug"></a>
# Bug reporting
One of the bugs that we encountered whas that the bathroom wall had no collider, so the player could go through it. The solution was to add a collider to the wall, so that the player could not go through it anymore. The bug was reported in a pull request, and the solution was linked to it. The pull request was then merged with the main branch.
![Bug](/images/bug.png)
<a name="refactoring"></a>
# Refactoring and Code Standards
The main refactoring that we did was changing the player model, which initially was created with a newer tool developed by Unity called Character Controller, to a more traditional one, which is the Rigidbody. This change was made because we decided to use an asset from the Unity Asset Store, which was not compatible with the Character Controller. So, in order for the HUD to be available and the weapon system to be running we had to make this change. The code standards were followed by all the developers, and the code was clean and easy to read.

<a name="commentaries"></a>
# Code commentaries
The code was commented by all the developers, so that it would be easier for the others to understand what each function does. This was done in order to make the code more readable and easier to understand. There are not too many comments, only enough for everyone to understand what each function or each code block does.
Example of a script with comments:

```csharp
using System;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    //Gun stats
    public int damage;
    public float timeBetweenShots, range, reloadTime;
    public int magazineSize, bulletsShot;
    private int bulletsLeft, sprayBulletNum;

    //For guns like shotguns
    public int bulletsPerTap;

    //Allow gun spray
    public bool allowButtonHold;

    //Players states
    //being only four, I don't see the point of using anything fancier than bool variables.
    private bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCamera;
    public Transform attackPoint;
    public LayerMask whatIsEnemy;// - useful after implementing enemies.



    void Start()
    {
        fpsCamera = GetComponent<PlayerLook>().cam;
        sprayBulletNum = 0;
        readyToShoot = true;
        Reload();
    }

    void Update()
    {
        PlayerInput();
    }

    private void PlayerInput() {
        
        //Should be changed to conserv cross-play
        //It's a intermediary solution
        if(allowButtonHold) {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        //Reload call
        if((Input.GetKey(KeyCode.R) && bulletsLeft < magazineSize && !reloading) || (bulletsLeft == 0 && bulletsShot != 0)) {
            Reload();
        }

        if(shooting && bulletsLeft > 0 && readyToShoot && !reloading)
        {
            Shoot();
        }

    }

    private void Reload() {
        reloading = true;

        Debug.Log("Reloading...");

        int residualBullets = bulletsLeft;

        //Takes the value of magazineSize if there are bullets left to fill another magazine,
        //else takes the rest of bullets.
        bulletsLeft = (bulletsShot > magazineSize) ? magazineSize : bulletsShot;

        bulletsShot += residualBullets;

        //Substract the bullets reloaded.
        if(bulletsShot - magazineSize < 0)
        {
            bulletsShot = 0;
        }
        else
        {
            bulletsShot -= magazineSize;
        }

        Invoke("ReloadCooldown", reloadTime);
    }

    private void ReloadCooldown()
    {
        reloading = false;
        Debug.Log("Ready to shoot!");
    }

    private void Shoot()
    {
        //Create a ray at the center of the view model
        Ray ray = new Ray(fpsCamera.transform.position, fpsCamera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * range);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, range, whatIsEnemy))
        {
            if(hitInfo.collider.GetComponent<Enemy>() != null)
            {
                hitInfo.collider.GetComponent<Enemy>().BaseInteract(damage);
            }
        }

        readyToShoot = false;

        bulletsLeft--;
        sprayBulletNum++;
        //Debug.Log("S-a tras " + sprayBulletNum);
        Debug.Log("Bullets left: " + bulletsLeft + "/" + bulletsShot);


        Invoke("ReadyToShoot", timeBetweenShots);
        
    }

    private void ReadyToShoot()
    {
        readyToShoot = true;
        if(!shooting)
        {
            sprayBulletNum = 0;
        }
    }


}

```

<a name="design"></a>
# Design Patterns
## Observer Pattern
Unity employs a robust internal system to manage the lifecycle of game objects and components, utilizing design patterns that streamline game development. One such pattern is a form of the Observer pattern, used internally to ensure that objects are updated correctly each frame. Below is a detailed description of how Unity achieves this through the `Update` and `LateUpdate` methods.
Internally, Unity uses a scheduling system that effectively mimics the Observer pattern. Each component that implements `Update`, `LateUpdate`, or other lifecycle methods (such as `FixedUpdate` for physics) implicitly subscribes to Unity's internal update loop.

As an example, consider the script for the MiniMap component, which updates the position of the player icon on the minimap each frame. By implementing the Update method, the MiniMap component subscribes to Unity's update loop and is automatically called each frame. This ensures that the player icon is updated correctly and consistently, without the need for manual scheduling or event handling.
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MinimapScript : MonoBehaviour
{

    public Transform player;
    public float fixedYPosition = 10f;

    void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = fixedYPosition;
        transform.position = newPosition;
    }
}
```

The `LateUpdate` method is called once per frame but after all `Update` methods have been processed. This ensures that any adjustments or calculations dependent on other updates are made accurately.

## State Pattern
The State pattern is a behavioral design pattern that allows an object to alter its behavior when its internal state changes. This pattern is particularly useful in game development, where game objects often have multiple states that dictate their behavior. We used this pattern in designing the enemy behavior in our game.

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject player;
    public NavMeshAgent Agent { get { return agent; } }
    public GameObject Player { get { return player; } }
    public Path path;

    [Header("Sight Values")]
    public float sightDistance = 20f;
    public float fieldOfView = 85f;

    [Header("Weapon Values")]
    [Range(0.1f, 10f)]
    public float fireRate;
    public Transform gunBarrel;

    [SerializeField]
    private string currentState;
    
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialise();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
    }

    public bool CanSeePlayer()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position;
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if (angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
                {
                    Ray ray = new Ray(transform.position, targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if (Physics.Raycast(ray, out hitInfo, sightDistance))
                    {
                        if (hitInfo.transform.gameObject == player)
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
}

```
<a name="ai"></a>
# Using an AI tool
While developing the game, we used ChatGPT to assist us in creating different scripts, and maybe even explaining some Unity features that we did not understand on our own. Even though we did use it, we can say that it is not the best tool for game development, and not to expect too much from it because it's capabilities are limited. It can be useful for some basic scripts, but for more complex ones it might not be the best choice. We found YouTube tutorials to be a lot more helpful than ChatGPT.