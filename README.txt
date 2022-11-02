Bonus Submission
Cody Jensen
100591285

1. 100591285 = 31 (PRIME)
2. Watched Gameplay Video for Wrecking Crew
3. Repo is created
4. Repo is public
5. Git Ignore for Unity has been added
6. Readme added to repo
7. Unity Folder Structure Organized with proper names: DONE
8. Is the singleton properly implemented?  YES
9. Is the singleton implementation properly described?
	I have implemented a singleton into the GameManager, creating a single instance of the manager to take sole responsiblity
	for the logic and flow of the game.  It handles adding to the players score when destroying an object within the scene, as well as
	resetting the scene if the player dies after touching an enemy.  I chose to implement it this way because there should only ever be one 
	instance of the game running at a single time and we don't want conflicting information between multiple instances should that ever
	happen.  The current state of the game should be singular, and as such the GameManager has sole responsibility.
	This benefits the game by avoiding any game breaking issues that revolve around multiple instances overlapping and sending and
	receiving mixed information.  
10. Is the Observer properly implemented?  YES
11. Is the observer implementation properly described?
	I have implemented an observer pattern into the GameManager using delegates to handle the functionality of events called by other
	classes.  I start by creating a base delegate called  "void OnEvent()".  I then make two delegate functions with this, one to observe for
	if the player dies, and another to observe if an object has been destroyed.  If the player touches an enemy, it sends out a signal to the
	game manager, indicating it has died.  This results in the delegate calling the Reset function on the scene, reloading everything to its 
	initial state.  Whenever an object is interacted with by the player and destroyed, it sends out its own signal to the GameManager to
	tell it to award the player 100 points. These delegates benefit the game by allowing any class to send out its own signal in order to
	trigger events within the game.
12. Is the command Desgin pattern properly explained?
13. Is the flowchart properly presented and consistent with the explanation?
14. Is the executable file uploaded as a release? 
15. Are the instructions provided in the repository? Yes
	Controls: 
	'A' and 'D' or 'Left Arrow' and 'Right Arrow' to move left and right
	'W' and 'S' or 'Up Arrow' and 'Down Arrow' to move up and down (only when on a ladder)
	'E' to interact with an object (Destructibles and Bombs)
16. Is the project uploaded to the repo and working? 
