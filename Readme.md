# I Hate Giants

## Quickstart
tl;dr: This mod removes giants from Lethal Company.
Refer to [installation](#installation) for usage, and enjoy!


## Overview
This is a BepInEx mod for the game Lethal Company, which removes giants on each client as they are spawned in.

The mod has been tested in a game with four players, on version 44 with no issues. Future patches may be incompatible with this mod (I haven't tested this on version 45 yet)

If the mod isn't working with future updates, I will endeavour to fix this when I have time.

## Installation

Download the latest [release](---releases)

- Install and configure [BepInEx](https://thunderstore.io/c/lethal-company/p/BepInEx/BepInExPack/).
- Place RemoveGiants.dll into the plugins folder in ``{GameDirectory}/BepInEx/Plugins.``
- Play a game, enjoy no giants!

Each player in the lobby needs to have this mod installed locally.

### Build

To build this mod locally:

To configure the NuGet dependcies for this project, please refer to [the documentation for the LethalCompanyTemplateMod](https://github.com/LethalCompany/LethalCompanyModdingWiki/wiki/Starting-a-mod#adding-nuget-source)

- Clone the entire repository
- Open the .sln file in an IDE of your choice
- Build the project
- Navigate to ``\bin\Debug\netstandard2.1`` to find RemoveGiants.dll, following the instructions above to install.


