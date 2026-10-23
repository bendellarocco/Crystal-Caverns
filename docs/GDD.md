# Crystal Caverns — Game Design Document

Last updated Oct 23, 2026 · Owner: Ben

_Draft in progress. Sections still to write: core loop, UI and HUD, Godot technical notes, scope and milestones._

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
| Engine | Godot 4, GDScript |

The name comes from the mine setting. Crystals are not a collectible or game system.

**Open:** the explorer's name and why they are going down, the logline, and the design pillars.

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

Level 1 and the prototype use obstacles only, with no enemies.

**Open:** which obstacles appear in level 1, how much damage each does, and whether enemies arrive in later levels.

## Level structure

Each level ends at a ladder that leads down to the next level, so the player keeps descending through the cave. The current scope is one level.

**Open:** level length, checkpoints, and how later levels will differ.

## Art and audio direction

- **Art:** 16-bit pixel art with a color palette similar to Yoshi's Island.
- **Audio:** left open for now.
