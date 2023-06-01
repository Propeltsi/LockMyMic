---

LockMyMic
=========

Overview
--------

LockMyMic is a simple console application that adjusts your microphone volume to a desired level and maintains it at that level. This is useful in situations where the microphone volume may be automatically adjusted by other applications or system settings, leading to inconsistent audio levels.

The application uses the [NAudio library](https://github.com/naudio/NAudio) to interact with the audio devices.

Installation
------------

1.  Clone this repository:
    
    bash
    
    ```bash
    git clone https://github.com/Propeltsi/LockMyMic.git
    ```
    
2.  Navigate into the cloned repository:
    
    bash
    
    ```bash
    cd LockMyMic
    ```
    
3.  Build the solution using the dotnet CLI:
    
    `dotnet build`
    

Usage
-----

Run the LockMyMic application with optional arguments:

```bash
dotnet run -- <targetVolume> <pollingInterval>
```

*   `targetVolume`: The desired microphone volume level (0-100). Default: 30
*   `pollingInterval`: The time in milliseconds between volume checks. Default: 500

Example:

```bash
dotnet run -- 50 1000
```

This sets the microphone volume level to 50% and checks the volume every 1000 ms (1 second).

For help with the arguments, use the `-h` or `h` argument:

```bash
dotnet run -- -h
```

License
-------

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

---
