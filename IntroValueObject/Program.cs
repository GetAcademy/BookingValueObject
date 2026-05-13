


using IntroValueObject;

var a = new DiceRecord(2);
var b = new DiceRecord(2);

Console.WriteLine(a==b);


/*
var a = new DiceStruct(2);
var b = a;
b.Number = 6;

Console.WriteLine(a.Number);
Console.WriteLine(b.Number);
*/
/*
var per = new Person
{
    Name = new PersonName("Per"),
    StreetName = new StreetName("Gata")
};

var pål = new Person
{
    Name = new PersonName("Pål"),
    StreetName = new StreetName("Veien")
};


//per.Name = pål.StreetName;


int i = 5;
*/