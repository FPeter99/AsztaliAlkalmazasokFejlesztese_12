using konyvtar_LIB;


Console.Write("3. feladat: ");

string[] fajlBeolvasas = File.ReadAllLines("konyvek.txt");
Konyvtarak konyvtarak = new Konyvtarak(fajlBeolvasas);
Console.WriteLine($"A könyvek száma: {konyvtarak.Konyvek_szama} db");



Console.WriteLine();
Console.Write("4. feladat: ");
Console.WriteLine($"A kölcsönözhető könyvek száma: {konyvtarak.Kolcsonozheto} db");



Console.WriteLine();
Console.Write("5. feladat: ");
Console.WriteLine($"Harry Potter könyvek száma: {konyvtarak.HarryPotter_szama} db");



Console.WriteLine();
Console.Write("6. feladat: ");




foreach (var ev in konyvtarak.Legtobb_egy_evben)
{
    Console.WriteLine($"A legtöbb könyvet {ev.Key} évben adták ki {ev.Count()} db");
}





Console.WriteLine();
Console.Write("7. feladat: ");
Console.WriteLine("Könyvek évenkénti darabszáma: ");

foreach (var ev in konyvtarak.Evenkenti_kiadasok)
{
    Console.WriteLine($"\t{ev.Key}: {ev.Count()} db");
}




Console.WriteLine();
Console.Write("8. feladat: ");
Console.WriteLine("Szerzők és könyveiknek száma: ");

foreach (var szerzo in konyvtarak.Szerzonkenti_kiadasok)
{
    Console.WriteLine($"\t{szerzo.Key}: {szerzo.Count()} db");
}




Console.WriteLine();
Console.Write("9. feladat: ");
Console.Write("Adjon meg egy könyvcímet: ");
string cim = Console.ReadLine();

if (konyvtarak.LetezoKonyv(cim))
{
    if (konyvtarak.KolcsonozhetoKonyv(cim))
    {
        Console.WriteLine($"A(z) \"{cim}\" című könyv kölcsönözhető.");
    }
    else
    {
        Console.WriteLine($"A(z) \"{cim}\" című könyv nem kölcsönözhető.");
    }
}
else
{
    Console.WriteLine($"Nincs ilyen könyv a könyvtárban.");
}




Console.WriteLine();
Console.Write("10. feladat: ");
Console.WriteLine($"Kölcsönözhető könyvek listája: {String.Join(", ", konyvtarak.Kolcsonozheto_konyvek)}");