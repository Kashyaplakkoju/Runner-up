# Runner_up Unity Project

## Overview
Runner_up is an endless runner game built in Unity, inspired by games like Subway Surfers. The player controls a character (e.g., Naruto model) that runs forward automatically, collects coins, avoids obstacles, and jumps or moves side-to-side. The game supports VR/accelerometer controls for tilting to move and jump, as well as keyboard inputs for testing. It features procedural generation of ground segments, obstacles, and coins, with basic scoring and game over mechanics on collision with obstacles.

The project includes C# scripts for player movement, spawning systems, collision handling, camera follow, and UI elements. It uses Unity's built-in physics, animation, and TextMeshPro for UI. Assets include 3D models, audio clips, and prefabs for grounds, obstacles, and coins.

## Features
- **Endless Running**: Automatic forward movement with procedural ground and obstacle spawning.
- **Controls**:
  - VR/Accelerometer: Tilt device to move left/right, tilt up to jump.
  - Keyboard (for testing): Arrow keys for left/right, Space for jump.
- **Coin Collection**: Randomly spawned coins with sound effects and score increment.
- **Obstacles**: Randomly placed blockers (jump or roll types) that end the game on collision.
- **Camera System**: Third-person camera follows the player.
- **Scoring**: Real-time score display using TextMeshPro.
- **Game Over**: Restarts the scene on obstacle collision.
- **Tap to Play**: Initial screen prompt that hides on touch.
- **Audio**: Coin collection sound and potential background music (e.g., Naruto theme).

## Scripts Overview
The project consists of several C# scripts attached to GameObjects in the Unity scene. Below is a summary of each script's purpose and key functionality:

### Cam_script.cs
- **Purpose**: Controls the camera to follow the player.
- **Key Features**:
  - Follows the player's Z-position with a fixed offset.
  - Uses `LateUpdate` for smooth following after player movement.
- **Attachment**: Attach to the Main Camera GameObject. Assign the player's Transform in the Inspector.

### CoinCollector.cs
- **Purpose**: Handles coin collection on collision.
- **Key Features**:
  - Plays an audio clip on collection.
  - Destroys the coin object.
  - Logs "Coin collected!" for debugging.
- **Attachment**: Attach to the player or a collider. Assign `collectSound` AudioClip in the Inspector.

### CoinSpawner.cs
- **Purpose**: Spawns coins in waves at random lanes (left, center, right).
- **Key Features**:
  - Spawns every `timeBetweenWaves` seconds.
  - Randomly chooses lane positions using Transforms (`left_pos`, `right_pos`, `center_pos`).
- **Attachment**: Attach to a spawner GameObject. Assign prefab and positions in the Inspector.

### Destroyer.cs
- **Purpose**: Destroys old ground segments after the player passes.
- **Key Features**:
  - Triggers ground spawning on collision with tagged "Ground" objects.
  - Destroys the collided ground.
- **Attachment**: Attach to a destroyer trigger behind the player.

### End.cs
- **Purpose**: Handles game over on obstacle collision.
- **Key Features**:
  - Restarts the current scene using `SceneManager`.
  - Logs "Game Ended" for debugging.
- **Attachment**: Attach to the player.

### Ground_Spawner.cs
- **Purpose**: Procedurally spawns ground segments and obstacles.
- **Key Features**:
  - Singleton instance for easy access.
  - Spawns ground prefabs forward.
  - Randomly spawns obstacles (50% center, 25% left/right) using two prefab variants.
- **Attachment**: Attach to a manager GameObject. Assign prefabs and lane positions.

### OBD.cs
- **Purpose**: Simple destroyer for collided objects (e.g., obstacles or coins).
- **Key Features**:
  - Destroys any object on collision.
- **Attachment**: Attach to a trigger or collider as needed.

### ObstacleSpawner.cs
- **Purpose**: Spawns obstacles at random positions (currently commented out).
- **Key Features**:
  - Singleton instance.
  - Spawns within a random X/Z range around `spawnPos`.
  - Update logic is commented; enable for timed spawning.
- **Attachment**: Attach to a spawner. Assign prefab and positions.

### Pw.cs
- **Purpose**: Handles player movement based on VR head tilt.
- **Key Features**:
  - Uses `CharacterController` for movement.
  - Moves left/right if head tilt exceeds `tiltThreshold`.
- **Attachment**: Attach to the player. Assign `VRPlayer` Transform.

### Score.cs
- **Purpose**: Manages and displays the score.
- **Key Features**:
  - Increments score on "Coin" collision.
  - Updates TextMeshPro UI in real-time.
- **Attachment**: Attach to the player or UI manager. Assign `scoreUI` TextMeshProUGUI.

### TTP.cs
- **Purpose**: Handles "Tap to Play" prompt.
- **Key Features**:
  - Hides TextMeshPro text on first touch input.
- **Attachment**: Attach to a UI manager. Assign `tapToPlayText`.

### VRF.cs
- **Purpose**: VR/accelerometer-based forward running and jumping.
- **Key Features**:
  - Starts running on strong forward tilt.
  - Moves side-to-side based on X-acceleration.
  - Jumps on Y-acceleration threshold with animation coroutine.
  - Ignores collisions between layers 3 and 6.
- **Attachment**: Attach to the player. Assign animator, rigidbody, and lane positions.

### forward.cs
- **Purpose**: Keyboard-based movement for testing/non-VR mode.
- **Key Features**:
  - Starts on mouse click.
  - Moves forward automatically.
  - Left/Right arrows switch lanes; Space jumps with animation.
  - Smooth lerp to lane positions.
- **Attachment**: Attach to the player. Assign animator, rigidbody, and lane positions.

## Setup and Installation
1. **Unity Version**: Built with Unity 2022.x or later (compatible with TextMeshPro and XR features).
2. **Dependencies**:
   - TextMeshPro (TMPro) for UI.
   - Unity XR Plugin (for VR/accelerometer support).
   - Audio clips and 3D models (e.g., Naruto FBX, coin/obj files) included in Assets.
   - GLTFUtility for importing GLTF models.
   - Google Cardboard XR for VR samples (optional).
3. **How to Run**:
   - Open the project in Unity Editor.
   - Load the `SampleScene.unity` in `Assets/Scenes/`.
   - Assign necessary prefabs, transforms, and audio clips in the Inspector for scripts.
   - Play in Editor or build for Android (supports APK builds as seen in project files like try-1.apk).
4. **Builds**: Pre-built APKs are available in the root (e.g., try-5.apk). Test on Android devices with accelerometer support.

## Controls
- **VR/Mobile**: Tilt device left/right to move lanes, tilt up to jump. Forward tilt starts the game.
- **Keyboard (Testing)**: Left/Right arrows to switch lanes, Space to jump, Mouse click to start.
- **Touch**: Tap to hide start prompt.

## Known Issues
- ObstacleSpawner Update is commented; enable for dynamic spawning.
- Some scripts log debug messages; remove in production.
- Ensure layer collisions are set (e.g., ignore between player and certain objects).

## Contributing
Fork the repository on GitHub: [Kashyaplakkoju/Runner_up](https://github.com/Kashyaplakkoju/Runner_up). Pull requests welcome for bug fixes or features.

## License
This project is open-source under the MIT License (see LICENSE.md if available).

---  
*Project generated on September 14, 2025.*
