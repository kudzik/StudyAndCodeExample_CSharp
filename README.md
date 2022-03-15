# Study And CodeExample CSharp

## [Records](https://github.com/kudzik/StudyAndCodeExample_CSharp/blob/master/Records/Records.md)

[Dokumentacja]("https://docs.microsoft.com/pl-pl/dotnet/csharp/language-reference/builtin-types/record")
[Przewodnik]("https://docs.microsoft.com/pl-pl/dotnet/csharp/whats-new/tutorials/records")

## Opis

Rekordy to typy wartościowe które możemy deklarować obok struktur i klas. C# 10 dodaje możliwość deklaracji rekordów jako typów wartościowych `record struct`. Dodatkowo możemy zadeklarować `record class` aby w sposób semantyczny wyrazić że mamy do czynienia z typem referencyjnym.

:bulb: Bardzo często służą jako modele dla DTO w których chcemy aby były niezmienne po inicjalizacji.

## Przykłady

### Deklaracja rekordu

```C#
public record PersonRecord
{
    public string? Name { get; set; }
    public int Age { get; set; }
}

// rekord pozycyjny
// kompilator automatycznie tworzy właściwości Name i Age, a akcesor set ustawiany jest na init
public record PersonWithConstructor(string? Name, int Age);
```

## Utworzenie nowej instancji rekordu

```C#
var person1 = new PersonRecord() { Name = "Person1", Age = 20 };

var person2 = new PersonWithConstructor("Person2", 22);
```

### Niezmienność rekordu

Instancja rekordu jest niezmienna (Immutable), wartości rekordu nie mogą zmienić się po jego skonstruowaniu.

```C#
person1.Name = "Person1_Changed"; // błąd
```

### Porównywanie wartości rekordów

> Rekordy są równe gdy mają taką samą ilość składowych i wszystkie składowe mają takie same wartości. (W przeciwieństwie do klas które są równe gdy mają identyczne referencje).

Po zadeklarowaniu rekordu kompilator:

- nadpisuje metodę `Object.Equals(Object)`
- nadpisuje metodę `Object.GetHashCode()`
- zmienia zachowanie operatorów `==` i `!=`
- nadpisuje metodę `Object.ToString()`

Typ rekordu implementuje interfejs `IEquatable<T>`

### Klonowanie rekordów

Jeśli chcemy skopiować wartość rekordu do nowego obiektu, musimy użyć słowa  kluczowego `with`

```C#
var person1 = new Person("Tom", 20);
// Skopiowanie wszystkich wartości
var person2 = person1 with { };
// Nadpisanie wybranej wartości przy kopiowaniu
var person3 = person1 with { Age= 44 };

Console.WriteLine(person1); // Person { Name = Tom, Age = 20 }
Console.WriteLine(person2); // Person { Name = Tom, Age = 20 }
Console.WriteLine(person3); // Person { Name = Tom, Age = 44 }
```

### Dekonstrukcja

```C#

// Odczyt składowych rekordu
var person1Name = person1.Name;
var person1Age = person1.Age;

// Dekonstrukcja
var (name, age) = person1;
Console.WriteLine($"Name {name}, Age: {age}");
```

### Implementacja Interfejsów przez rekordy

Rekordy mogą implementować interfejsy

```C#
public readonly record struct Person(string Name, double Age) : IDisposable
{
    public void Dispose()
    {
        // ....
    }
}
```

### Dziedziczenie rekordów

Rekordy mogą dziedziczyć tyko po innych rekordach, klasy nie mogą dziedziczyć po rekordach.

```C#
Person teacher = new Teacher("Nancy", 34, 3);
Console.WriteLine(teacher);

public abstract record Person(string FirstName, double Age);
public record Teacher(string FirstName, double Age, int Grade) : Person(FirstName, Age);
```

### Rekordy generyczne

Rekordy generyczne działają tak jak pozostałe typy generyczne w C#. Działają również ograniczenia typów `where`.
