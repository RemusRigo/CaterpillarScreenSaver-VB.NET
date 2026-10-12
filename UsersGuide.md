# Caterpillar ScreenSaver: User's Guide



## Downloads & Runtimes

Download the latest release from the [Releases page](https://github.com/RemusRigo/CaterpillarScreenSaver-VB.NET/releases).

Each release contains one folder per framework and architecture:

|Folder|Target Framework|Architecture|Required Runtime|
|-|-|-|-|
|`net8.0 x64`|.NET 8.0|64-bit|[.NET 8.0 Desktop Runtime (x64)](https://dotnet.microsoft.com/download/dotnet/8.0)|
|`net8.0 x86`|.NET 8.0|32-bit|[.NET 8.0 Desktop Runtime (x86)](https://dotnet.microsoft.com/download/dotnet/8.0)|
|`net10.0 x64`|.NET 10.0|64-bit|[.NET 10.0 Desktop Runtime (x64)](https://dotnet.microsoft.com/download/dotnet/10.0)|
|`net10.0 x86`|.NET 10.0|32-bit|[.NET 10.0 Desktop Runtime (x86)](https://dotnet.microsoft.com/download/dotnet/10.0)|

> **Which one do I need?** On 64-bit Windows 10/11, use **x64**. Pick the .NET version whose
> **Desktop Runtime** you already have installed, or install one from the links above.
> The plain ".NET Runtime" is not enough; the screensaver needs the **Desktop** Runtime.

To check which runtimes are installed, open a command prompt and run:

```
dotnet --list-runtimes
```

Look for a `Microsoft.WindowsDesktop.App 8.x` or `10.x` line.



## Install

1. Download and extract the folder that matches your system (see the table above), e.g. `net8.0 x64`.
2. Copy the **whole folder** to a permanent location, for example:
   `D:\My Apps\Caterpillar ScreenSaver\`
   The folder must contain all 4 files; the screensaver won't start if any of them is missing:
   * `CaterpillarSS.scr`
   * `CaterpillarSS.dll`
   * `CaterpillarSS.deps.json`
   * `CaterpillarSS.runtimeconfig.json`
3. Right-click `CaterpillarSS.scr` and choose **Install**.
   The Windows **Screen Saver Settings** dialog opens with *CaterpillarSS* selected.
4. Set the **Wait** time and click **OK**.

> If Windows blocks the file ("Windows protected your PC"), right-click `CaterpillarSS.scr` →
> **Properties** → check **Unblock** → **OK**, then try again.



## Test it

* In **Screen Saver Settings**, click **Preview**, or
* double-click `CaterpillarSS.scr`.

The caterpillar starts at a random spot on a random monitor and eats its way across your desktop.
Press any key, click, or move the mouse to exit.



## Settings

Open **Screen Saver Settings** (Start → type *screen saver*), select *CaterpillarSS*, and click **Settings...**

|Setting|Range|Description|
|-|-|-|
|**Speed**|0.5 - 5.0|How fast the caterpillar crawls|
|**Size**|8 - 24|Head size in pixels; the body gets thinner toward the tail|
|**Color**|any|Body color; the head is drawn darker, segments alternate light/dark|

A live preview of the caterpillar is shown in the dialog. Click **Ok** to save.
Settings are stored per user in the registry under `HKEY_CURRENT_USER\Software\Remus RIGO\CaterpillarSS.VB-NET`.
Right-click the title bar → **About...** for version information.



## Background image

The caterpillar eats the first background it finds, in this order:

1. **Your real desktop.** `%LocalAppData%\Remus RIGO\SnapDesktop\Desktop.png`, taken by [SnapDesktop](https://github.com/RemusRigo/SnapDesktop-VB.NET).
   It is only used if its size matches your current monitor layout.
2. **Your wallpaper**, scaled to fill every monitor.
3. **The solid desktop color** of your current Windows theme.

### Optional: eat your real desktop with SnapDesktop

Windows switches to a separate desktop when the screensaver starts, so a screensaver can't
capture your open windows by itself. [SnapDesktop](https://github.com/RemusRigo/SnapDesktop-VB.NET)
runs in the background and saves a screenshot of your desktop every minute; the screensaver then
uses that image, so the caterpillar eats your actual windows, icons, and taskbar.

1. Download and run SnapDesktop (add it to Startup to run it automatically).
2. That's it: the screensaver picks up `Desktop.png` automatically.

> After you add or remove a monitor or change resolution or scaling, the screenshot is ignored until
> SnapDesktop takes a new one. Until then, the wallpaper is used.



## Multi-monitor

The caterpillar crawls across all monitors, including ones with different resolutions or scaling.
It moves from one monitor to the next only where their edges touch in **Settings → System → Display**.



## Uninstall

1. In **Screen Saver Settings**, choose another screensaver (or *None*) and click **OK**.
2. Delete the folder you copied in step 2 of *Install*.
3. Optional: delete the registry key `HKEY_CURRENT_USER\Software\Remus RIGO\CaterpillarSS.VB-NET`.
