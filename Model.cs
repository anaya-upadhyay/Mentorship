using System.Xml.Linq;

namespace PrimaryConstructor;

public record BankAccount(Guid id, string AccountNumber, string AccountHolder)
{
    public override string ToString() => $"{AccountHolder} ({AccountNumber})";
}

public record AdminRecord(int Id, string Name, string Email)
{
    public override string ToString() => $"{Id}: {Name} ({Email})";
}