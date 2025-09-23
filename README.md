# KitchenChaos


**## Summary ##**
KitchenChaos is a Unity game project where players work in a 
chaotic kitchen environment to fulfill orders under time pressure. 
Players manage cooking tasks, combine ingredients, use kitchen stations 
(cutting boards, stoves, plating), coordinate tasks, and deliver completed 
food orders before the time runs out.


**## Key Features & Game Mechanics : ##**
1. Order Management: Orders appear and must be completed in a timely manner.
2. Ingredient Collection & Preparation: Players need to pick up raw ingredients, cut or cook them, plate them properly.
3. Kitchen Stations: Multiple action points (e.g., chopping, cooking, plating) where different parts of an order are prepared.
4. Delivery: Once order is complete (ingredients prepared, plated), it gets delivered / counted for score.
5. Timer / Time limit: Gameplay probably constrained by time; orders must be fulfilled before timeout.


**## Controls : ##**
A. For Keyboard : 
 1. | Move chef | WASD / Arrow keys |
 2. | Kitchen Object/Food Pick up & drop | (Keyboard "E" ) |
 3. | Use cutting board/ Cutting of vegetables | (Keyboard "F") |
 4. | Pause Game | Escape key |
    
B. For GamePad : 
 1. | Move chef | Left Stick (GamePad) |
 2. | Kitchen Object/Food Pick up & drop / (Button South GamePad) |
 3. | Use cutting board/ Cutting of vegetables | (Button West GamePad) |
 4. | Pause Game | Start GamePad |


**## Best Code Practices in KitchenChaos : ##**
1. Separation of Concerns : Scripts are split into Managers, Components, and UI logic instead of cramming everything into one file. Example: GameManager handles global game state (start, pause, game over). DeliveryManager handles order spawning / checking. PlayerController only handles player movement + interactions. 👉 This keeps each script focused on one responsibility (SRP from SOLID principles).
2. Event-Driven Architecture : Uses C# events / delegates (or UnityEvents) to notify systems of changes (like “OnRecipeDelivered”, “OnStateChanged”). This decouples systems — e.g., the UI doesn’t need to constantly poll the game; it just listens for events. 👉 Helps in scalability: new UI panels or sounds can subscribe without modifying the core game logic.
3. ScriptableObjects for Data : Recipe definitions, kitchen objects, and order data are stored as ScriptableObjects instead of hard-coding values. Example: A RecipeSO might contain a list of required ingredients. Easy to extend — just make a new ScriptableObject asset, no code changes needed.
4. Use of Prefabs : Kitchen stations, plates, ingredients, and recipes are created as Prefabs with their own scripts. Prefabs make it reusable, consistent, and easy to spawn dynamically at runtime.
5. Player Input Abstraction : Likely uses Unity’s new Input System or at least keeps input handling inside a dedicated PlayerController. Prevents input logic from bleeding into unrelated scripts. Makes it easier to later switch from keyboard to gamepad.
6. Enums & State Machines : Uses Enums or State design pattern for controlling player states (Idle, Walking, Carrying, etc.) and game states (WaitingToStart, Playing, GameOver). This avoids messy boolean flags everywhere.
7. Consistent Naming & Organization : Scripts and assets follow self-explanatory names (PlateKitchenObject, StoveCounter, CuttingCounter). Organized into folders (Scripts/, Prefabs/, Materials/). Improves readability and onboarding for others.
8. Interface Usage : Uses interfaces (like IHasProgress) to generalize behaviors across different objects (cutting counter, stove, etc.). Lets UI progress bars or systems work with any object that implements the interface. 👉 Promotes polymorphism and clean architecture.
9. Code Comments & Readability : Code includes inline comments in making it reader-friendly. Public variables exposed with [SerializeField] for Unity Editor customization without breaking encapsulation.
10. 10. Error Handling & Null Checks : Scripts often guard against null references (checking if a slot is occupied before adding an ingredient). Prevents runtime crashes in Unity.

 
**##Why These Practices Matter : ##**
These practices make the project:
1. Scalable (easy to add new recipes, kitchen stations, or features)
2. Maintainable (small scripts, less spaghetti code)
3. Reusable (data and prefabs separated from logic)
4. Collaborative (other devs/designers can tweak values without touching code)
