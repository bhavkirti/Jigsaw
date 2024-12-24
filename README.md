Current Code Structure
- Game Manager
  - Responsible for entire gameplay.
  - Loads level
  - Populate current progress and pass on the current progress for saving 

- File Manager
  - Responsible for file related operations
 
- Sound Handler
  - Responsible for all the sound related tasks

- Event Handler
  - Responsible for all the events related to the game

- Base Puzzle Piece
  - Holds the position and status of puzzle piece
  - Responsible for drag and drop functionality

- Puzzle Piece
  - Inherits BasePuzzlePiece
  - Can be used to extend some new functionalities of puzzle-piece based on some requirements
  

Current Level Prefab structure
- Reference Image
  - Sprite of complete level
- Targets
  - Target references of all the pieces
- Picture
  - Holds all the pieces
- Each levels can be converted into such a prefab and should be assigned to GameManager.
    
