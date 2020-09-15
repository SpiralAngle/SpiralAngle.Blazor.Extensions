# SpiralAngle.Blazor.Extensions

This project is a collection of code helpers designed to simplify common Blazor tasks.

This will primarily consist of C# extension methods. If you are using languages that do not support extension methods, you can still use them as normal static methods.

The current focus is on improving the developer's access to the underlying model by adding generics based extensions methods and creating cleaner access to the underlying model. Currently `EditContext` and `FieldIdentifier` will notify you of changes, but don't do more than give you the name of what changed. This library helps with that by simply wrapping up casts and property access.

**Note**: While many methods take on the appearance of using generics, inside the method they are using casts. This means you can easily create `InvalidCastExceptions`. This is not something readily handled at compile time. If you find yourself using the generic methods a lot, I'd suggest talking to the [asp.net core](https://github.com/dotnet/aspnetcore) team.

## EditContextExtensions

This helper simplifies getting access to model and field data within an `EditContext`. These extensions help with using `EditContext` to act as a simplified ViewModel (as in [MVVM](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93viewmodel)).

## FieldIdentifierExtensions

This helper simplifies interacting with `FieldIdentifiers`.

Most important in this are the extensions to get the value from a `FieldIdentifier`. This is a simple example where we are just using the OnFieldChanged event on `EditContext to update a string.

```csharp    
    public Creature Creature { get; set; }
    private EditContext editContext;
    private string lastChange;
    protected override void OnInitialized()
    {
        Creature = new Creature(); // simplifying here!
        editContext = new EditContext(Creature);
        editContext.OnFieldChanged += FieldChanged;
        base.OnInitialized();
    }

    private void FieldChanged(object sender, FieldChangedEventArgs e)
    {
        lastChange = $"{e.FieldIdentifier.FieldName}:{e.FieldIdentifier.GetValue()}";
    }
    // ... Don't forget to dispose event handlers, esp once you start passing the context around.
```
