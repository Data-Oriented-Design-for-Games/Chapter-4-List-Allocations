# Chapter 4 — List Allocations

Sample project for **Chapter 4** of [*High Performance Unity Game Development (Using data-oriented design)*](https://www.manning.com/books/high-performance-unity-game-development) by Nitzan Wilnai (Manning).

This is a very small test. It adds items to a `List<int>` one at a time and prints the list's
`Count` and `Capacity` after every `Add`. The question it answers: when does a `List` allocate
memory as it grows?

## What it shows

- A `List<T>` keeps its items in an internal array. `Count` is how many items are in the list.
  `Capacity` is how many items that array can hold.
- A new empty list has no room yet. The first `Add` makes the first allocation.
- When an `Add` would go past `Capacity`, the list allocates a bigger array and copies the items
  into it. The old array is left for the garbage collector.
- `Capacity` grows in jumps, not one item at a time. Each jump is an allocation you did not ask
  for.

## How the test works

All of the code is in one file, `Assets/Scripts/Main.cs`.

- `Main.RunTest` is called by the **Run Test** button. It sets a flag.
- `Main.Update` sees the flag, runs the loop below, and writes one line of text per `Add`.
- `NumTests` is the number of items to add. It is set to 20.

```csharp
List<int> IntList = new List<int>();

for (int i = 0; i < NumTests; i++)
{
    IntList.Add(i);
    ResultText.text += "List Count " + IntList.Count + " List Capacity " + IntList.Capacity + "\n";
}
```

Nothing is timed. The test only reports the two sizes.

## Running it

1. Open the project in Unity **6000.3.22f1** (Unity 6.3 LTS) or newer.
2. Open `Assets/Scenes/MainScene.unity` and press **Play**.
3. Click the **Run Test** button. The results appear as text on screen, one line per `Add`.
   Nothing is written to the Console.

To add more or fewer items, select the `Main` object in the scene and edit `NumTests` in the
Inspector.

## Reading the results

Each line looks like this:

```
List Count <items in the list> List Capacity <room in the internal array>
```

`Count` goes up by one on every line. `Capacity` stays the same for a few lines and then jumps.
Every line where `Capacity` changes is an `Add` that allocated a new array and copied the items.

To see the difference, change `new List<int>()` to `new List<int>(NumTests)` in `Main.cs` and
run the test again. `Capacity` no longer changes, because the list had enough room from the
start.

## More samples

All sample projects for the book: https://github.com/Data-Oriented-Design-for-Games
