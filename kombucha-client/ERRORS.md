# Kombucha Errors list

* * *

**Kombucha errors start with the _K_ (internal error) or the _KE_ (user error) prefix.**

## User Errors

| Code  | Name                   | Description                                                                                         | Fix                                                              |
| ----- | ---------------------- | --------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------- |
| KE001 | Empty Culture Argument | The culture file that was being parsed had fields that were empty or null.                          |                                                                  |
| KE002 | No Package File Access | Kombucha does not have permission to access the file or directory provided for the package.sml file | Give Kombucha permission to access the package file or directory |
| KE003 | Package File Not Found | The package.sml file does not exist where Kombucha tried to access it.                              | Create the package.sml file first.                               |
| KE004 | Operation Cancelled    | The operation was cancelled by the user.                                                            |                                                                  |
| KE051 | Package Not Found      | The package that the user requested to be installed does not exist.                                 |                                                                  |
| KE101 | Package Not Installed  | The package that was requested to be run cannot be found.                                           | Install the package first.                                       |

### Miscellaneous Errors

| Code  | Name              | Description                                                                                                                | Fix                       |
| ----- | ----------------- | -------------------------------------------------------------------------------------------------------------------------- | ------------------------- |
| KE00A | Command Not Found | The command the user inputted is not recognized.                                                                           |                           |
| KE00B | Unknown Error 1A  | An unknown error occurred when Kombucha tried to access the file package.sml after the user tried to create a new package. | Please report this error. |
| KE00C | Invalid Input     | The user input was not recognized as a valid response or command.                                                          |                           |

## Internal Errors

| Code  | Name                           | Description                                                                       | Fix                     |
| ----- | ------------------------------ | --------------------------------------------------------------------------------- | ----------------------- |
| K0001 | Database Not Found             | Kombucha was unable to connect to database on kombucha-internal-000webhostapp.com | Please report this bug. |
| K0002 | Unknown Package Creation Error | An error occurred when kombucha tried to create a package.                        | Please report this bug. |
| K0001 |                                |                                                                                   |                         |

## Error Syntax

-   First syntax:

    -   `<ERROR DESCRIPTION> \n <ERROR CODE> \n <ERROR DETAILS>`
    -   Example: `Kombucha does not have permission to access the directory of file "myfile.sml" at the path of  \"" + cultureFile + "\". \nError code: KE000.\nError details: "`

-   Second syntax:
    -   `\n <ERROR CODE> : <ERROR DESCRIPTION OR DETAILS>`
    -   Example: `\nError KE004: Operation cancelled by user.`
