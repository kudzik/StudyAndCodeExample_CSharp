var person1 = new PersonRecord() { Name = "Person1", Age = 20 };

var person2 = new PersonWithConstructor("Person2", 22);

// Skopiowanie wszystkich wartości
var person4 = person1 with { };
// Nadpisanie wybranej wartości przy kopiowaniu
var person5 = person1 with { Age = 44 };



// Odczyt składowych rekordu
var person1Name = person1.Name;
var person1Age = person1.Age;

// Dekonstrukcja
var (Name, Age) = person2;

public record PersonRecord
{
    public string? Name { get; set; }
    public int Age { get; set; }
}

// rekord pozycyjny
// kompilator automatycznie tworzy właściwości Name i Age, a akcesor set ustawiany jest na init
public record PersonWithConstructor(string? Name, int Age);