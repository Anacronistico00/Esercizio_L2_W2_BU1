using Esercizio_L2_W2_BU1.Models;


Console.WriteLine("++++ Inserimento CV ++++");
CV Curriculum = new CV()
{
    InformazioniPersonali = new InformazioniPersonali()
    {
        Nome = readString("Nome: "),
        Cognome = readString("Cognome: "),
        DataDiNascita = readDateTime("Data di nascita: "),
        Indirizzo = readString("Indirizzo: "),
        Telefono = readString("Telefono: "),
        Email = readString("Email: ")
    },
};

Curriculum.StudiEffettuati = new List<Studi>();
Console.WriteLine("++++ Inserimento Studi ++++");
int numStudi = readInt("Quanti percorsi di studio vuoi inserire?\n");
for (int i = 0; i < numStudi; i++)
{
    Curriculum.StudiEffettuati.Add(new Studi()
    {
        Qualifica = readString("Qualifica: "),
        Istituto = readString("Istituto: "),
        Tipo = readString("Tipo di qualifica: "),
        Dal = readDateTime("Data inizio: "),
        Al = readDateTime("Data fine: ")
    });
}

Curriculum.Impieghi = new List<Impiego>();
Console.WriteLine("++++ Inserimento Impieghi ++++");
int numImpieghi = readInt("Quanti impieghi vuoi inserire?\n");
for (int i = 0; i < numImpieghi; i++)
{
    Curriculum.Impieghi.Add(new Impiego()
    {
        Esperienza = new Esperienza()
        {
            Azienda = readString("Azienda: "),
            JobTitle = readString("Job Title: "),
            Dal = readDateTime("Data inizio: "),
            Al = readDateTime("Data fine: "),
            Descrizione = readString("Descrizione: "),
            Compiti = readString("Compiti: ")
        }
    });
}

try
{
    PrintCVDetails(Curriculum);
}
catch (Exception ex)
{
    Console.WriteLine("Errore durante la stampa del CV: " + ex.Message);
}

static string readString(string message)
{
    Console.WriteLine(message);
    return Console.ReadLine();
}
static DateTime readDateTime(string message)
{
    DateTime result;
    Console.WriteLine(message);
    while (!DateTime.TryParse(Console.ReadLine(), out result))
    {
        Console.WriteLine("Formato errato. Riprova: ");
    }
    return result;
}
static int readInt(string message)
{
    int result;
    Console.WriteLine(message);
    while (!int.TryParse(Console.ReadLine(), out result))
    {
        Console.WriteLine("Inserisci un numero valido: ");
    }
    return result;
}

static void PrintCVDetails(CV curriculum)
{
    Console.Clear();
    Console.WriteLine("CV di " + curriculum.InformazioniPersonali.Nome + " " + curriculum.InformazioniPersonali.Cognome);
    Console.WriteLine("++++ INIZIO Informazioni Personali: ++++");
    Console.WriteLine("Nome: " + curriculum.InformazioniPersonali.Nome);
    Console.WriteLine("Cognome: " + curriculum.InformazioniPersonali.Cognome);
    Console.WriteLine("Telefono: " + curriculum.InformazioniPersonali.Telefono);
    Console.WriteLine("Email: " + curriculum.InformazioniPersonali.Email);
    Console.WriteLine("++++ FINE Informazioni Personali: ++++");

    Console.WriteLine("\n++++ INIZIO Studi e Formazione: ++++");
    foreach (var studio in curriculum.StudiEffettuati)
    {
        Console.WriteLine("Istituto: " + studio.Istituto);
        Console.WriteLine("Qualifica: " + studio.Qualifica);
        Console.WriteLine("Tipo: " + studio.Tipo);
        Console.WriteLine("Dal: " + studio.Dal + " al " + studio.Al);
    }
    Console.WriteLine("++++ FINE Studi e Formazione: ++++");

    Console.WriteLine("\n++++ INIZIO Esperienze Professionali: ++++");
    foreach (var impiego in curriculum.Impieghi)
    {
        Console.WriteLine("Presso: " + impiego.Esperienza.Azienda);
        Console.WriteLine("Tipo di lavoro: " + impiego.Esperienza.JobTitle);
        Console.WriteLine("Compito: " + impiego.Esperienza.Compiti);
        Console.WriteLine("Dal: " + impiego.Esperienza.Dal + " al " + impiego.Esperienza.Al);
    }
    Console.WriteLine("++++ FINE Esperienze Professionali: ++++");
}