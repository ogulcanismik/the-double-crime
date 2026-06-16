# The Double Crime

![The Double Crime poster](PosterV4.jpg)

*Poster designed in Adobe Photoshop. The real double crime was how many times I nudged those masks by one pixel.*

A Unity narrative adventure game set on a ship, featuring Ink-powered branching dialogue, NPC interactions, and a save system.

## Overview

Walk around the ship in third person, discover NPCs, and engage in branching conversations driven by Ink scripts. Dialogue choices can affect NPC opinions and discovery state. Includes a ledger UI, pause menu, scene teleporters, and persistent save/load via a custom save interface.

## Tech Stack

- **Engine:** Unity 6 (6000.3.10f1)
- **Render Pipeline:** Universal Render Pipeline (URP)
- **Dialogue:** [Ink](https://www.inklestudios.com/ink/) narrative scripting
- **Save System:** ESave integration with custom `ISaveable` interface
- **Camera:** Cinemachine third-person follow
- **Input:** Unity Input System

## Code Highlights

| Script | Responsibility |
|--------|----------------|
| `GameManagerScript` | Pause/interaction state, NPC selection |
| `DialogueController` | Ink story runtime, choice UI, scrollable dialogue |
| `NPCController` / `NPCSO` | NPC data, sprites, discovery state, sorting layers |
| `PlayerController` / `PlayerCameraController` | Third-person movement and camera |
| `SaveScript` / `ISaveable` | Save/load abstraction for game objects |
| `LedgerController` | In-game ledger UI |
| `BasementTeleporterScript` | Scene/area transitions |

## Ink Stories

The `Ink/Stories/` folder contains branching dialogue for six characters (Ada, Arthur, Bastian, Valeria, Fiona, C), orchestrated through `main.ink`.

## Repository Note

This repo contains **source code, Ink dialogue scripts, and the project poster** for portfolio purposes. Other art assets, audio, third-party plugins (Ink runtime, ESave), and compiled `.json` story files are not included.

## Author

Ogulcan Ismik
