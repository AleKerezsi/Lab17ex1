using Lab17ex1.Extensii;
using Lab17ex1.Models;
using Microsoft.EntityFrameworkCore;

//SeedDb();

AdaugaCategorie(new Categorie() { Nume="Imbracaminte", Pictograma= "https://example.com/pictograms/clothes.png" });
AdaugaProducator(new Producator() { Nume = "LG", Adresa="Seoul, South Korea", CUI="1234567890" });
ActualizeazaPretulUnuiProdus("Samsung Galaxy S23", new Eticheta() { CodDeBare = Guid.NewGuid(), Pret = 2199.99 });
ObtineValoareaStoculuiTotal();
ObtineValoareaStoculuiTotalDeLaUnProducator("Apple");
ObtineValoareaStoculuiTotalPerCategorie("Electronice");

//Suplimentar
AdaugaProdus();


//Adaugare de categorie
static void AdaugaCategorie(Categorie categorie)
{

    using var magazinDbContext = new MagazinDbContext();
    magazinDbContext.Categorii.Add(categorie);
    magazinDbContext.SaveChanges();
}

//Adaugare de producator
static void AdaugaProducator(Producator producator)
{
    using var magazinDbContext = new MagazinDbContext();
    magazinDbContext.Producatori.Add(producator);
    magazinDbContext.SaveChanges();
}

//Modificarea pretului unui produs
static void ActualizeazaPretulUnuiProdus(string numeProdus, Eticheta etichetaNoua)
{
    using var magazinDbContext = new MagazinDbContext();
    var produs = magazinDbContext.Produse.FirstOrDefault(produs => produs.Nume == numeProdus);
    if(produs != null) produs.Eticheta = etichetaNoua;
    magazinDbContext.SaveChanges();
}

//Obtinerea valorii totale a stocului magazinului
static void ObtineValoareaStoculuiTotal()
{
    using var magazinDbContext = new MagazinDbContext();

    var valoareaTotalaStoc = magazinDbContext.Produse.Include(produs => produs.Eticheta).Sum(produs => produs.Stoc * produs.Eticheta.Pret);

    Console.WriteLine($"Valoarea totala a stocului: {valoareaTotalaStoc}");
}

//Obtinearea valorii stocului de la un anumit producator oferit ca parametru
static void ObtineValoareaStoculuiTotalDeLaUnProducator(string numeProducator)
{
    using var magazinDbContext = new MagazinDbContext();

    var valoareaTotalaStoc = magazinDbContext.Produse
        .Include(produs => produs.Eticheta)
        .Include(produs => produs.Producator)
        .Where(produs => produs.Producator.Nume == numeProducator)
        .Sum(produs => produs.Stoc * produs.Eticheta.Pret);

    Console.WriteLine($"Valoarea totala a stocului producatorului {numeProducator} este {valoareaTotalaStoc}");
}

//Obtinerea valorii totale a stocului per categorie
static void ObtineValoareaStoculuiTotalPerCategorie(string numeCategorie)
{
    using var magazinDbContext = new MagazinDbContext();

    var valoareaTotalaStoc = magazinDbContext.Produse
        .Include(produs => produs.Eticheta)
        .Include(produs => produs.Categorie)
        .Where(produs => produs.Categorie.Nume == numeCategorie)
        .Sum(produs => produs.Stoc * produs.Eticheta.Pret);

    Console.WriteLine($"Valoarea totala a stocului din categoria {numeCategorie} este {valoareaTotalaStoc}");
}

//Adaugare de produs
static void AdaugaProdus()
{
    using var magazinDbContext = new MagazinDbContext();

    var produsNou = new Produs { 
        Nume = "iPad Pro 2023", Stoc = 30, 
        Categorie = new Categorie { Nume = "Electronice", Pictograma = "https://example.com/pictograms/electronics.png" }, 
        Producator = new Producator { Nume = "Apple", Adresa = "Cupertino, California, US", CUI = "0987654321" }, 
        Eticheta = new Eticheta { CodDeBare = Guid.NewGuid(), Pret = 3499.99 }
    };

    magazinDbContext.Add(produsNou);
    magazinDbContext.SaveChanges();

}


//ResetDB();


static void SeedDb()
{
    using var magazinDbContext = new MagazinDbContext();

    var categorii = new[]
    {
        new Categorie { Nume = "Electronice", Pictograma = "https://example.com/pictograms/electronics.png" },
        new Categorie { Nume = "Incaltaminte", Pictograma = "https://example.com/pictograms/footwear.png" },
        new Categorie { Nume = "Mobila", Pictograma = "https://example.com/pictograms/furniture.png" }
    };

    var producatori = new[]
    {
        new Producator { Nume = "Samsung", Adresa = "Seoul, South Korea", CUI = "1234567890" },
        new Producator { Nume = "Apple", Adresa = "Cupertino, California, US", CUI = "0987654321" },
        new Producator { Nume = "Nike", Adresa = "Beaverton, Oregon, US", CUI = "787637321" },
        new Producator { Nume = "Ikea", Adresa = "Delft, Netherlands", CUI = "7890123456" }

    };

    var etichete = new[]
    {
        new Eticheta { CodDeBare = Guid.NewGuid(), Pret = 1999.99 },
        new Eticheta { CodDeBare = Guid.NewGuid(), Pret = 2999.99 },
        new Eticheta { CodDeBare = Guid.NewGuid(), Pret = 999.99 },
        new Eticheta { CodDeBare = Guid.NewGuid(), Pret = 3999.99 }
    };

    var produse = new[]
    {
        new Produs { Nume = "Samsung Galaxy S23", Stoc = 100, Categorie = categorii[0], Producator = producatori[0], Eticheta = etichete[0] },
        new Produs { Nume = "iPhone 14 Pro", Stoc = 50, Categorie = categorii[0], Producator = producatori[1], Eticheta = etichete[1] },
        new Produs { Nume = "Nike Air Max 270", Stoc = 200, Categorie = categorii[1], Producator = producatori[2], Eticheta = etichete[2] },
        new Produs { Nume = "IKEA Bookcase", Stoc = 25, Categorie = categorii[2], Producator = producatori[3], Eticheta = etichete[3] }
    };

    magazinDbContext.AddRange(categorii);
    magazinDbContext.AddRange(producatori);
    magazinDbContext.AddRange(etichete);
    magazinDbContext.AddRange(produse);

    magazinDbContext.SaveChanges();

}

static void ResetDB()
{
    using var magazinDbContext = new MagazinDbContext();

    //Curat datele doar prin metoda extensie Clear, nu sterg si tabelele efectiv
    magazinDbContext.Producatori.Clear();
    magazinDbContext.Categorii.Clear();
    magazinDbContext.Etichete.Clear();
    magazinDbContext.Produse.Clear();

    magazinDbContext.SaveChanges();

}
