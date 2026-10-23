# Crystal Caverns — Game Design Document

Last updated Oct 23, 2026 · Owner: Ben

## Concept and pitch

Crystal Caverns is a fast-paced, all-ages 2D cave platformer where an explorer runs, jumps and grapples ever deeper into a cave, one level at a time.

| Field | Answer |
| --- | --- |
| Player character | An explorer |
| Core verbs | Run, jump, grappling hook |
| Feel | Fast paced, closer to Super Meat Boy |
| Structure | Separate levels; each one takes the player further down into the cave |
| Audience | All ages |
| Platform | PC first; mobile possibly later |
| Team | Solo project |
| Engine | Godot 4.7, GDScript |

The name comes from the mine setting. Crystals are not a collectible or game system.

**Open:** the explorer's name and why they are going down, the logline, and the design pillars.

## Core loop

1. Enter a level.
2. Run, jump and grapple through it.
3. Reach the ladder at the end.
4. Climb down to the next, deeper level and repeat.

## Player mechanics

The explorer has exactly three moves: run, jump and the grappling hook. There is no wall jump, dash or double jump.

### Grappling hook

What the hook does depends on where it lands:

| Hook target | Result |
| --- | --- |
| A straight wall in front of the player | The player is pulled toward the wall |
| A surface on the ceiling | The player swings from it like a pendulum |

### Health

The player has health rather than dying in one hit.

### Controls (PC)

| Action | Input |
| --- | --- |
| Run | W A S D |
| Jump | Space |
| Aim the hook | Mouse: point at a spot on a wall |
| Fire the hook | Left click |
| Add force to a swing | A or D while swinging |

Clicking fires the hook at the spot under the cursor. If the hook reaches it, the player is either pulled toward it (a wall in front) or starts swinging (a ceiling surface). If it does not reach, nothing attaches.

**Open:** run speed and jump height, hook range, what happens when the player reaches the wall after a pull, how a swing is released, how much health the player has, what refills it, and what happens when it runs out.

## Obstacles and enemies

Level 1 and the prototype use obstacles only, with no enemies. Nothing in level 1 damages the player.

**Open:** which obstacles appear in level 1, what will damage the player in later levels, and whether enemies arrive later.

## Level structure

Each level ends at a ladder that leads down to the next level, so the player keeps descending through the cave. The current scope is one level.

**Open:** level length, checkpoints, and how later levels will differ.

## Art and audio direction

- **Art:** 16-bit pixel art with a color palette similar to Yoshi's Island.
- **Audio:** left open for now.

## UI and HUD

The only HUD element is the player's health. Nothing else is shown on screen during play.

**Open:** how health is displayed (hearts, bar, number) and which menus the prototype needs.

## Technical notes

- **Engine:** Godot 4.7, GDScript.
- **Repo:** the GDD lives at `docs/GDD.md` in the Crystal-Caverns repo. The repo currently also holds an older Unity 5.1 project.

**Open:** whether the Godot project replaces the Unity files or sits beside them, tile and sprite size, and target resolution.

## Scope and milestones

The current goal is a single-level prototype to find out whether the game is fun. There is no target date.
