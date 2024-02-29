# Lethal Giantless

## Quickstart
tl;dr: This mod removes giants from Lethal Company.
Refer to [installation](#installation) for usage, and enjoy!


## Overview
This is a BepInEx mod for the game Lethal Company, which removes all but one giant at spawn-time.
The mod contains a config file which allows adjustment of the maximum number of giants, and a scalar
that is applied to every giant's movement speed.

To adjust this config file, go to ``{GameDirectory}/BepInEx/Config`` and edit the RemoveGiants.cfg file.

- ``MaxGiants``: The maximum number of giants that can spawn.
- ``GiantMovementSpeed``: Each giant's movement speed will be multiplied by this scalar value.

The mod has been tested in version 49 in a four-player game with no issues. Future patches may be incompatible with this mod (I will continue to test as new updates are released)

If the mod isn't working with future updates, I will endeavour to fix this when I have time.

## Installation

Download the latest [release](https://github.com/flinn-fraher/LethalGiantless/releases)

- Install and configure [BepInEx](https://thunderstore.io/c/lethal-company/p/BepInEx/BepInExPack/).
- Place RemoveGiants.dll into the plugins folder in ``{GameDirectory}/BepInEx/Plugins.``
- Play a game, enjoy no giants!

Each player in the lobby needs to have this mod installed locally.

### Build

To build this mod locally:

To configure the NuGet dependency for this project, please refer to [the documentation for the LethalCompanyTemplateMod](https://github.com/LethalCompany/LethalCompanyModdingWiki/wiki/Starting-a-mod#adding-nuget-source)

- Configure the references in LT_RemoveGiants.csproj to your local installation of Lethal Company
- Build the project
- Move RemoveGiants.dll to your installation of Lethal Company following the [installation instructions](#installation)


