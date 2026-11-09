# Mini Notepad

Mini Notepad is a simple Windows desktop text editor built with C# and Windows Forms. It lets you create, edit, open, and save `.txt` files while displaying a live word and character count.

## Screenshot

![Mini Notepad showing the editor and live word and character count](screenshot.png)

## Features

| Menu or area | What it does |
| --- | --- |
| File → New | Clears the editor after confirmation if it contains text. |
| File → Open | Opens a `.txt` file using `OpenFileDialog`. |
| File → Save | Saves the editor content to a `.txt` file using `SaveFileDialog`. |
| File → Exit | Closes the application. |
| Edit → Cut, Copy, Paste | Moves or copies selected text and pastes plain text from the clipboard. |
| Status bar | Updates the word and character count as the text changes. |

## Built With

- C# and .NET
- Windows Forms
- Visual Studio 2022

## How to Run

1. Download or clone this repository.
2. Open the solution (`.sln`) or project (`.csproj`) in Visual Studio with the **.NET desktop development** workload installed.
3. Press **F5** to run Mini Notepad.
4. Type `hello world`. The status bar should show `Words: 2 | Characters: 11`.
5. Use **File → Save** to save the text and **File → Open** to open it again.
