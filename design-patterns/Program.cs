using Patterns.Creational;


// The client code creates a builder object, passes it to the director and then initiates the construction process.
var director = new Director();
var builder = new ConcreteBuilder();

director.Builder = builder;

Console.WriteLine("Standard basic product:");
director.BuildMinimalViableProduct();
Console.WriteLine(builder.GetProduct().ListParts());

Console.WriteLine("Standard full featured product:");
director.BuildFullFeaturedProduct();
Console.WriteLine(builder.GetProduct().ListParts());

// Using builder pattern without a director
Console.WriteLine("Custom product:");
builder.BuildPartA();
builder.BuildPartC();
Console.WriteLine(builder.GetProduct().ListParts());



