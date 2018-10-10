# 🥃 Kombucha 🥃

The missing package manager for Windows

* * *

## What is Kombucha?
[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2FKiedtl%2FKombucha.svg?type=shield)](https://app.fossa.io/projects/git%2Bgithub.com%2FKiedtl%2FKombucha?ref=badge_shield)


Kombucha is a command-line installer and uninstaller, much like [Homebrew](https://brew.sh/) or [Scoop](https://scoop.sh/). Kombucha was created with the goal of having a easy-to-use command-line utility that could be used to install a tool. Kombucha tries, like Scoop, to do away with UAC popups, installation wizards, MSI files, and kitten roasting.

## Concepts in Kombucha

### Bottles

Bottles are just Kombucha-jargon for a bottle or app. Bottles are stored in this repository in the `kombucha-bottles` directory. When you request an app to be installed, Kombucha looks up the `bottle.json` app manifest file in the `shelf/<app-name>/` directory. The `bottle.json` file contains the following information:

-   TITLE
-   NAME
-   HOMEPAGE
-   DESCRIPTION
-   Author(s)
-   Readme URL (plain text format)
-   LICENSE NAME
-   LICENSE URL
-   LATEST VERSION
-   DOWNLOAD TYPE (MSI, ZIP, EXE)
-   32-BIT DOWNLOAD URL
-   64-BIT DOWNLOAD URL
-   EXECUTABLE FILE NAME FOR THE APP

The app manifest will look something like this:

```json
{
    "name": "yummy-cake",
    "title": "Yummy Cake",
    "homepage": "http://www.yummy-cake.org/",
    "description": "This is a sample file.",
    "author": "Yummy Cake Company, LLC",
    "readme": "http://www.yummy-cake.org/readme.text",
    "license": {
        "name": "MIT",
        "url": "https://www.yummy-cake.org/LICENSE.text"
    },
    "latestversion": "1.3.2",
    "type": "ZIP",
    "architecture": {
        "x64": {
            "url": "http://www.yummy-cake.org/files/1.3.2-setup.zip",
            "hash": "898c1ca0015183fe2ba7d55cacf0a1dea35e873bf3f8090f362a6288c6ef08d7"
        },
        "x86": {
            "url": "http://www.yummy-cake.org/files/1.3.2-setup-x86.zip",
            "hash": "c554238bee18a03d736525e06d9258c9ecf7f64ead7c6b0d1eb04db2c0de30d0"
        }
    },
    "executable": "bin/yummy-cake-start.exe"
}
```


[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2FKiedtl%2FKombucha.svg?type=large)](https://app.fossa.io/projects/git%2Bgithub.com%2FKiedtl%2FKombucha?ref=badge_large)

### Shelves

Similar to Buckets in Scoop, Shelves are Git repositories somewhere up in the cloud that are stuffed with app manifests (i.e. `bottle.json` files) for bottles that you can download and install. The main Shelf is located in this repository in the `shelf` directory. You can create your own shelf.

## What can I do in Kombucha?

-   **INSTALL** command

    -   This command installs a bottle.
    -   Syntax: `kombucha fill [bottle name]`

-   **INSTALL-MULTIPLE** command

    -   This command installs multiple bottles.
    -   Syntax: `kombucha fill-multiple [bottle1] [bottle2] [and on and on]`

-   **RUN** command

    -   This command runs the executable binary of a bottle that was installed previously
    -   Syntax: `kombucha run [bottle]`

-   **RUN-MULTIPLE** command

    -   This command executes multiple programs.
    -   Syntax: `kombucha gulp [bottle1] [bottle2] [and on and on]`

-   **INFO** command

    -   Kombucha will output the information about a bottle. The output will look similar to this:

               ```
               Name: yummy-cake
               Author: Yummy Cake LLC
               Version: 1.1.0
               Website: https://www.yummy-cake.org/
               License: MIT (https://www.yummy-cake.org/LICENSE.text)
               Manifest:
                 C:\Users\<USER>\Kombucha\Fridge\yummy-cake\bottle.json
               Location:
                 C:\Users\<USER>\Kombucha\Fridge\yummy-cake\
               ```

    -   Syntax: `kombucha info [bottle name]`

-   **UPDATE** command

    -   Kombucha will update a bottle that was previously installed
    -   Syntax: `kombucha update [bottle]`

-   **TRY** command

    -   This command installs a bottle to a temporary directory, runs the bottle executable, and later deletes the temporary directory.
    -   Syntax: `kombucha try [bottle]`

-   **CLEAN** command
    -   This command deletes all temporary files and directories in the Kombucha fridge.
    -   Syntax: `kombucha clean`

* * *