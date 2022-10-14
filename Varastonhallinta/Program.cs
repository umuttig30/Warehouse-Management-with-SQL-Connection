using Varastonhallinta;

//Console.WriteLine($"yhteyden tarjoaa {Projectconstants.DatabaseProvider}.");

Console.WriteLine("VARASTONHALLINTA");
while (true)
{
    Console.WriteLine("1 – Lisää uusi tuote\n2 – Poista tuote\n3 – Tulosta eri tuotteiden määrät\n4 – Muokkaa tuotenimeä\n0 – Lopeta sovellus");
    int valinta = Convert.ToInt32(Console.ReadLine());
    if (valinta == 1)
    {
        Console.WriteLine("Mitä tuotetta haluat lisätä?");
        Console.Write("Id: ");
        int uusituoteId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");
        Console.Write("Tuotteennimi: ");
        string uusituotteennimi = Console.ReadLine();
        Console.WriteLine("");
        Console.Write("Hinta: ");
        string uusituotteenhinta = Console.ReadLine();
        Console.WriteLine("");
        Console.Write("Saldo: ");
        string uusituotteensaldo = Console.ReadLine();

        AddItems(uusituoteId, uusituotteennimi, uusituotteenhinta, uusituotteensaldo);
        Console.WriteLine("Tuote lisätty.");
    }
    else if (valinta == 2)
    {
        Console.WriteLine("Mikä on poistettavan tuotteen Id?");
        int poistettavatuoteID = Convert.ToInt32(Console.ReadLine());
        DeleteItem(poistettavatuoteID);
        Console.WriteLine("Tuote Poistettu.");
    }
    else if (valinta == 3)
    {
        ReadItems();
    }
    else if (valinta == 4)
    {
        Console.Write("Anna muokattavan tuotteen Id: ");
        int muokattavatuoteID = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");
        Console.Write("Anna uusi tuotenimi: ");
        string uusimuokattutuote = Console.ReadLine();
        Console.WriteLine("");
        ChangeItems(uusimuokattutuote, muokattavatuoteID);
        Console.WriteLine("Tuote muokattu.");
    }
    else if (valinta == 5)
    {
        break;
    }
}



static void ReadItems()
{
    using (Varastonhallintaa varastonhallinta = new())
    {
        Console.WriteLine("Kaikki Tuotteet");

        //Haetaan kaikki Tuotteet taulun tietueet
        IQueryable<Tuote>? Tuotteet = varastonhallinta.Tuotteet;

        if (Tuotteet is null)
        {
            Console.WriteLine("Ei ole yhtäkään tuotetta varastossa.");
            return;
        }
        //Käydään kaikki tietueet läpi ja tulostetaan ne näytölle
        foreach (Tuote tuote in Tuotteet)
        {
            Console.WriteLine("Id: " + tuote.id);
            Console.WriteLine("Saldo: " + tuote.Varastosaldo);
            Console.WriteLine("Hinta: " + tuote.Tuotenhinta);
            Console.WriteLine("Nimi: " + tuote.Tuotenimi);
        }
    }
}



static bool AddItems(int newId, string newTuotenimi, string newTuotenhinta, string newVarastosaldo)
{
    using (Varastonhallintaa varastonhallinta = new())
    {
        Tuote tuote = new()
        {
            id = newId,
            Tuotenimi = newTuotenimi,
            Tuotenhinta = newTuotenhinta,
            Varastosaldo = newVarastosaldo

        };

        varastonhallinta.Tuotteet?.Add(tuote);

        int affected = varastonhallinta.SaveChanges();
        return (affected == 1);
    }
}



static int DeleteItem(int deletable)
{
    using (Varastonhallintaa varastonhallinta = new())
    {
        Tuote tuotedelete = varastonhallinta.Tuotteet.Find(deletable);

        if (tuotedelete is null)
        {
            Console.WriteLine("Ei löydy!");
            return 0;
        }
        else
        {
            varastonhallinta.Remove(tuotedelete);
            int affected = varastonhallinta.SaveChanges();
            return affected;
        }
    }
}


static bool ChangeItems(string newTuotename, int id)
{
    using (Varastonhallintaa varastonhallinta = new())
    {
        Tuote tuoteupdate = varastonhallinta.Tuotteet.Find(id);

        if (tuoteupdate is null)
        {
            return false;
        }
        else
        {
            tuoteupdate.Tuotenimi = newTuotename;
            int affected = varastonhallinta.SaveChanges();
            return (affected == 1);
        }
    }
}

